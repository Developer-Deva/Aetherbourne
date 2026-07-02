# Core Item Structures Technical Specification

This document details the low-level data architecture, memory layouts, and systemic paradigms governing items within the *Aetherbourne* simulation engine. The technical design enforces strict memory continuity, 100% deterministic integer math, low-overhead Foreign Function Interface (FFI) boundary passes to the MonoGame client, and high cache-line efficiency.

---

## 1. Architectural Foundation

Items in *Aetherbourne* are modeled via a **Dual-State Architectural Paradigm**. They prioritize memory locality and minimize Entity Component System (ECS) entity bloat by mutating their underlying representation based on spatial context.

```
+-------------------------------------------------------------------------+
|                           DUAL-STATE MODEL                              |
+-------------------------------------------------------------------------+
|                                                                         |
|  [ IN INVENTORY ]                                                       |
|  Container Entity (Chest/Inhabitant) -> Inventory Component             |
|                                         |                               |
|                                         +-> Contiguous Array of:        |
|                                             [Item Struct (128 Bytes)]   |
|                                             [Item Struct (128 Bytes)]   |
|                                                                         |
|  [ IN WORLD SPACE ]                                                     |
|  World Entity -> Components: [Transform] [Renderable] [ItemPayload]     |
|                                                              |          |
|                                                              +---> holds|
|                                                     [Item Structs]      |
+-------------------------------------------------------------------------+

```

### 1.1 Inventory Items (Contiguous Value Types)

When stored inside a container (e.g., backpacks, chest tiles, production stations), items are **not** independent entities in the ECS registry. They are pure data structures packed contiguously inside an allocated vector or fixed array within the host container’s `Inventory` component.

### 1.2 World Items (ECS Entities)

When dropped or spawned directly onto a map tile, the engine wraps the item structure inside a first-class ECS Entity. The entity receives spatial components (`Transform`, `Position`), interaction hooks (`Targetable`), a rendering component (`Renderable`), and an `ItemPayload` component containing the identical base item struct.

---

## 2. Low-Level Layout (Rust Backend)

To ensure binary compatibility across the FFI boundary to the C# client without performance-degrading serialization layers, the base item structure is compiled under the C calling convention (`#[repr(C)]`).

The universal item properties array size is bounded to **28 entries**. This optimizes the entire `Item` data footprint to exactly **128 bytes**, fitting cleanly into exactly **two 64-byte CPU cache lines** to eliminate alignment padding and maximize cache locality.

```rust
/// Universal Item Spectrum Indices mapped via compile-time constants.
/// Represents a fixed-point scale from 0 to 10000 (0.00% to 100.00%).
#[repr(u32)]
pub enum ItemAxis {
    // --- Group A: Fundamental Physics ---
    MassDensity = 0,
    VolumeFootprint = 1,
    StructuralDurability = 2,
    HardnessToughness = 3,

    // --- Group B: Thermodynamics & Environment ---
    ThermalEnergy = 4,
    HydroSaturation = 5,

    // --- Group C: Alchemy & Chemical Vectors ---
    AethericSaturation = 6,
    MaterialPurity = 7,
    VolatilityFlammability = 8,
    ToxicityContamination = 9,

    // --- Group D: Biology & Organics ---
    DecompositionRate = 10,
    NutritionalBioFuel = 11,
    GeneticMutationLatency = 12,

    // --- Group E: Cognitive Resonance ---
    CognitiveDensity = 13,
    HistoricalAura = 14,

    // --- Group F: Mechanical Utility ---
    SharpnessPenetration = 15,
    InsulationBuffering = 16,

    // --- Reserved Slots for Future Systems (11 Open Slots) ---
    Reserved17 = 17, Reserved18 = 18, Reserved19 = 19, Reserved20 = 20,
    Reserved21 = 21, Reserved22 = 22, Reserved23 = 23, Reserved24 = 24,
    Reserved25 = 25, Reserved26 = 26, Reserved27 = 27,
}

/// Binary Bitfields for rapid capability checks.
pub type StructuralFlags = u64;

pub const FLAG_NONE: u64             = 0;
pub const FLAG_IS_LIQUID: u64        = 1 << 0;
pub const FLAG_IS_GASEOUS: u64       = 1 << 1;
pub const FLAG_IS_FLAMMABLE: u64     = 1 << 2;
pub const FLAG_IS_BURNING: u64       = 1 << 3;
pub const FLAG_IS_EDIBLE: u64        = 1 << 4;
pub const FLAG_CAN_HARVEST: u64      = 1 << 5;
pub const FLAG_IS_EQUIPMENT: u64     = 1 << 6;
pub const FLAG_HAS_GENETICS: u64     = 1 << 7;

/// The canonical, fixed-size 128-byte Blittable Item Structure.
#[repr(C)]
#[derive(Copy, Clone, Debug, PartialEq, Eq)]
pub struct Item {
    pub structural_flags: u64,   // 8 Bytes: Bitfield capabilities
    pub axes: [i32; 28],         // 112 Bytes: Multi-axial fixed-point arrays
    pub item_type_id: u32,       // 4 Bytes: Static database definition fallback ID
    pub quantity: u32,           // 4 Bytes: Stack magnitude 
} // Total: Exactly 128 Bytes (2 Cache Lines)

```

---

## 3. Container-Mediated Simulation Engine

Because inventory items are pure data structures rather than standalone ECS entities, they are bypassed by the global ECS system loops. Instead, environmental reactions (e.g., rotting, heating, freezing, combusting) are executed via **Container-Mediated Simulation**.

