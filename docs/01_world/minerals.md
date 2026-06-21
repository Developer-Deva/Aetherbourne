# Minerals and Geological Resources System

**Description:** Comprehensive documentation of mineral resources and geological materials in Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

This system manages all mineral deposits, ores, gems, and geological materials that form the foundation of crafting, construction, and magical systems in the game world. Minerals integrate with the global macro drivers (Latitude, Altitude, Humidity, DepthLayer, Magical Anomalies, Contamination) to procedurally generate contextual resources tailored to geological conditions across all 15 biomes. Custom 2D rendering properties enable hex-color palette matching, sprite animation, particle effects, and Y-layer sorting for pixel-perfect 32x32 tile rendering.

## Macro Global Drivers (Planetary Context)

Mineral generation uses the same environmental parameter vectors as flora:

- **Latitude** (0.0 = Equator/Hot → 1.0 = Poles/Cold): Drives thermal mineral generation
- **Altitude** (0.0 = Sea Level → 1.0 = Mountain Peaks): Determines ore richness and metallurgic types
- **Humidity** (0.0 = Arid → 1.0 = Saturated): Influences mineral purity and oxidation state
- **Depth Layer** (0 = Surface, 1 = Subterranean, 2 = Mantle): Dictates geological origin (Sedimentary → Magmatic → Mantle)
- **System Flags** (Boolean): `IsMagicalAnomaly` spawns Glowstone/Gems; `IsContaminated` spawns Toxic/Irradiated variants

## Mineral Properties and Categories

The mineral classification system uses 23 distinct properties to describe and generate unique mineral variations with integrated custom 2D engine rendering hooks. These categories create a comprehensive taxonomy enabling procedural generation of diverse, meaningful mineral types.

## 1. Rarity

* Common
* Uncommon
* Rare
* Epic
* Legendary
* Mythic

## 2. Value

* Worthless
* Junk
* Cheap
* Standard
* Precious
* Priceless
* Relic
* Legendary

## 3. Electrical / Energy Transfer

* Insulative
* Resistant
* Conductive

## 4. Structural Integrity

* Malleable
* Firm
* Durable
* Fractured
* Brittle

## 5. Thermal Spectrum

* Cryo
* Lukewarm
* Thermal

## 6. Light Emission

* Obscure
* Matte
* Luminescent

## 7. Physical Purity

* Impure
* Smelted
* Pure

## 8. Bio-Hazard / Toxicity

* Benign
* Irritating
* Toxic

## 9. Energy Stability

* Volatile
* Stable
* Inert

## 10. Physical Mass

* Sparse
* Compact
* Massive

## 11. Gravitational Weight

* Featherlight
* Standard
* Cumbersome

## 12. Supernatural Affinity

* Magickal
* Latent
* Non-Magickal

## 13. Surface Texture

* Granular
* Marbled
* Vitreous

## 14. Acoustic Resonance

* Dampened
* Muffled
* Resonant

## 15. Chemical Behavior

* Corrosive
* Neutral
* Adhesive

## 16. Magnetic Affinity

* Magnetic
* Deflecting
* Polar-Flipped

## 17. Mineral Class
This dictates the material's basic taxonomy, transitioning from basic construction stone to organic fossils, metals, and precious crystals.

* Stone
* Earthy
* Fossilized
* Ore
* Alloyed
* Glowstone
* Gem
* Shard

## 18. Geological Origin
This outlines the environmental and tectonic forces that created the mineral, moving from surface layers to volcanic heat, high tectonic pressure, cosmic arrivals, or magical anomalies.

* Sedimentary (Water-layered, surface crust)
* Alluvial (River-washed, eroded silt)
* Hydrothermal (Hot, mineral-rich underground springs)
* Volcanic (Cooled lava, tectonic heat)
* Metamorphic (Crushed under extreme subterranean pressure)
* Impactite (Forged from a meteor crash)
* Mantle (Dredged up from the deepest core of the planet)
* Anomalous (Formed by localized tears in reality or magic)

## 19. Matter State (Phase)
What form does the mineral take at room temperature? Splitting this allows for mercury-like liquid metals or cloud-like gaseous ores.

