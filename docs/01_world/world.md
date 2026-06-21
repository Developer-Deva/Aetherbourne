# World and Biome Systems
**Description:** Core environmental driver systems and biome taxonomy for Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
The world of Aetherbourne is generated through a series of interlocking environmental systems. Rather than static labels, biomes are emergent properties of underlying physical values.

---

## Planetary Context (Macro Global Drivers)
Every 32x32 simulation tile is defined by a `PlanetaryContext` struct. This data drives all subsequent ecological and hydrological simulations.

```csharp
public struct PlanetaryContext
{
    public float Latitude;            // 0.0 = Equator (Hot) → 1.0 = Polar (Cold)
    public float Altitude;            // 0.0 = Sea Level → 1.0 = Mountain Peaks
    public float Humidity;            // 0.0 = Arid → 1.0 = Saturated
    public float Drainage;            // 0.0 = Retains Water → 1.0 = Rapid Runoff
    public float Fertility;           // 0.0 = Barren → 1.0 = Extremely Fertile
    public float DistanceFromWater;   // 0.0 = Shoreline → 1.0 = Inland
    public float WaterAvailability;   // Calculated from local hydrology
    public byte DepthLayer;           // 0 = Surface, 1 = Caverns, 2 = Core
    public bool IsMagicalAnomaly;     // Triggers arcane mutations
    public bool IsContaminated;       // Triggers hazardous mutations
}
```

---

## Fertility & Ecology
**Fertility** represents the biological potential of the soil, but **Plant Growth** is a function of both Fertility and Water.
*   **High Fertility + Low Water:** Sparse, hardy vegetation (e.g., Savanna).
*   **High Fertility + High Water:** Dense, rapid growth (e.g., Rainforest).
*   **Low Fertility + High Water:** Specialized, slow growth (e.g., Peat Bogs).

---

## Acoustic Profiles & AI Perception
The acoustic profile of a biome directly modifies creature behavior and AI detection logic.

| Profile | Sound Propagation | AI / Stealth Impact |
| :--- | :--- | :--- |
| **Deadened** | -50% Range | +20% Stealth; Harder to communicate. |
| **Standard** | 100% Range | Baseline perception and communication. |
| **Echoing** | +50% Range | -20% Stealth; +20% Sonic Damage. |

---

## Biome Physics Modifiers
*   **Atmospheric Pressure:** High altitudes increase stamina drain (+15%).
*   **Crushing Pressure:** Deep subterranean or aquatic layers reduce movement speed (-20%) but increase stun resistance.
*   **Light Levels:** Affect visibility radius (2 to 15 tiles) and creature visual awareness.

---

## Hydrology Generation
Water is the primary ecosystem driver. It flows from high **Altitude** (Springs) through areas of high **Drainage** (Rivers) to natural depressions (Lakes). Areas with high **Humidity** but low **Drainage** naturally form **Marshes and Bogs**.

---

## Design Philosophy
*   **Value-Driven:** Biomes are labels for humans; systems should only care about the underlying floats (Latitude, Humidity, etc.).
*   **Interconnectivity:** Changes in one system (e.g., Hydrology) should naturally ripple through others (e.g., Fertility and Populations).
