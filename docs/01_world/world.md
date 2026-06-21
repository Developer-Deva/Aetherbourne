# World and Biome Systems

**Description:** Core environmental driver systems and biome taxonomy for Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

Content placeholder.

## Planetary Context (Macro Global Drivers)

All procedural generation for flora, fauna, minerals, environmental hazards, hydrology, weather systems, and ecosystem simulation derives from normalized context vectors applied to each 32x32 simulation tile.

This lightweight struct avoids expensive string labels in memory while providing enough information for biome assignment, ecological simulation, settlement generation, resource spawning, and creature adaptation systems.

```csharp
public struct PlanetaryContext
{
    public float Latitude;            // 0.0 = Equator (Hot) → 1.0 = Polar (Cold)
    public float Altitude;            // 0.0 = Sea Level → 1.0 = Mountain Peaks

    public float Humidity;            // 0.0 = Arid Desert → 1.0 = Waterlogged Saturation
    public float Drainage;            // 0.0 = Retains Water → 1.0 = Rapid Runoff
    public float Fertility;           // 0.0 = Barren → 1.0 = Extremely Fertile

    public float DistanceFromWater;   // 0.0 = Shoreline → 1.0 = Inland Landlocked
    public float WaterAvailability;   // Local water abundance after hydrology calculations

    public byte DepthLayer;           // 0 = Surface, 1 = Subterranean Caverns, 2 = Mantle Core

    public bool IsMagicalAnomaly;     // Triggers arcane/purple mutations
    public bool IsContaminated;       // Triggers hazardous/poisonous mutations

    public string HarvestingTool;     // Ex: "SonicPick", "LaserCutter", "Sickle"
}
```

## Climate Overlays

Climate is generated independently from terrain biomes and may apply to any compatible biome.

```csharp
public enum ClimateZone
{
    Tropical,
    Temperate,
    Boreal,
    Polar
}
```

Examples:

* Tropical Forest
* Temperate Forest
* Boreal Forest
* Polar Forest
* Tropical Rockland
* Polar Shrubland

Climate overlays affect:

* Temperature
* Snow accumulation
* Rainfall frequency
* Seasonal transitions
* Flora distribution
* Fauna adaptation
* Water freezing behavior

## Hazard Layers

Hazards are generated independently from biome assignment.

A biome no longer dictates its hazard state.

```csharp
public enum HazardLayer
{
    Pristine,
    Miasmic,
    Irradiated,
    Cursed,
    Volatile
}
```

Examples:

* Miasmic Forest
* Irradiated Desert
* Cursed Grassland
* Volatile Highland
* Pristine Wetland

This dramatically increases environmental variety without requiring additional biome definitions.

## Water Features

Hydrology is generated independently of biome assignment.

```csharp
public enum WaterFeature
{
    None,

    Pond,
    Lake,

    Stream,
    River,

    Spring,
    Oasis,

    Marsh,
    Bog,

    Waterfall,

    UndergroundRiver,
    UndergroundLake
}
```

Water features influence:

* Vegetation density
* Animal migration
* Settlement desirability
* Agriculture
* Resource abundance
* Disease spread
* Seasonal ecosystem shifts

---

## Design Philosophy

High-level goals for world generation, environmental consistency, and system interoperability.

## Core Concepts

- Planetary context vectors
- Climate overlays and hazards
- Biome-driven simulation

---

## Implementation / Notes

* Notes on context struct usage, biome selection, and event hooks.

## The 15 Base Biomes

A deterministic cascade evaluates the PlanetaryContext to assign a single BaseBiome enum.

This biome then drives:

* Visual rendering
* Tile generation
* Physics modifiers
* Flora generation
* Fauna spawning
* Ambient effects
* Resource tables

## Surface World Biomes (DepthLayer 0)

### 1. Forest

High humidity, moderate altitude, partial shade.

Dense multi-tile tree canopies, herbaceous undergrowth, nutrient-rich soil.

**Tile Movement Speed:** 0.8 (moderate friction through vegetation)

**Ambient Light:** Dim (canopy blocking)

**Typical Conditions**

* Moderate to high fertility
* Moderate drainage
* High humidity

**Common Water Features**

* Streams
* Rivers
* Ponds

### 2. Highland

High altitude, low temperature, low humidity.

Thin-air rocky mountain passes with sparse vegetation.

**Tile Movement Speed:** 0.7 (rough stone)

**Atmospheric Pressure:** Thin (stamina drain)

**Ambient Light:** Radiant (thin atmosphere)

**Common Water Features**

* Springs
* Streams
* Waterfalls

### 3. Grassland

Standard baseline conditions.

Stable temperate plains dominated by grasses and herbaceous crops.

**Tile Movement Speed:** 1.0 (optimal movement)

**Atmospheric Pressure:** Standard