* Gaseous
* Vaporous
* Liquid
* Viscous
* Solid

## 20. Smelting Point (Volatility under Heat)
What happens when a player puts it in a forge? Some metals melt easily; others require cosmic heat or vaporize entirely.

* Volatile (Vaporizes instantly)
* Fusible (Melts at low temperatures like Lead)
* Temperate (Standard forge melting point like Iron)
* Refractory (Requires extreme blast-furnace heat)
* Infusible (Impossible to melt by normal means) [1] 

## 21. Optical Clarity (Transparency)
How does light behave inside the mineral? This is vital if you are rendering shaders for gems or crystals.

* Opaque (Blocks all light)
* Translucent (Blurs light passing through)
* Transparent (Perfect optical clarity)

## 22. Cleavage & Fracture (Breakage Pattern)
How does it shatter when mined or struck? This tells the generator if the drop comes out as clean geometric crystals or jagged shards.

* Hackly (Jagged, sharp, uneven tears)
* Conchoidal (Smooth, shell-like curved breaks like obsidian)
* Perfect (Splits cleanly along flat geometric crystal planes)

## 23. Sensory Feedback (Scent / Taste)

Does the mineral give off a physical warning or clue to the player?

* Fetid (Sulfuric, rotting smell)
* Odorless (No sensory footprint)
* Aromatic (Sweet, metallic, or ozone scent)

---

## Design Philosophy

Principles for mineral variety, procedural geology, and balance across biomes.

## Core Concepts

- Global environmental drivers
- Mineral properties and rarity
- Resource generation and exploitation

---

## Implementation / Notes

* Notes on mineral data encoding, generation logic, and crafting integration.

## Custom 2D Engine Rendering Properties

The procedural generator assigns these custom properties to control 32x32 pixel sprite rendering in the top-down tile engine:

### Palette Hex (Color Tint)

Dominant sprite color expressed as hexadecimal. Examples:
- Volcanic ores: `#d64b27` (oxidized copper red)
- Hydrothermal deposits: `#423254` (deep purple)
- Alluvial sediment: `#4c6055` (earthy green-brown)
- Tundra shards: `#a8d3e6` (ice blue)
- Magical anomaly: `#b15cd9` (arcane purple)

### Sprite Animation

Boolean flag triggering continuous animation loops:
- **true**: Pulsing, flashing, or rotating animation (Glowstone minerals)
- **false**: Static sprite (most ores)

### Particle Emitter Type

Dictates environmental effect particles rendered around the mineral:
- **"None"**: No particle effects
- **"Smoke"**: Grey/white smoke cloud (volcanic, thermal ores)
- **"ArcaneSpark"**: Purple arcane sparkles (magical anomaly minerals)
- **"Spores"**: Green spore particles (contaminated deposits)

### Sorting Layer Order (Y-Sort)

Integer value determining draw order (higher renders on top):
- Ground minerals: Layer 1
- Mid-elevation crystals: Layer 2
- Tall crystal formations: Layer 3-4
- Floating anomalies: Layer 5+

## Data Dictionary
This table maps out specific gameplay stat bonuses for the extreme and unique points across all 23 categories.

