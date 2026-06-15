# World and Biome Systems

**Description:** Core environmental driver systems and biome taxonomy for Aetherbourne
**Last Updated:** 2026-06-15

---

## Planetary Context (Macro Global Drivers)

All procedural generation for flora, minerals, and environmental effects derives from normalized context vectors applied to each 32x32 simulation tile. This lightweight struct avoids expensive string labels in memory:

```csharp
public struct PlanetaryContext
{
    public float Latitude;           // 0.0 = Equator (Hot) → 1.0 = Polar (Cold)
    public float Altitude;           // 0.0 = Sea Level → 1.0 = Mountain Peaks
    public float Humidity;           // 0.0 = Arid Desert → 1.0 = Waterlogged Saturation
    public float DistanceFromWater;  // 0.0 = Shoreline → 1.0 = Inland Landlocked
    public byte DepthLayer;          // 0 = Surface, 1 = Subterranean Caverns, 2 = Mantle Core
    public bool IsMagicalAnomaly;    // Triggers arcane/purple mutations
    public bool IsContaminated;      // Triggers hazardous/poisonous mutations
    public string HarvestingTool;    // Ex: "SonicPick", "LaserCutter", "Sickle"
}
```

---

## The 15 Base Biomes

A deterministic cascade evaluates the PlanetaryContext to assign a single BaseBiome enum, which then drives visual rendering, physics modifiers, hazard layers, and procedural content generation.

### Surface World Biomes (DepthLayer 0)

1. **Forest**: High humidity, moderate altitude, partial shade. Dense multi-tile tree canopies, herbaceous undergrowth, nutrient-rich soil.
   - Tile Movement Speed: 0.8 (moderate friction through vegetation)
   - Ambient Light: Dim (canopy blocking)
   - Hazards: Pristine or Miasmic (decomposition)

2. **Highland**: High altitude, low temperature, low humidity. Thin-air rocky mountain passes, sparse vegetation.
   - Tile Movement Speed: 0.7 (rough stone)
   - Atmospheric Pressure: Thin (stamina drain)
   - Ambient Light: Radiant (thin atmosphere)
   - Hazards: Pristine or Volcanic (tectonic activity)

3. **Grassland**: Standard baseline conditions. Stable temperate plains, grass and herbaceous crops.
   - Tile Movement Speed: 1.0 (optimal movement)
   - Atmospheric Pressure: Standard
   - Ambient Light: Radiant (open sky)
   - Hazards: Pristine

4. **Desert**: Arid, maximum light tracking, high temperature, low humidity. Sandy tilemaps, sparse xerophytic plants.
   - Tile Movement Speed: 0.6 (sand friction)
   - Ambient Light: Radiant (intense sunlight)
   - Temperature: Thermal (hot)
   - Hazards: Pristine or Cursed (magical voids)

5. **Wetland**: Saturated moisture, low altitude, stagnant water bodies. Sludgy mire tiles, low movement, miasmic gas hazards.
   - Tile Movement Speed: 0.4 (mud, water resistance)
   - Atmospheric Pressure: Crushing (water weight)
   - Acoustic Profile: Deadened (sound absorption)
   - Hazards: Miasmic (poisonous fog)

6. **Rockland**: High altitude, low moisture, exposed bedrock. Mountainous grey rock tiles, minimal vegetation, hard terrain.
   - Tile Movement Speed: 0.7 (rough stone)
   - Ambient Light: Radiant
   - Hazards: Pristine or Volcanic

7. **Shrubland**: Transitional humidity, sparse brush and alchemical greenery. Transitional biome between forest and grassland.
   - Tile Movement Speed: 0.9 (minor vegetation)
   - Ambient Light: Radiant (partial canopy)
   - Hazards: Pristine or Miasmic

8. **Coastal**: Land-meets-water boundary. Sandy beach auto-tiles, salt-tolerant plants, transition zone.
   - Tile Movement Speed: 0.6 (sand and surf)
   - Ambient Light: Radiant
   - Hazards: Pristine or Irradiated (brine pools)

9. **Freshwater**: Inland bodies of water. Fresh lakes and rivers, aquatic plant life, drinkable water.
   - Tile Movement Speed: 0.2 (water swimming)
   - Atmospheric Pressure: Crushing (water depth)
   - Hazards: Pristine or Miasmic (stagnant water)

10. **Ocean**: Lowest altitude, deep saltwater. Deep saltwater tilemap textures, bioluminescent organisms, crushing pressure.
    - Tile Movement Speed: 0.1 (water resistance)
    - Atmospheric Pressure: Crushing (deep water)
    - Ambient Light: Dim (light absorption)
    - Hazards: Pristine or Irradiated (thermal vents)