Global environmental engines interact purely with the container entity. The container then propagates the external thermodynamic or biological forces inward to its local contiguous item blocks using staggered ticking patterns.

### 3.1 Step-by-Step Simulation Flow

1. **Environmental Vector Injection:** A room is set ablaze. The global `ThermodynamicsSystem` scans the world grid, detects a `Chest Entity`, and increments the Chest's personal `ThermalEnergy` component.
2. **Container Barrier Mitigation:** The container evaluates its own defensive properties (e.g., insulation coefficients, air tightness) to compute how much of the environmental force breaches the hull.
3. **Contiguous Array Modification:** The container updates its items. Because the item structs reside sequentially in memory, the CPU streams the properties through cache lines without pointer chasing.

```rust
pub struct Inventory {
    pub items: Vec<Item>, // Sequentially allocated in memory heap
    pub insulation_rating: i32, // Fixed point scalar mitigating heat ingress
}

/// System executed on a staggered scheduler (e.g., every 30 ticks) to update internal items.
pub fn simulate_container_inventories(
    ambient_temperature: i32, 
    inventories: &mut Vec<Inventory>
) {
    for inventory in inventories.iter_mut() {
        // Calculate heat bleeding into the container
        let thermal_delta = (ambient_temperature - 5000) * (10000 - inventory.insulation_rating) / 10000;
        
        // Loop over items contiguously. High-performance cache friendliness.
        for item in inventory.items.iter_mut() {
            // Apply thermal updates to the item properties array
            item.axes[ItemAxis::ThermalEnergy as usize] += thermal_delta;
            
            // Systemic check: Handle item ignition via bitfield transitions
            if (item.structural_flags & FLAG_IS_FLAMMABLE) != 0 {
                let current_heat = item.axes[ItemAxis::ThermalEnergy as usize];
                let volatility = item.axes[ItemAxis::VolatilityFlammability as usize];
                
                // If heat exceeds threshold computed from material volatility
                if current_heat > (10000 - volatility) {
                    item.structural_flags |= FLAG_IS_BURNING;
                }
            }
        }
    }
}

```

---

## 4. FFI Boundary & Interoperability Layer (C# / MonoGame)

To prevent Garbage Collection (GC) pressure, boxing overhead, and marshaling lag in the MonoGame frontend client, the C# application processes the item structures as raw unmanaged blittable memory blocks.

### 4.1 The C# Layout Mirror

```csharp
using System;
using System.Runtime.InteropServices;

namespace Aetherbourne.Client.Engine
{
    public enum ItemAxis : uint
    {
        MassDensity = 0, VolumeFootprint = 1, StructuralDurability = 2, HardnessToughness = 3,
        ThermalEnergy = 4, HydroSaturation = 5, AethericSaturation = 6, MaterialPurity = 7,
        VolatilityFlammability = 8, ToxicityContamination = 9, DecompositionRate = 10,
        NutritionalBioFuel = 11, GeneticMutationLatency = 12, CognitiveDensity = 13,
        HistoricalAura = 14, SharpnessPenetration = 15, InsulationBuffering = 16
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct Item
    {
        public ulong StructuralFlags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public int[] Axes;
        public uint ItemTypeId;
        public uint Quantity;
    }
}

```

### 4.2 Zero-Allocation Rendering Read Execution

When rendering UI menus or inspect windows, the C# engine must not clone or serialize data arrays. Instead, it queries the Rust engine for a Direct Pointer Reference into the container's active contiguous memory buffer.

```csharp
public unsafe void RenderInventoryOverlay(uint containerEntityId)
{
    // Fetch direct pointer location and quantity boundary via Rust FFI call
    Item* itemBufferNative = NativeEngine.GetInventoryBuffer(containerEntityId, out int itemIdxCount);
    
    // Wrap native memory pointer in a highly optimized, allocation-free ReadOnlySpan
    ReadOnlySpan<Item> inventoryView = new ReadOnlySpan<Item>(itemBufferNative, itemIdxCount);

    for (int i = 0; i < inventoryView.Length; i++)
    {
        ref readonly Item item = ref inventoryView[i];
        
        // Instant data interrogation without allocation
        uint typeId = item.ItemTypeId;
        int currentDurability = item.Axes[(int)ItemAxis.StructuralDurability];
        bool isBurning = (item.StructuralFlags & (1UL << 3)) != 0;

        DrawItemSlotSprite(i, typeId, currentDurability, isBurning);
    }
}

```

---

## 5. Mathematical & Architectural Design Bounds

To guarantee deterministic correctness and high framework resilience across development cycles, the following structural constraints are absolute:

1. **Fixed-Point Normalization Boundaries:** All values stored inside the `axes` integer collection must scale strictly within the range of `0` to `10000`. Midpoints or balanced points default to `5000`. Mathematical translations requiring fractions are executed via integer division scaling (`Value * Modifier / 10000`).
2. **Zero Heap-Allocation Mandate:** The `Item` data record must remain structural and fully blittable. It must never contain dynamic heap-allocated collection types (`Vec`, `String`, `HashSet`, or references to managed class models).
3. **State Mutation Containment:** Moving items between inventory containers requires direct memory copies (`Copy/Clone`) and array appends/truncations. Spawning a dropped item requires reading the local data structure, initializing an ECS wrapper container entity on the target map coordinate, and copying the struct directly inside the new entity's `ItemPayload` component.
4. **Reserved Structural Expansion Padding:** Indices `17` through `27` are locked out from active design assignments and function entirely as padding arrays to absorb unannounced features (e.g., electromagnetism, radiological corruption matrices) without changing structural sizing properties, database schemas, or client binding interfaces.