| Category / Modifier Word | Stat Bonus / Mechanical Effect |
|---|---|
| 1. Rarity | Base modifier multiplier for all rolled secondary stats. |
| 2. Value | Price multiplier for merchants and trade value. |
| 3. Insulative | +20% Lightning / Energy Resistance |
| 3. Conductive | +15% Lightning Damage / +10% Attack Speed |
| 4. Malleable | -20% Crafting cost / Item requires fewer materials to forge |
| 4. Brittle | +25% Critical Damage / Armor breaks 20% faster when hit |
| 5. Cryo | +15% Frost Damage / Attacks slow enemy movement speed |
| 5. Thermal | +15% Fire Damage / Attacks inflict burning damage over time |
| 6. Obscure | +15% Stealth rating / Decreases enemy aggro range |
| 6. Luminescent | Radiates local light / Extends mini-map vision radius |
| 7. Impure | -10% Base armor or damage value due to heavy structural debris |
| 7. Pure | +20% Weapon Damage / Armor Integrity |
| 8. Benign | Purges 1 physical debuff every 15 seconds / +10% Health regen |
| 8. Toxic | +15% Poison Damage / Inflicts deadly poison sickness on hit |
| 9. Volatile | 5% chance to trigger an explosive shockwave when swung or struck |
| 9. Inert | 100% immune to self-combustion / +25% Knockback Resistance |
| 10. Sparse | Component size is minimized / Weapon weight reduced by 30% |
| 10. Massive | Item scales 1.5x larger / Inventory space requirement increased |
| 11. Featherlight | +15% Jump height and evasion window |
| 11. Cumbersome | -15% Attack and movement speed / +30% Stun Resistance |
| 12. Magickal | +20% Maximum Mana / Spells scale higher |
| 12. Non-Magickal | Completely blocks magical tracking / Weapon cannot be enchanted |
| 13. Granular | +15% Armor Piercing due to rough micro-teeth serrations |
| 13. Vitreous | +12% Spell deflection / Parrying chance |
| 14. Dampened | Completely silences movement noise / Immune to sound attacks |
| 14. Resonant | +20% Sonic/Shockwave damage / Weapon echoes on swing |
| 15. Corrosive | Permanently degrades target's armor defense by 3% per hit |
| 15. Adhesive | Disarm immune / Grappled enemies cannot escape easily |
| 16. Magnetic | Vaccuums and pulls nearby loose loot directly to the player |
| 16. Polar-Flipped | 15% chance to deflect incoming ranged projectiles straight back |
| 17. Mineral Class | Taxonomy hook: Determines if used for smithing, jeweling, or fuel. |
| 18. Geological Origin | Lore & Zone hook: Yields extra drops if mined in native biomes. |
| 19. Matter State | Determines physical item physics (Solid block vs. Liquid flask vs. Gas cloud). |
| 20. Smelting Point | Dictates required furnace tier (Volatile instantly explodes if melted). |
| 21. Optical Clarity | Dictates rendering shader transparency values (Opaque vs. Translucent vs. Transparent). |
| 22. Cleavage & Fracture | Dictates salvage yield (Perfect breaks into 4 flawless items, Hackly yields scraps). |
| 23. Sensory Feedback | Alerts player to invisible hazards (Fetid = Poison trap nearby, Aromatic = Magic source nearby). |

---------------------------
## Procedural Generation System

The procedural naming generator accepts rolled data across all 23 categories, determines which properties are the most extreme anomalies, converts them into grammatically correct word forms, and formats them into a clean naming blueprint:

**Naming Pattern:** [Rarity] + [Origin/State Prefix] + [Property Adjective] + [Base Name/Class] + [Of the Suffix]

