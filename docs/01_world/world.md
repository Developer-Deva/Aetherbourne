# World and Biome Systems
**Description:** Core environmental driver systems, biome taxonomy, and hydrological cycles for Aetherbourne
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

Climate overlays affect:
* Temperature
* Snow accumulation
* Rainfall frequency
* Seasonal transitions
* Flora distribution
* Fauna adaptation
* Water freezing behavior

---

## Hazard Layers
Hazards are generated independently from biome assignment. A biome no longer dictates hazard state.

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

This increases environmental variety without additional biome definitions.

---

## Water Features
Hydrology is generated independently from biome assignment.

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

## Climate & Seasonal Hydrology
Water systems fluctuate dynamically throughout the year based on the celestial cycles documented in [Cosmology](docs/01_world/cosmology.md).

### Seasonal Cycles
*   **Spring:** Rivers swell, wetlands expand, and plant growth accelerates due to runoff.
*   **Summer:** Water levels decrease, drought risk increases in low-humidity zones.
*   **Autumn:** Stable water distribution; harvest peak in high-fertility zones.
*   **Winter:** Surface water freezes, snow accumulation increases, and river flow slows.

---

## Biome Taxonomy
Biomes are categorized by their `PlanetaryContext` profile.

A deterministic cascade evaluates the context into one of 15 base biomes.
Each biome then drives rendering, tile generation, physics modifiers, flora, fauna, ambient effects, and resources.

*   **Surface Biomes:** Forest, Highland, Grassland, Desert, Wetland, Rockland, Shrubland, Coastal, Freshwater, Ocean
*   **Emergent Biomes:** Tundra, Volcanic Crag
*   **Subterranean Biomes:** Shallow Caverns, Abyssal Chasms, Geothermal Mantle

### Base Biome Summaries
*   **Forest:** Dense vegetation, moderate moisture, and abundant life.
*   **Highland:** Rocky, high-altitude terrain with thin air and sparse flora.
*   **Grassland:** Open plains with grasses, steady movement, and balanced ecology.
*   **Desert:** Dry, high-drainage terrain with extreme heat and limited resources.
*   **Wetland:** Waterlogged ground, stagnant pools, and specialized plants.
*   **Rockland:** Exposed bedrock and sparse growth in dry, rugged terrain.
*   **Shrubland:** Transitional brushlands between forest and grassland.
*   **Coastal:** Shoreline zones with mixed land-water influence and salt-tolerant life.
*   **Freshwater:** Inland lakes and rivers with aquatic plants and drinkable water.
*   **Ocean:** Deep saltwater regions with limited light and strong currents.
*   **Tundra:** Cold, low-fertility zones with permafrost and hardy species.
*   **Volcanic Crag:** Heat-scarred rocky terrain with lava, ash, and instability.
*   **Shallow Caverns:** Upper subterranean networks with roots, fungus, and dim light.
*   **Abyssal Chasms:** Deep caves with crushing pressure, darkness, and toxic zones.
*   **Geothermal Mantle:** Extreme heat and pressure around magma chambers.

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

## Hazard Layers & Tectonic Activity
### Hazard Types
*   **Miasmic:** Poisonous gas clouds (2 Poison DMG/sec).
*   **Irradiated:** Radioactive zones (1 Rad DMG/sec; increases mutation rate).
*   **Cursed:** Arcane corruption (1 Curse DMG/sec; suppresses magic).
### Tectonic States
*   **Stable:** No geological hazards.
*   **Shifting:** Random tremors and unstable footing.
*   **Volcanic:** Active lava flows and geothermal geysers.

---

## Biome Physics Modifiers
*   **Atmospheric Pressure:** High altitudes increase stamina drain (+15%).
*   **Crushing Pressure:** Deep layers reduce movement speed (-20%) but increase stun resistance.
*   **Light Levels:** Affect visibility radius (2 to 15 tiles) and creature visual awareness.

---

## Hydrology Generation
Water is the primary ecosystem driver. It flows from high **Altitude** (Springs) through areas of high **Drainage** (Rivers) to natural depressions (Lakes). Areas with high **Humidity** but low **Drainage** naturally form **Marshes and Bogs**.

---

## Design Philosophy
*   **Value-Driven:** Biomes are labels for humans; systems should only care about the underlying floats.
*   **Interconnectivity:** Changes in one system (e.g., Hydrology) ripple through others (e.g., Fertility).
