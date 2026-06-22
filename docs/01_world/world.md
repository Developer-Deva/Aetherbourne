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

### Tundra
*   **Profile:** High Latitude, Low Humidity, Low Fertility.
*   **Characteristics:** Permafrost, sparse hardy vegetation, extreme cold.
### Rainforest
*   **Profile:** Low Latitude, High Humidity, High Fertility.
*   **Characteristics:** Dense canopy, rapid biodiversity, constant rainfall.
### Desert
*   **Profile:** Low Humidity, Low Fertility, High Drainage.
*   **Characteristics:** Extreme temperature shifts, specialized flora/fauna.
### Deep Caverns (Depth Layer 1-2)
*   **Profile:** High Altitude (relative to core), Low Light.
*   **Characteristics:** Bioluminescent flora, echoing acoustics, crushing pressure.

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

## Design Philosophy
*   **Value-Driven:** Biomes are labels for humans; systems should only care about the underlying floats.
*   **Interconnectivity:** Changes in one system (e.g., Hydrology) ripple through others (e.g., Fertility).