### C# Implementation

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class MineralNameGenerator
{
    // Category 1 & 2: Rarity and Value formatting maps
    private static readonly Dictionary<string, string> RarityTitles = new()
    { 
        { "Common", "Crude" },
        { "Uncommon", "Choice" },
        { "Rare", "Exotic" },
        { "Epic", "Exalted" },
        { "Legendary", "Eternal" },
        { "Mythic", "Primordial" }
    };

    private static readonly Dictionary<string, string> ValueTitles = new()
    { VALUE_TITLES = {
    "Worthless": "Dross", "Junk": "Scrap", "Cheap": "Base", "Standard": "", 
    "Precious": "Noble", "Priceless": "Regal", "Relic": "Venerated", "Legendary": "Mythos"
}
        { "Worthless", "Dross" },
        { "Junk", "Scrap" },
        { "Cheap", "Base" },
        { "Standard", "" },
        { "Precious", "Noble" },
        { "Priceless", "Regal" },
        { "Relic", "Venerated" },
        { "Legendary", "Mythos" }
    };

    // The Naming Conversion Matrix for standard physical & magical properties
    private static readonly Dictionary<string, (string adj, string noun)> PropertyWords = new()
    {
        { "Insulative", ("Grounded", "Isolation") },
        { "Conductive", ("Galvanic", "Conduction") },
        { "Malleable", ("Pliant", "Shaping") },
        { "Brittle", ("Fractured", "Shattering") },
        { "Cryo", ("Glacial", "Frost") },
        { "Thermal", ("Searing", "the Forge") },
        { "Obscure", ("Umbral", "Shadows") },
        { "Luminescent", ("Radiant", "Luminance") },
        { "Impure", ("Silty", "Dross") },
        { "Pure", ("Pristine", "Purity") },
        { "Benign", ("Wholesome", "Cleansing") },
        { "Toxic", ("Caustic", "Venom") },
        { "Volatile", ("Unstable", "Combustion") },
        { "Inert", ("Quenched", "Stability") },
        { "Sparse", ("Minute", "Fractions") },
        { "Massive", ("Colossal", "Goliath") },
        { "Featherlight", ("Buoyant", "Levitation") },
        { "Cumbersome", ("Leadened", "the Anvil") },
        { "Magickal", ("Arcane", "Sorcery") },
        { "Non-Magickal", ("Inert", "Nullification") },
        { "Granular", ("Coarse", "Grit") },
        { "Vitreous", ("Glassy", "Reflection") },
        { "Dampened", ("Muffled", "Silence") },
        { "Resonant", ("Echoing", "Vibrations") },
        { "Corrosive", ("Acidic", "Erosion") },
        { "Adhesive", ("Sticky", "Cohesion") },
        { "Magnetic", ("Lodestone", "Attraction") },
        { "Polar-Flipped", ("Veering", "Reversal") },
        { "Opaque", ("Darkened", "Opacity") },
        { "Transparent", ("Crystalline", "Clarity") },
        { "Hackly", ("Jagged", "Splinters") },
        { "Perfect", ("Flawless", "Symmetry") },
        { "Fetid", ("Noxious", "Stench") },
        { "Aromatic", ("Ozone", "Perfume") }
    };

    // Structural Categories 18 & 19 (Geological Origin / Matter State)
    private static readonly Dictionary<string, string> EnvironmentPrefixes = new()
    {
        { "Sedimentary", "Crusted" },
        { "Alluvial", "River" },
        { "Hydrothermal", "Geyser" },
        { "Volcanic", "Magma" },
        { "Metamorphic", "Tectonic" },
        { "Impactite", "Meteor" },
        { "Mantle", "Core" },
        { "Anomalous", "Rift" },
        { "Gaseous", "Aerosol" },
        { "Vaporous", "Misty" },
        { "Liquid", "Fluid" },
        { "Viscous", "Sludgy" }
    };

    /// <summary>
    /// Generates a procedural mineral name based on base material and properties.
    /// </summary>
    /// <param name="baseMaterial">Fictional or real mineral name (e.g., 'Copper', 'Malachite')</param>
    /// <param name="properties">Dictionary of the 23 rolled attributes. 
    /// Numeric properties use a floating scale (0.0 - 1.0).</param>
    /// <returns>A procedurally generated mineral name.</returns>
    public static string GenerateProceduralName(string baseMaterial, Dictionary<string, object> properties)
    {
        // 1. Grab base structural information
        string rarity = properties.ContainsKey("Rarity") ? (string)properties["Rarity"] : "Common";
        string value = properties.ContainsKey("Value") ? (string)properties["Value"] : "Standard";
        string mineralClass = properties.ContainsKey("Mineral Class") ? (string)properties["Mineral Class"] : "Ore";
        string geoOrigin = properties.ContainsKey("Geological Origin") ? (string)properties["Geological Origin"] : "Sedimentary";
        string matterState = properties.ContainsKey("Matter State") ? (string)properties["Matter State"] : "Solid";

        // Final string components
        string rarityWord = RarityTitles.ContainsKey(rarity) ? RarityTitles[rarity] : "";
        string valueWord = ValueTitles.ContainsKey(value) ? ValueTitles[value] : "";
        string envWord = "";
        string adjWord = "";
        string nounSuffix = "";

        // Assemble base compound identifier (e.g., "Volcanic Ore" or "Tectonic Gem")
        string baseName = mineralClass != "Stone" ? $"{baseMaterial} {mineralClass}" : baseMaterial;

        // 2. Extract environmental background modifiers (Origin / State Priority)
        var priorityOrigins = new[] { "Volcanic", "Impactite", "Anomalous", "Mantle" };
        if (priorityOrigins.Contains(geoOrigin))
        {
            envWord = EnvironmentPrefixes.ContainsKey(geoOrigin) ? EnvironmentPrefixes[geoOrigin] : "";
        }
        else
        {
            var priorityStates = new[] { "Gaseous", "Liquid", "Viscous" };
            if (priorityStates.Contains(matterState))
            {
                envWord = EnvironmentPrefixes.ContainsKey(matterState) ? EnvironmentPrefixes[matterState] : "";
            }
        }

        // 3. Prioritize physical property modifiers (Sort by extreme statistical deviation)
        // Filters out baseline properties (scores under 0.75)
        var extremeTraits = new List<(string trait, double score)>();
        foreach (var prop in properties)
        {
            if (PropertyWords.ContainsKey(prop.Key) && prop.Value is double score && score >= 0.75)
            {
                extremeTraits.Add((prop.Key, score));
            }
        }

        // Sort so the highest extreme rolls get naming rights
        extremeTraits = extremeTraits.OrderByDescending(x => x.score).ToList();

        // Rule: Top extreme becomes the main Adjective modifier
        if (extremeTraits.Count >= 1)
        {
            string primaryTrait = extremeTraits[0].trait;
            adjWord = PropertyWords[primaryTrait].adj;
        }

        // Rule: Second highest extreme becomes the descriptive "of the" Suffix
        if (extremeTraits.Count >= 2)
        {
            string secondaryTrait = extremeTraits[1].trait;
            nounSuffix = $"of {PropertyWords[secondaryTrait].noun}";
        }

        // 4. Compile layout cleanly, filtering out unused variables
        var prefixChain = new List<string> { rarityWord, valueWord, envWord, adjWord };
        var cleanedPrefixes = prefixChain.Where(p => !string.IsNullOrEmpty(p)).ToList();

        string finalName = string.Join(" ", cleanedPrefixes) + $" {baseName}";
        if (!string.IsNullOrEmpty(nounSuffix))
        {
            finalName += $" {nounSuffix}";
        }

        // Strip accidental duplicate spaces
        return System.Text.RegularExpressions.Regex.Replace(finalName, @"\s+", " ").Trim();
    }
}
```

### Usage Examples

**Example A:** High-tier volcanic find that is both hot and unstable

```csharp
var result = MineralNameGenerator.GenerateProceduralName("Iron", new()
{
    { "Rarity", "Epic" },
    { "Value", "Standard" },
    { "Mineral Class", "Ore" },
    { "Geological Origin", "Volcanic" },
    { "Matter State", "Solid" },
    { "Thermal", 0.95 },
    { "Volatile", 0.88 },
    { "Magnetic", 0.2 }
});
// Output: Exalted Magma Searing Iron Ore of Combustion
```

**Example B:** A liquid, poisonous anomaly found deep within a spatial rift

```csharp
var result = MineralNameGenerator.GenerateProceduralName("Aetherium", new()
{
    { "Rarity", "Mythic" },
    { "Value", "Priceless" },
    { "Mineral Class", "Gem" },
    { "Geological Origin", "Anomalous" },
    { "Matter State", "Liquid" },
    { "Toxic", 0.99 },
    { "Magickal", 0.91 }
});
// Output: Primordial Regal Rift Caustic Aetherium Gem of Sorcery
```

**Example C:** Standard bottom-tier chunk with baseline statistics

```csharp
var result = MineralNameGenerator.GenerateProceduralName("Tin", new()
{
    { "Rarity", "Common" },
    { "Value", "Worthless" },
    { "Mineral Class", "Ore" },
    { "Geological Origin", "Sedimentary" },
    { "Matter State", "Solid" },
    { "Conductive", 0.1 },
    { "Firm", 0.4 }
});
// Output: Crude Dross Tin Ore
```

## Geological Formation and Mining

### Ore Deposit Types

- **Veins**: Narrow deposits following rock fractures and faults
- **Lodes**: Larger, more concentrated ore bodies
- **Placers**: Secondary deposits formed by erosion and concentration
- **Pegmatites**: Coarse-grained igneous rocks containing rare minerals
- **Skarns**: Contact metamorphic deposits rich in metals and gems

### Mining Mechanics

```csharp
using System;
using System.Collections.Generic;