### Emergent Biomes (DepthLayer 0, Calculated from Conditions)

11. **Tundra**: High latitude + Rockland conditions. Frozen permafrost, crystalline rock tiles, minimal life.
    - Latitude: ≥ 0.85
    - Temperature: Cryo (frozen)
    - Tile Movement Speed: 0.75 (ice friction)
    - Ambient Light: Dim (polar twilight)
    - Hazards: Pristine or Irradiated

12. **Volcanic Crag**: Low latitude + Rockland + High tectonic activity. Active surface lava, black obsidian tiles, heat shimmer.
    - Conditions: Altitude ≥ 0.50 & Low Humidity & High Tectonic Activity
    - Temperature: Thermal (lava proximity)
    - Tile Movement Speed: 0.5 (unstable lava)
    - Ambient Light: Dim (heat distortion)
    - Hazards: Volatile (active lava)

### Subterranean Biomes (DepthLayer 1 & 2)

13. **Shallow Caverns** (DepthLayer 1 - Upper): Dim light, deadened sound, surface roots breaking through. Fungal growth, crystal formations, underground streams.
    - Atmospheric Pressure: Standard to Crushing
    - Ambient Light: Dim (bioluminescent fungi)
    - Acoustic Profile: Echoing (stone chambers)
    - Hazards: Pristine or Miasmic

14. **Abyssal Chasms** (DepthLayer 1 - Lower): Pitch-black, echoing vaults, pooling toxic/radioactive gases. Absolute biological void, toxic spore clouds, ancient fossils.
    - Atmospheric Pressure: Crushing (rock weight)
    - Ambient Light: Pitch-Black (true darkness)
    - Acoustic Profile: Echoing (massive cavern)
    - Hazards: Miasmic (poisonous atmosphere) or Irradiated

15. **Geothermal Mantle** (DepthLayer 2): Pure magma chambers, crushing pressure, absolute biological void. Only extremophile organisms survive. Liquid lava pools, geothermal vents.
    - Atmospheric Pressure: Crushing (extreme)
    - Ambient Light: Dim (magma glow)
    - Temperature: Thermal (extreme heat)
    - Acoustic Profile: Echoing (cavern resonance)
    - Hazards: Volatile (active magma)

---

## Biome Physics Modifiers

### Atmospheric Pressure
- **Thin** (High peaks): +15% stamina drain, +10% jump height loss
- **Standard** (Sea level, most biomes): Base physics
- **Crushing** (Core layers, water depth): -20% movement speed, +30% stun resistance, gear degradation

### Ambient Light Level
- **Pitch-Black**: Cannot see beyond 2 tiles without light source; creatures lose visual awareness
- **Dim**: 6-tile visibility radius; gloomy atmosphere
- **Radiant**: 15-tile visibility radius; bright daylight

### Acoustic Profile
- **Deadened**: Sound-absorbing terrain; immune to sonic attacks; -50% hearing radius
- **Standard**: Normal audio propagation
- **Echoing**: All sounds amplified and reflected; +20% sonic damage; communication carries far

### Tectonic Activity
- **Stable**: No tremors or hazards
- **Shifting**: Random cave-ins (5% per minute), ground tremors, unstable footing
- **Volcanic**: Active lava flows, explosive geysers, rapid environmental changes

### Hazard Layer
- **Pristine**: No additional hazards
- **Miasmic**: Poisonous gas clouds; takes 2 poison damage per second without protection; reduces visibility
- **Irradiated**: Radioactive particles; takes 1 radiation damage per second; causes mutations
- **Cursed**: Purple arcane contamination; takes 1 curse damage per second; disables magic temporarily

---

## Biome Distribution Parameters

| Parameter | Range | Effect |
|---|---|---|
| Latitude | 0.0 → 1.0 | Controls temperature and polar regions |
| Altitude | 0.0 → 1.0 | Controls elevation and atmospheric pressure |
| Humidity | 0.0 → 1.0 | Controls water availability and moisture-dependent biomes |
| Distance From Water | 0.0 → 1.0 | Controls aquatic vs. terrestrial plant types |
| Depth Layer | 0, 1, 2 | Controls surface/subterranean/mantle biomes |
| Magical Anomaly | Boolean | Spawns arcane mutations and Glowstone minerals |
| Contamination | Boolean | Spawns toxic plants and radioactive minerals |