**Ambient Light:** Radiant (open sky)

**Typical Conditions**

* Moderate fertility
* Moderate drainage

**Common Water Features**

* Rivers
* Lakes
* Ponds

### 4. Desert

Arid environment with intense sunlight and high temperatures.

Sandy tilemaps and sparse xerophytic plants.

**Tile Movement Speed:** 0.6 (sand friction)

**Ambient Light:** Radiant (intense sunlight)

**Temperature:** Thermal

**Typical Conditions**

* Very low humidity
* Low water availability
* High drainage

**Common Water Features**

* Oasis (rare)
* Seasonal streams

### 5. Wetland

Saturated moisture, low altitude, stagnant water bodies.

Sludgy mire tiles and moisture-loving vegetation.

**Tile Movement Speed:** 0.4 (mud and water resistance)

**Acoustic Profile:** Deadened (sound absorption)

**Typical Conditions**

* High humidity
* Low drainage
* High water availability

**Common Water Features**

* Marshes
* Bogs
* Shallow ponds

### 6. Rockland

High altitude, low moisture, exposed bedrock.

Mountainous stone terrain with minimal vegetation.

**Tile Movement Speed:** 0.7 (rough stone)

**Ambient Light:** Radiant

**Common Water Features**

* Springs
* Waterfalls

### 7. Shrubland

Transitional humidity and sparse brush.

Acts as a transitional biome between forest and grassland.

**Tile Movement Speed:** 0.9 (minor vegetation)

**Ambient Light:** Radiant (partial canopy)

### 8. Coastal

Land-meets-water transition zone.

Sandy beach autotiles and salt-tolerant vegetation.

**Tile Movement Speed:** 0.6 (sand and surf)

**Ambient Light:** Radiant

**Common Water Features**

* Beaches
* Estuaries
* Coastal wetlands

### 9. Freshwater

Inland lakes and rivers.

Aquatic plant life and drinkable water sources.

**Tile Movement Speed:** 0.2 (swimming)

**Atmospheric Pressure:** Crushing (depth dependent)

**Common Water Features**

* Lakes
* Rivers
* Ponds

### 10. Ocean

Deep saltwater ecosystems.

Bioluminescent organisms, deep trenches, and thermal vents.

**Tile Movement Speed:** 0.1 (water resistance)

**Atmospheric Pressure:** Crushing

**Ambient Light:** Dim (light absorption)

**Common Water Features**

* Deep trenches
* Thermal vent fields

## Emergent Surface Biomes

Emergent biomes occur when specific environmental thresholds are met.

### 11. Tundra

High latitude combined with Rockland-like conditions.

Frozen permafrost, crystalline rock formations, and minimal life.

**Generation Conditions**

* Latitude ≥ 0.85
* Cold climate overlay
* Low biological productivity

**Temperature:** Cryo

**Tile Movement Speed:** 0.75 (ice friction)

**Ambient Light:** Dim (polar twilight)

**Common Water Features**

* Frozen lakes
* Seasonal meltwater streams

### 12. Volcanic Crag

Low latitude Rockland with extreme tectonic instability.

Active lava flows, black obsidian fields, and heat distortion.

**Generation Conditions**

* Altitude ≥ 0.50
* Low Humidity
* High Tectonic Activity

**Temperature:** Thermal

**Tile Movement Speed:** 0.5 (unstable volcanic terrain)

**Ambient Light:** Dim (heat distortion)

## Subterranean Biomes

### 13. Shallow Caverns

Upper subterranean networks.

Roots penetrate from the surface.

Fungal growth, crystal formations, underground streams, and bioluminescent organisms are common.

**Atmospheric Pressure:** Standard to Crushing

**Ambient Light:** Dim

**Acoustic Profile:** Echoing

**Common Water Features**

* Underground rivers
* Underground lakes

### 14. Abyssal Chasms

Massive deep cave vaults.

Pitch-black environments containing toxic gases, ancient fossils, and biological dead zones.

**Atmospheric Pressure:** Crushing

**Ambient Light:** Pitch-Black

**Acoustic Profile:** Echoing

**Common Water Features**

* Deep underground rivers
* Toxic underground pools

### 15. Geothermal Mantle

Deep magma chambers beneath the world.

Extreme pressure and heat create hostile environments where only extremophile organisms survive.

**Atmospheric Pressure:** Crushing

**Ambient Light:** Dim (magma glow)

**Temperature:** Thermal

**Acoustic Profile:** Echoing

**Common Features**

* Magma lakes
* Geothermal vents

## Biome Physics Modifiers

## Atmospheric Pressure

### Thin

High Peaks

* +15% Stamina Drain
* -10% Jump Height

### Standard

Most Surface Environments

* Base Physics

### Crushing

Deep Water and Underground Regions