public class MiningYieldCalculator
{
    /// <summary>
    /// Calculates the yield from mining a mineral deposit based on various factors.
    /// </summary>
    public static double CalculateMiningYield(
        MineralDeposit deposit,
        double minerSkill,
        double toolQuality)
    {
        // Base yield from deposit richness
        double baseYield = deposit.Richness * deposit.Accessibility;

        // Skill modifier (experienced miners extract more)
        // Formula: 1.0 + (skill - 10) * 0.05
        double skillMultiplier = 1.0 + (minerSkill - 10) * 0.05;

        // Tool effectiveness (accounts for tool durability and type)
        double toolMultiplier = GetToolEffectiveness(toolQuality);

        // Environmental factors (weather, location difficulty, etc.)
        double environmentalModifier = CalculateEnvironmentalFactors(deposit.Location);

        // Depletion factor (deposits become less rich over time)
        // Maximum 30% penalty as deposit is exhausted
        double depletionPenalty = 1.0 - (deposit.Extracted / deposit.TotalReserve) * 0.3;

        // Calculate total yield
        double totalYield = baseYield * skillMultiplier * toolMultiplier *
                           environmentalModifier * depletionPenalty;

        return totalYield;
    }

    /// <summary>
    /// Determines tool effectiveness based on quality rating (0.0 - 1.0).
    /// </summary>
    private static double GetToolEffectiveness(double toolQuality)
    {
        // Quality below 0.5 is severely reduced
        if (toolQuality < 0.5)
            return 0.4 + (toolQuality * 0.2);
        
        // Normal scaling from 0.5 quality to 1.0 quality
        // Maps to 0.5 effectiveness to 1.0 effectiveness
        return 0.5 + (toolQuality * 0.5);
    }

    /// <summary>
    /// Calculates environmental modifiers based on deposit location and conditions.
    /// </summary>
    private static double CalculateEnvironmentalFactors(Location location)
    {
        double modifier = 1.0;

        // Depth penalty: deeper deposits are harder to extract from
        modifier *= Math.Max(0.5, 1.0 - (location.Depth / 1000.0) * 0.2);

        // Weather conditions
        if (location.HasStorm)
            modifier *= 0.7; // 30% penalty during storms
        
        if (location.Temperature < -10 || location.Temperature > 40)
            modifier *= 0.85; // 15% penalty in extreme temperatures

        // Accessibility modifier (rough terrain, obstacles)
        modifier *= location.AccessibilityFactor;

        return Math.Max(0.1, modifier); // Minimum 10% yield
    }
}

/// <summary>
/// Represents a mineral deposit in the game world.
/// </summary>
public class MineralDeposit
{
    public string Name { get; set; }
    public double Richness { get; set; } // 0.0 - 1.0
    public double Accessibility { get; set; } // 0.0 - 1.0
    public Location Location { get; set; }
    public double TotalReserve { get; set; }
    public double Extracted { get; set; }

    public double GetDepletionPercentage() => (Extracted / TotalReserve) * 100.0;
}

/// <summary>
/// Represents a location with environmental characteristics.
/// </summary>
public class Location
{
    public string Name { get; set; }
    public double Depth { get; set; } // meters
    public double Temperature { get; set; } // Celsius
    public bool HasStorm { get; set; }
    public double AccessibilityFactor { get; set; } // 0.0 - 1.0
}
```

### Prospecting System

- **Surface Signs**: Visual indicators of underground deposits (discolored rock, mineral veins)
- **Geological Survey**: Systematic exploration and mapping of promising areas
- **Dowsing**: Magical detection of mineral deposits using specialized tools
- **Remote Sensing**: Advanced detection using specialized equipment or spells

## Mineral Processing

### Smelting & Refining

- **Ore Preparation**: Crushing and concentration before processing
- **Smelting**: High-temperature extraction of metals from ores
- **Refining**: Purification and alloy creation processes
- **Alloying**: Combining metals for enhanced properties

### Gem Cutting & Polishing

- **Rough Cutting**: Initial shaping to reveal gem quality
- **Facet Cutting**: Precision cutting to maximize brilliance
- **Polishing**: Surface finishing to enhance clarity and shine
- **Setting**: Mounting gems in jewelry or magical items

### Crystal Attunement

- **Resonance Tuning**: Aligning crystals with specific magical frequencies
- **Energy Charging**: Infusing crystals with magical power
- **Network Formation**: Linking crystals for enhanced effects
- **Stabilization**: Preventing crystal degradation or magical backlash

## Economic Mineral Systems

### Market Value Calculation

```python
def calculate_mineral_value(mineral, quality, quantity, market_conditions):
## Base value per unit
    base_value = mineral.base_market_value