* -20% Movement Speed
* +30% Stun Resistance
* Increased Gear Degradation

## Ambient Light Levels

### Pitch-Black

* Visibility Radius: 2 Tiles
* Creatures lose visual awareness without light sources

### Dim

* Visibility Radius: 6 Tiles
* Gloomy atmosphere

### Radiant

* Visibility Radius: 15 Tiles
* Bright daylight

## Acoustic Profiles

### Deadened

* Sound absorbing terrain
* Immune to sonic attacks
* -50% Hearing Radius

### Standard

* Normal audio propagation

### Echoing

* Sound amplification and reflection
* +20% Sonic Damage
* Increased communication range

## Tectonic Activity

### Stable

* No geological hazards

### Shifting

* Random cave-ins
* Ground tremors
* Unstable footing

### Volcanic

* Active lava flows
* Explosive geysers
* Rapid environmental changes

## Hazard Layer Effects

## Pristine

No additional environmental hazards.

## Miasmic

Poisonous gas clouds and decomposition zones.

* 2 Poison Damage/Second
* Reduced Visibility

## Irradiated

Radioactive contamination.

* 1 Radiation Damage/Second
* Increased mutation rates

## Cursed

Arcane corruption.

* 1 Curse Damage/Second
* Temporary magical suppression

## Volatile

Extreme geological instability.

* Lava hazards
* Fire damage
* Explosive geothermal activity

## Fertility System

Fertility determines biological productivity.

## Low Fertility (0.0–0.3)

* Sparse vegetation
* Reduced wildlife
* Poor agriculture

## Moderate Fertility (0.3–0.7)

* Balanced ecosystems
* Stable populations

## High Fertility (0.7–1.0)

* Dense vegetation
* Rich biodiversity
* Increased agricultural output
* High settlement desirability

## Drainage System

Drainage determines how rapidly water exits an area.

## Low Drainage

* Wetlands
* Bogs
* Marshes
* Flood-prone regions

## Moderate Drainage

* Forests
* Grasslands
* Balanced ecosystems

## High Drainage

* Rocky terrain
* Arid environments
* Desert formation

## Hydrology Generation

Water is generated before biome assignment and acts as a primary ecosystem driver.

## Springs

Generated at high elevations where underground water reaches the surface.

## Streams

Generated from springs and runoff.

## Rivers

Generated when multiple streams converge.

Rivers act as major biodiversity corridors.

## Lakes

Generated in natural depressions with sufficient water accumulation.

## Ponds

Small isolated water bodies.

## Marshes and Bogs

Generated from:

* High Humidity
* Low Drainage
* Shallow Water

## Oases

Generated when groundwater surfaces within desert regions.

Oases become ecological hotspots.

## Underground Water Systems

Generated within subterranean layers.

Includes:

* Underground Rivers
* Underground Lakes

## Seasonal Hydrology

Water systems fluctuate dynamically throughout the year.

## Spring

* Rivers swell
* Wetlands expand
* Plant growth accelerates

## Summer

* Water levels decrease
* Drought risk increases

## Autumn

* Stable water distribution

## Winter

* Surface water freezes
* Snow accumulation increases
* River flow slows

## Ecological Influence Chain

Environmental systems influence one another naturally.

```text
Water Sources
      ↓
Plant Growth
      ↓
Herbivore Populations
      ↓
Predator Populations
      ↓
Settlement Growth
      ↓
Civilization Development
```

This creates emergent ecological and societal behavior without relying on scripted events.

## Biome Distribution Parameters

| Parameter           | Range     | Effect                              |
| ------------------- | --------- | ----------------------------------- |
| Latitude            | 0.0 → 1.0 | Temperature and climate             |
| Altitude            | 0.0 → 1.0 | Elevation and pressure              |
| Humidity            | 0.0 → 1.0 | Moisture availability               |
| Drainage            | 0.0 → 1.0 | Water retention and runoff          |
| Fertility           | 0.0 → 1.0 | Biological productivity             |
| Distance From Water | 0.0 → 1.0 | Aquatic influence                   |
| Water Availability  | 0.0 → 1.0 | Hydrological abundance              |
| Depth Layer         | 0, 1, 2   | Surface and subterranean generation |
| Magical Anomaly     | Boolean   | Arcane mutations and resources      |
| Contamination       | Boolean   | Toxic and radioactive content       |

---

## Design Philosophy

Biomes exist primarily as human-readable environmental labels.

Simulation systems should derive behavior from the underlying environmental values:

* Latitude
* Altitude
* Humidity
* Drainage
* Fertility
* Water Availability
* Hazard Layers
* Climate Overlays
* Tectonic Activity

This allows flora, fauna, civilizations, diseases, mutations, evolution, and ecological interactions to emerge naturally from world conditions rather than biome-specific hardcoded rules.