## Quality multiplier
    quality_multipliers = {
        'poor': 0.5,
        'fair': 0.8,
        'good': 1.0,
        'excellent': 1.5,
        'flawless': 2.5
    }
    quality_value = base_value * quality_multipliers[quality]

## Quantity discount (bulk sales are slightly less per unit)
    quantity_discount = min(1.0, 0.95 ** (quantity / 10))

## Market conditions
    supply_demand_modifier = calculate_supply_demand(mineral, market_conditions)

## Rarity bonus
    rarity_bonus = 1.0 + (mineral.rarity_score * 0.1)

    total_value = (quality_value * quantity * quantity_discount *
                   supply_demand_modifier * rarity_bonus)

    return total_value
```

### Trade Networks

- **Mining Guilds**: Organizations controlling mineral extraction and distribution
- **Merchant Caravans**: Transportation of minerals between regions
- **Black Market**: Illegal trade in rare or restricted minerals
- **Inter-Faction Trade**: Diplomatic mineral exchanges between clans

### Resource Scarcity

- **Depletion Mechanics**: Deposits become exhausted over time
- **Conservation Efforts**: Sustainable mining practices and regulations
- **Alternative Sources**: Recycling, deep mining, or magical creation
- **Technological Solutions**: More efficient extraction methods

## Advanced Mineral Features

### Magical Mineral Properties

- **Mana Conduction**: Ability to channel and amplify magical energy
- **Spell Storage**: Capacity to hold prepared spells for later use
- **Elemental Affinity**: Natural alignment with specific magical schools
- **Resonance Effects**: Interactions between different mineral types

### Technological Applications

- **Alloy Development**: Creating new metal combinations for specific purposes
- **Crystal Technology**: Using crystals in mechanical and electrical devices
- **Mineral Composites**: Combining minerals with other materials
- **Synthetic Minerals**: Laboratory-created minerals with unique properties

### Geological Events

- **Mineral Vein Discovery**: Random events revealing new deposits
- **Cave-Ins**: Mining accidents that can create or destroy access
- **Volcanic Activity**: Creation of new mineral deposits through eruptions
- **Earthquakes**: Structural changes affecting existing mines

## Performance Optimization

### Mineral Management

- **Spatial Indexing**: Efficient storage and retrieval of mineral locations
- **Procedural Generation**: Dynamic creation of mineral deposits
- **Caching**: Store calculated mineral properties and values
- **Lazy Loading**: Only load mineral data when needed

### Processing Efficiency

- **Batch Processing**: Handle multiple mineral operations simultaneously
- **Predictive Calculation**: Anticipate future mineral needs and values
- **Memory Pooling**: Reuse mineral data structures
- **Background Updates**: Process mineral changes during idle time

This minerals system creates a rich geological foundation for crafting, magic, and economic systems, with realistic mining mechanics and valuable resources that drive player progression and world-building.