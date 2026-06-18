# Project Dump

## Summary

- Root: `/workspaces/Aetherbourne`
- Files Included: 26
- Max File Size: 5 MB
- Chunk Size: 12,000 chars

---

## Directory Structure

```text
├── docs
│   ├── 01_world
│   │   ├── cosmology.md
│   │   ├── flora.md
│   │   ├── minerals.md
│   │   └── world.md
│   ├── 02_creatures
│   │   ├── actions.md
│   │   ├── creatures.md
│   │   ├── emotions.md
│   │   ├── genetics.md
│   │   ├── memories.md
│   │   ├── needs.md
│   │   ├── personality.md
│   │   ├── relationships.md
│   │   ├── skills.md
│   │   └── stats.md
│   ├── 03_simulation
│   │   ├── events.md
│   │   └── time.md
│   ├── 04_society
│   │   ├── communities.md
│   │   └── culture.md
│   └── 05_content
│       ├── consumables.md
│       ├── equipment.md
│       ├── items.md
│       ├── stations.md
│       ├── tools.md
│       └── weapons.md
├── src
├── files.py
└── README.md
```

---

# FILE: `README.md`

| Metric | Value |
|----------|----------|
| Size | 331 bytes |
| Lines | 3 |
| Tokens | 83 |
| SHA256 | `867b4004dc4a19b22d417a2bee52d4edd0680abac05fb3e1fe64b088ee51d4f3` |

```markdown
# Aetherbourne
Aetherbourne is a 2D top-down pixel-art life sim built around systemic design, procedural generation, and emergent storytelling. Creatures inherit DNA-based physical traits and capabilities across generations, while personalities emerge through experiences, memories, relationships, and interactions with the world.

```

---

# FILE: `docs/01_world/cosmology.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/01_world/flora.md`

| Metric | Value |
|----------|----------|
| Size | 50,532 bytes |
| Lines | 1,229 |
| Tokens | 12,626 |
| SHA256 | `d1be7bd37908fe6074c986d1b14b30931baeaf150de3385cbb6ff939ffba7cf9` |

## Chunk 1/5

```markdown
# Flora and Botanical Systems

**Description:** Comprehensive documentation of flora, plants, vegetation, and botanical resources in Aetherbourne
**Last Updated:** 2025-10-04

---

## Overview

This system manages all plant species, vegetation, herbs, crops, and botanical materials that form the foundation of alchemy, medicine, sustenance, and magical systems in the game world. Flora integrates with the global macro drivers (Latitude, Altitude, Humidity, DepthLayer, Magical Anomalies, Contamination) to procedurally generate contextual plants tailored to environmental conditions across 15 distinct biomes. Custom 2D rendering properties enable pixel-perfect sprite composition using a modular morphology matrix.

---

## Macro Global Drivers (Planetary Context)

All flora generation references these normalized (0.0 to 1.0) environmental parameters:

- **Latitude** (0.0 = Equator/Hot → 1.0 = Poles/Cold): Drives thermal and biome selection
- **Altitude** (0.0 = Sea Level → 1.0 = Mountain Peaks): Dictates atmospheric pressure and growth constraints
- **Humidity** (0.0 = Arid → 1.0 = Saturated): Determines water dependency and plant form
- **Distance From Water** (0.0 = Shoreline → 1.0 = Landlocked): Drives aquatic vs. xerophytic traits
- **Depth Layer** (0 = Surface, 1 = Subterranean, 2 = Mantle): Determines light level and biome type
- **System Flags** (Boolean): `IsMagicalAnomaly`, `IsContaminated` trigger special mutations

---

## Flora Properties and Categories

The botanical classification system uses 35 distinct properties organized into 4 core morphology tracks plus 5 secondary botanical life tracks plus 4 functional categorization tracks. These categories enable procedural generation of contextually appropriate flora with sprite-compositing guidance for custom 2D engines, functional resource mapping, and role-based ecosystem integration.

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

## 3. Growth Rate

* Stagnant (Doesn't grow under normal conditions)
* Slow (Grows over months or seasons)
* Moderate (Standard growth cycle)
* Fast (Rapid growth, weeks to maturity)
* Explosive (Spreads uncontrollably, invasive)

## 4. Yield Abundance

* Sparse (1-2 harvestable items per plant)
* Modest (3-5 items per plant)
* Generous (6-10 items per plant)
* Abundant (11-20 items per plant)
* Massive (20+ items per plant)

## 5. Bloom Season

* Spring
* Summer
* Autumn
* Winter
* Eternal (Always in bloom/harvestable)
* Nocturnal (Only at night)
* Cyclical (Repeats every 3-5 days)

## 6. Toxicity Level

* Benign (Safe to consume/handle)
* Irritating (Minor skin/respiratory irritation)
* Mildly Toxic (Causes sickness if ingested)
* Highly Toxic (Deadly if ingested, requires protection)
* Corrosive (Burns skin on contact)
* Inert (Immune to poison effects)

## 7. Medicinal Potency

* Inert (No medicinal value)
* Mild (Minor healing or buff effects)
* Potent (Significant healing or buff duration)
* Powerful (Major healing or powerful buffs)
* Legendary (Extraordinary effects)
* Antitoxin (Cures poisons and diseases)

## 8. Elemental Affinity

* Neutral
* Thermal (Fire, heat)
* Cryo (Ice, cold)
* Electrical (Lightning, energy)
* Nature (Life, growth)
* Void (Darkness, decay)

## 9. Mana Saturation

* Depleted (Absorbs mana)
* Neutral (Inert to magic)
* Latent (Minimal magical energy)
* Infused (Contains magical energy)
* Saturated (Overflowing with magic)

## 10. Visibility

* Obscure (Camouflaged, hard to spot)
* Camouflaged (Blends with surroundings)
* Normal (Easily visible)
* Distinctive (Stands out visually)
* Luminous (Glows or radiates light)

## 11. Hardiness

* Fragile (Dies with slightest damage)
* Delicate (Easily damaged)
* Sturdy (Resists normal wear)
* Hardy (Survives harsh conditions)
* Indestructible (Nearly impossible to destroy)

## 12. Regeneration

* None (No self-healing)
* Slow (Regenerates over days)
* Moderate (Regenerates over hours)
* Fast (Regenerates over minutes)
* Instant (Regenerates continuously)

## 13. Spread Rate

* Stationary (Doesn't spread)
* Rooted (Spreads through roots over seasons)
* Seeding (Spreads via seeds, slow)
* Viral (Spreads rapidly via spores)
* Parasitic (Overtakes other plants)

## 14. Light Requirements

* Nocturnal (Thrives in darkness)
* Shade (Prefers low light)
* Partial (Tolerates sun and shade)
* Sunlight (Requires direct sunlight)
* Intense (Requires extreme sunlight)

## 15. Water Dependency

* Xerophytic (Thrives in drought)
* Low (Minimal water needed)
* Moderate (Standard water needs)
* High (Requires frequent watering)
* Aquatic (Lives in water)

## 16. Soil Preference

* Acidic (Thrives in acidic soil)
* Neutral (Tolerates all soil types)
* Alkaline (Requires basic/alkaline soil)
* Volcanic (Prefers mineral-rich lava soil)
* Magical (Requires mana-infused soil)

## 17. Pollination Type

* Self-Pollinating (No partner needed)
* Wind-Pollinated (Spreads via air currents)
* Insect-Pollinated (Requires insects)
* Magical (Requires arcane energy)
* Sterile (Cannot reproduce naturally)

## 18. Root System

* Shallow (Roots near surface)
* Fibrous (Spreading surface roots)
* Taproot (Deep single root)
* Massive (Deep, extensive root system)
* Aerial (Roots in air/water)

## 19. Lifespan Classification

* Ephemeral (Days to weeks)
* Annual (Completes cycle in one year)
* Biennial (Two-year life cycle)
* Perennial (Decades-long lifespan)
* Ancient (Centuries or millennia old)

## 20. Aesthetic Value

* Ugly (Repulsive appearance)
* Plain (Unremarkable)
* Normal (Standard appearance)
* Beautiful (Visually appealing)
* Stunning (Exceptionally gorgeous)

## 21. Fragrance Intensity

* Odorless (No scent)
* Subtle (Faint, pleasant scent)
* Aromatic (Noticeable, enjoyable fragrance)
* Potent (Strong, overwhelming fragrance)
* Fetid (Repulsive, sulfuric smell)

## 22. Color Vibrancy

* Drab (Muted, dull colors)
* Muted (Subdued coloration)
* Normal (Standard plant colors)
* Vibrant (Bright, vivid colors)
* Prismatic (Shimmers with multiple colors)

## 23. Symbiotic Relationships

* Solitary (Grows alone)
* Compatible (Can grow near similar plants)
* Synergistic (Enhances nearby plants)
* Parasitic (Damages nearby plants)
* Mycorrhizal (Partners with fungi networks)

## 24. Growth Form (Silhouette/Habit)

The foundational plant silhouette dictating root, stalk, and leaf graphics composition for sprite assembly.

* Thalloid (Ground blankets, lichens, sheet mosses; flat ground coverage)
* Rosette (Circular ground clusters radiating from soil center; compact disc patterns)
* Caulescent (Vertical stems/columns; upright singular or multi-stalk focus)
* Clambering (Terrain-wrapping vines; climbing/trailing growth patterns)
* Arborescent (Tree trunks; full canopy overhead coverage)

## 25. Organ Destination (Anatomy Focus)

Dictates which plant part is harvested and drives yield type.

* Subterranean (Underground storage: potatoes, carrots, root crops; yields tubers/bulbs)
* Culm-Stalk (Stalk wall mass: bamboo, cane, reeds; yields structural stalks)
* Foliar (Leafy focus: cooking herbs, alchemical leaves; yields leaves/foliage)
* Inflorescent (Blooms/seed heads: flowers, wheat ears, grain; yields individual flowers/seeds)
* Fructiferous (Branch fruits/berries: apples, berries, seed pods; yields fruits/nuts)

## 26. Stem Structure (Material Integrity)

Determines plant durability, harvestability, and crafting requirements.

* Herbaceous (Soft, easily snapped; requires minimal effort to harvest)
* Fleshy-Succulent (Water-retaining, zero wood; cactus/mushroom stems)
* Hollow-Cane (Segmented, rigid hollow shells; yields cylindrical sections)
* Suffruticose (Semi-woody base; persistent but partially herbaceous)
* Ligneous (Solid timber core wood; requires axes/tools to harvest)

## 27. Canopy Architecture (Foliage Density)

Dictates visual silhouette and collision radius for 2D pixel rendering.

* Naked (Bare, minimal foliage; zero visual obstruction)
* Tufted (Pom-pom pixel clusters at tips; compact aerial mass)
* Spreading (Wide scattered leaf circumference; dispersed canopy coverage)
* Dense-Canopy (Opaque, shadow-casting foliage; full visual blocking)
* Plume (Feather-like vertical reeds/ferns; feathered aerial display)

## 28. Surface Armor (Outer Layer Protection)

Dictates plant durability and harvesting safety requirements.

* Fleshy (Soft vulnerable exterior; easy to damage)
* Fibrous (Textured stringy exterior; moderate protection)
* Barked (Protective wooden skin; requires cutting tools)
* Thorny (Barbed spines; causes damage to bare hands)
* Chitinous (Hard insect-like shell; nearly impervious)

## 29. Foliage Type (Leaf Morphology)

Dictates visual leaf sprites and interaction patterns.

* Leafless (No visible foliage layer; bare stems/trunks)
* Bladed (Thin sword-like leaves; grass/grain morphology)
* Broadleaf (Large flat leaves; herbaceous coverage)
* Needled (Thin conifer needles; frostbitten appearance)
* Spored (Fungal spore-releasing structures; mycelial patterns)

## 30. Growth Cycle (Seasonal Activity)

Dictates when the plant actively produces harvestable material.

* Ephemeral (Burst blooms; days to weeks active cycle)
* Seasonal (Active during specific seasons only)
* Perennial (Active year-round; continuous growth)
* Decaying (Dead/rotting; produces spoilage materials)

## 31. Reproduction Style (Spread Mechanism)

Dictates how the plant propagates and spreads naturally.

* Rooting (Spreads through root runners and offshoots)
* Seeding (Reproduces via seeds; slow natural spread)
* Spreading (Wind pollen particles; aerial dispersal)
* Sporing (Fungal spore release; rapid dissemination)
* Parasitic (Overtakes other plants; competitive growth)

## 32. Growth Habit

Defines the primary growth pattern and habitat preference of the plant.

* Herbaceous (Non-woody plants with soft stems, often seasonal)
* Woody (Persistent stems or trunks that survive through seasons)
* Climbing (Uses structures or other plants to ascend)
* Creeping (Spreads across the ground or substrate)
* Aquatic (Lives in or on water bodies)
* Epiphytic (Grows on other plants without rooting in soil)
* Subterranean (Main body exists below ground)
* Fungal (Spore-bearing growth habit with mycelium networks)

## 33. Structural Type

Describes the physical architecture and form of the plant structure.

* Single-Stem (One main trunk or stalk)
* Multi-Stem (Several stems or branches from the base)
* Rosette (Leaves arranged in a ground-hugging circle)
* Vining (Flexible, trailing, or twining growth)
* Canopy (Expansive branches forming overhead cover)
* Bulbous (Forms bulbs, corms, or tubers as storage organs)
* Mat-Forming (Dense carpet of foliage or mossy cover)
* Spore Cluster (Mushroom caps, puffballs, or fungal tufts)

## 34. Harvest Output

Specifies the primary harvestable part or product of the plant.

* Leaves (Harvested foliage for teas, salves, and seasoning)
* Flowers (Petals and blooms for potions, perfumes, and rituals)
* Fruit (Edible or alchemical fruiting bodies)
* Seeds (Reproductive kernels used for planting, oil, or spice)
* Bark (Protective outer layers harvested for dyes, medicine, or woodcraft)
* Wood (Timber and branches for construction, tools, or firewood)
* Resin (Sticky exudate used for adhesives, incense, and enchantments)
* Sap (Liquid extracts for potions, sweets, or alchemical reagents)
* Roots/Tubers (Underground storage organs used for food, poultices, or powders)
* Spores (Reproductive dust used for fungi cultivation and mystical effects)
* Nectar (Sweet fluid used in brews, offerings, or magical attractors)
* Fiber (Strong strands used for rope, cloth, and basketry)

## 35. Resource Role

Dictates the primary functional purpose and utility category of the plant.

* Culinary (Used primarily as food, drink, or cooking ingredients)
* Medicinal (Used for healing, cures, and restorative brews)
* Alchemical (Used as potio
```

## Chunk 2/5

```markdown
n, enchantment, or spellcraft components)
* Construction (Used for building, crafting, or structural materials)
* Textile (Used for fabric, rope, weaving, and soft goods)
* Fuel (Used for fire, steam, or energy production)
* Trade (High-value goods intended for merchants and barter)
* Ritual (Used for ceremonies, offerings, and magical rites)
* Environmental (Used to shape ecosystems, terrain, or weather)
* Utility (Used for traps, tools, dyes, preservatives, or household goods)

---

## Data Dictionary

This table maps out specific gameplay stat bonuses for the extreme and unique points across all flora trait categories.

| Category / Modifier Word | Stat Bonus / Mechanical Effect |
|---|---|
| 1. Rarity | Base modifier multiplier for all rolled secondary stats. |
| 2. Value | Price multiplier for merchants and trade value. |
| 3. Slow | +15% potion brewing time for more control / -5% ingredient cost |
| 3. Explosive | Uncontrolled spread provides free resources but may destroy garden |
| 4. Sparse | +10% purity in crafting / Less waste but fewer items |
| 4. Massive | +30% total yield / Can sustain more consistent supply chains |
| 5. Eternal | Always harvestable / Never depletes, infinite resource |
| 5. Nocturnal | +25% potency at night / Harvesting at night grants bonus duration |
| 6. Benign | +10% health recovery / Safe for untrained herbalists |
| 6. Corrosive | +20% armor degradation / Must wear protection when harvesting |
| 7. Antitoxin | Instantly cures 1 poison effect / Purges debuffs on consumption |
| 7. Inert | Immune to status effects / Cannot be enhanced by alchemy |
| 8. Thermal | +15% fire damage / Attacks inflict burning, potions add warmth |
| 8. Cryo | +15% frost damage / Attacks slow movement, potions chill enemies |
| 8. Nature | +20% healing effectiveness / Restores mana over time |
| 9. Saturated | +25% spell potency / Magical effects are amplified by 25% |
| 9. Depleted | -20% mana cost for spells / Can be used to nullify magic |
| 10. Luminous | Extends vision radius / Provides light source when placed |
| 10. Obscure | +15% stealth rating / Decreases enemy detection range |
| 11. Indestructible | Infinite harvests / Plant never dies or depletes |
| 11. Fragile | Reduced durability / Breaking yields 50% resources |
| 12. Instant | Continuous regeneration / Heals 5 HP per tick automatically |
| 12. None | Single-use only / Must be replanted after each harvest |
| 13. Viral | Spreads uncontrollably / Free resources but invasive |
| 13. Stationary | +5% yield bonus / Can be reliably farmed in one location |
| 14. Nocturnal | +25% effectiveness at night / Potency shifts with day/night cycle |
| 14. Intense | Requires specialized greenhouse / +30% yield with proper setup |
| 15. Aquatic | Can be farmed in water / Opens underwater harvesting routes |
| 15. Xerophytic | Thrives in deserts / No watering needed |
| 16. Magical | Requires mana infusion to grow / +50% stat bonuses if grown magically |
| 16. Volcanic | Thrives near lava/heat sources / Automatically enhanced by environment |
| 17. Sterile | Cannot spread naturally / Rare and valuable, requires seeds |
| 17. Self-Pollinating | Requires no tending / Autonomously produces offspring |
| 18. Aerial | Can be grown in air/clouds / Unlocks sky gardens |
| 18. Massive | Deep roots anchor the plant / Cannot be blown away by wind |
| 19. Ancient | Centuries-long lifespan / Grows stronger with age, exponential value |
| 19. Ephemeral | Rapid cycle / Harvests daily but with minimal yield |
| 20. Stunning | +15% sell price / NPCs prefer purchasing beautiful plants |
| 20. Ugly | -15% sell price / Harder to trade, but alchemically identical |
| 21. Potent | Aroma grants +5% buff when nearby / Scent provides passive benefits |
| 21. Fetid | Repels weak enemies / Creatures avoid this plant automatically |
| 22. Prismatic | +20% magical effectiveness / Potions glow and attract attention |
| 22. Drab | -10% aesthetic value but easier to hide / Can be planted unnoticed |
| 23. Mycorrhizal | +50% yield from nearby plants / Creates network effects in gardens |
| 23. Parasitic | -30% health for nearby plants / Can be used as competitive tool |
| 24. Thalloid | Ground-level rendering / Zero collision radius, flat tile placement |
| 24. Rosette | Radial sprite composition / Compact collision box, disk-shaped |
| 24. Caulescent | Vertical stalk rendering / Standard collision radius, upright silhouette |
| 24. Clambering | Vining overlay sprite / Wraps terrain, expands collision bounds |
| 24. Arborescent | Full canopy tree sprite / Large collision radius, shadow-casting |
| 25. Subterranean | Yields tubers/bulbs / Harvested by digging; hidden underground |
| 25. Culm-Stalk | Yields structural stalks / Harvested by cutting; cylindrical segments |
| 25. Foliar | Yields leaves/foliage / Harvested by hand-picking; regrows quickly |
| 25. Inflorescent | Yields flowers/seeds / Harvested by threshing; seasonal availability |
| 25. Fructiferous | Yields fruits/nuts / Harvested by hand-picking; branch-based yields |
| 26. Herbaceous | Fast regrowth cycle / Ideal for herbalism and low-maintenance |
| 26. Fleshy-Succulent | High water content / Resists frost; vulnerable to drying |
| 26. Hollow-Cane | Minimal material cost / Harvests as complete segments |
| 26. Suffruticose | Balanced durability / Persists through seasons |
| 26. Ligneous | High material value / Requires specialized harvesting tools |
| 27. Fleshy | Easy to harvest / Vulnerable to damage |
| 27. Fibrous | Moderate protection / Standard harvesting difficulty |
| 27. Barked | Protected exterior / Requires cutting implements |
| 27. Thorny | Hazardous to harvest / Causes damage; requires protective gear |
| 27. Chitinous | Nearly impervious / Requires specialized tools; rare harvests |
| 28. Leafless | Bare sprite rendering / No foliage visual layer |
| 28. Bladed | Grass-like sprites / Thin blade morphology |
| 28. Broadleaf | Dense leaf coverage / Large flat leaflet sprites |
| 28. Needled | Conifer needle sprites / Frostbitten appearance |
| 28. Spored | Fungal fruiting bodies / Spore-releasing animation |
| 29. Ephemeral | Burst blooms / Days to weeks active window |
| 29. Seasonal | Season-locked growth / Active in specific biome seasons only |
| 29. Perennial | Year-round availability / Continuous harvestable state |
| 29. Decaying | Spoilage materials / Dead/rotting yields toxins/compost |
| 30. Rooting | Root-based spread / +50% yield from nearby plants |
| 30. Seeding | Seed dispersal / Slow natural spread, establishes new plants |
| 30. Spreading | Wind pollination / +25% potency when flowers are active |
| 30. Sporing | Fungal spores / Rapid dissemination in wet biomes |
| 30. Parasitic | Overtakes neighbors / -30% health for nearby plants |
| 31. Thorny | +15% armor piercing damage / Causes bleed on contact |
| 31. Medicinal | +20% healing effectiveness / Restores mana over time |
| 31. Toxic | +15% poison damage / Inflicts sickness on consumption |
| 31. Magickal | +25% spell potency / Amplifies magical effects by 25% |
| 32. Herbaceous | Fast seasonal regrowth / Ideal for herbalism and low-maintenance cultivation |
| 32. Woody | Durable, long-lived growth / Supports timber, fruits, and structural use |
| 32. Climbing | Grows upward on support / Useful for vertical gardens and canopy access |
| 32. Creeping | Spreads low to the ground / Excellent for groundcover and trap plants |
| 32. Aquatic | Harvestable in water / Unlocks pond, swamp, and shoreline resources |
| 32. Epiphytic | Grows on other plants / Ideal for canopy and aerial cultivation |
| 32. Subterranean | Stores reserves underground / Harvested for roots, tubers, or fungi bodies |
| 32. Fungal | Spore-based growth / Used for exotic reagents and decay ecosystems |
| 33. Single-Stem | Focused central growth / Supports trunks, stalks, and tall harvests |
| 33. Multi-Stem | Multiple shoots / Good for berries, shrubs, and bushy harvests |
| 33. Rosette | Low, radial leaf arrangement / Efficient ground-level resource collection |
| 33. Vining | Flexible trailing form / Produces fruit, fiber, and climbing cover |
| 33. Canopy | Spread branches overhead / Provides shade, fruit, and timber |
| 33. Bulbous | Underground storage organs / Useful for food and powerful root medicines |
| 33. Mat-Forming | Dense surface coverage / Great for moss, ground herbs, and insulation |
| 33. Spore Cluster | Fungal fruiting bodies / Harvested for spores, potions, and ritual components |
| 34. Leaves | Primary ingredient for teas, salves, and herbal infusions |
| 34. Flowers | Petals and blossoms used for perfume, rituals, and potion catalysts |
| 34. Fruit | Edible harvest with culinary and alchemical uses |
| 34. Seeds | Reproductive units used for planting, oils, spices, and powders |
| 34. Bark | Durable material for dyes, medicine, and craftwork |
| 34. Wood | Structural material for construction, tools, and fuel |
| 34. Resin | Sticky exudate used for incense, adhesives, and enchantments |
| 34. Sap | Liquid extract used in brews, sweets, and alchemical reagents |
| 34. Roots/Tubers | Groundfood and extracts used for nourishment and medicine |
| 34. Spores | Reproduction and mystical reagents used for fungi systems |
| 34. Nectar | Sweet fluid used in brews, offerings, and attraction effects |
| 34. Fiber | Strong strands used for rope, cloth, and basketry |
| 35. Culinary | Boosts food quality / Increases hunger restoration and morale |
| 35. Medicinal | Boosts healing potency / Enables cures, tonics, and status recovery |
| 35. Alchemical | Boosts potion strength / Serves as rare reagent for spells and enchantments |
| 35. Construction | Boosts building durability / Used in structures, scaffolding, and tools |
| 35. Textile | Boosts cloth quality / Used for clothing, rope, and soft goods |
| 35. Fuel | Reduces burn time / Provides energy for fires, steam, and rituals |
| 35. Trade | Boosts market price / Valuable for merchants, guilds, and black markets |
| 35. Ritual | Boosts ritual potency / Used in ceremonies, wards, and offerings |
| 35. Environmental | Supports ecosystem effects / Affects terrain, weather, or biomes |
| 35. Utility | Useful for tools, dyes, traps, and everyday crafting |

---

## Procedural Generation System

The procedural naming generator accepts rolled data across all 35 categories, determines which properties are the most extreme anomalies, converts them into grammatically correct word forms, and formats them into a clean naming blueprint:

**Naming Pattern:** [Rarity] + [Biome/Season Prefix] + [Property Adjective] + [Base Name/Species] + [Of the Suffix]

### C# Implementation

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class FloraNameGenerator
{
    // Category 1 & 2: Rarity and Value formatting maps
    private static readonly Dictionary<string, string> RarityTitles = new()
    {
        { "Common", "Humble" },
        { "Uncommon", "Blessed" },
        { "Rare", "Exotic" },
        { "Epic", "Arcane" },
        { "Legendary", "Eternal" },
        { "Mythic", "Primordial" }
    };

    private static readonly Dictionary<string, string> ValueTitles = new()
    {
        { "Worthless", "Wilted" },
        { "Junk", "Withered" },
        { "Cheap", "Common" },
        { "Standard", "" },
        { "Precious", "Noble" },
        { "Priceless", "Regal" },
        { "Relic", "Venerated" },
        { "Legendary", "Mythos" }
    };

    // The Naming Conversion Matrix for all 35 flora categories (supporting categories 1-35)
    private static readonly Dictionary<string, (string adj, string noun)> PropertyWords = new()
    {
        // Categories 6-23: Environmental & morphological properties
        { "Benign", ("Wholesome", "Healing") },
        { "Corrosive", ("Acidic", "Erosion") },
        { "Antitoxin", ("Purifying", "Antidotes") },
        { "Inert", ("Inert", "Void") },
        { "Thermal", ("Searing", "Flame") },
        { "Cryo", ("
```

## Chunk 3/5

```markdown
Glacial", "Frost") },
        { "Electrical", ("Galvanic", "Lightning") },
        { "Nature", ("Verdant", "Renewal") },
        { "Void", ("Umbral", "Darkness") },
        { "Saturated", ("Arcane", "Sorcery") },
        { "Depleted", ("Inert", "Nullification") },
        { "Luminous", ("Radiant", "Light") },
        { "Obscure", ("Hidden", "Shadows") },
        { "Indestructible", ("Eternal", "Permanence") },
        { "Fragile", ("Delicate", "Frailty") },
        { "Instant", ("Swift", "Regeneration") },
        { "None", ("Static", "Stagnation") },
        { "Viral", ("Invasive", "Contagion") },
        { "Stationary", ("Rooted", "Grounding") },
        { "Nocturnal", ("Moonlit", "Night") },
        { "Intense", ("Brilliant", "Radiance") },
        { "Aquatic", ("Fluid", "Waters") },
        { "Xerophytic", ("Desert", "Drought") },
        { "Magical", ("Arcane", "Enchantment") },
        { "Volcanic", ("Magma", "Geothermal") },
        { "Sterile", ("Barren", "Silence") },
        { "Self-Pollinating", ("Autonomous", "Propagation") },
        { "Aerial", ("Skyborne", "Ether") },
        { "Massive", ("Colossal", "Abundance") },
        { "Ancient", ("Primeval", "Ages") },
        { "Ephemeral", ("Transient", "Brevity") },
        { "Stunning", ("Radiant", "Beauty") },
        { "Ugly", ("Twisted", "Blight") },
        { "Potent", ("Aromatic", "Perfume") },
        { "Fetid", ("Noxious", "Stench") },
        { "Prismatic", ("Iridescent", "Spectrum") },
        { "Drab", ("Muted", "Obscurity") },
        { "Mycorrhizal", ("Connected", "Symbiosis") },
        { "Parasitic", ("Consuming", "Predation") },
        { "Slow", ("Sluggish", "Time") },
        { "Explosive", ("Rampant", "Chaos") },
        { "Sparse", ("Meager", "Scarcity") },
        { "Abundant", ("Generous", "Bounty") },
        { "Vibrant", ("Vivid", "Vitality") },
        
        // Categories 24-27: Morphology Matrix tracks
        { "Thalloid", ("Thalloidal", "Groundcover") },
        { "Rosette", ("Radial", "Rosettes") },
        { "Caulescent", ("Stalked", "Verticality") },
        { "Clambering", ("Vining", "Ascension") },
        { "Arborescent", ("Arboreal", "Canopy") },
        { "Subterranean", ("Tuberous", "Underworld") },
        { "Culm-Stalk", ("Stalky", "Canes") },
        { "Foliar", ("Leafy", "Foliage") },
        { "Inflorescent", ("Floral", "Blooms") },
        { "Fructiferous", ("Fruited", "Abundance") },
        { "Herbaceous", ("Succulent", "Softness") },
        { "Fleshy-Succulent", ("Plump", "Juiciness") },
        { "Hollow-Cane", ("Tubular", "Segmentation") },
        { "Suffruticose", ("Semi-Woody", "Persistence") },
        { "Ligneous", ("Woody", "Timber") },
        { "Naked", ("Bare", "Exposure") },
        { "Tufted", ("Pom-Pom", "Clustering") },
        { "Spreading", ("Dispersed", "Coverage") },
        { "Dense-Canopy", ("Opaque", "Shadow") },
        { "Plume", ("Feathered", "Plumage") },
        
        // Categories 28-31: Secondary botanical traits
        { "Fleshy", ("Vulnerable", "Softness") },
        { "Fibrous", ("Stringy", "Texture") },
        { "Barked", ("Protected", "Bark") },
        { "Thorny", ("Spined", "Danger") },
        { "Chitinous", ("Armored", "Chitin") },
        { "Leafless", ("Bare", "Starkness") },
        { "Bladed", ("Slender", "Blades") },
        { "Broadleaf", ("Wide-Leafed", "Expanse") },
        { "Needled", ("Coniferous", "Needles") },
        { "Spored", ("Fungal", "Spores") },
        { "Seasonal", ("Cyclical", "Seasons") },
        { "Perennial", ("Eternal", "Continuity") },
        { "Decaying", ("Rotting", "Decomposition") },
        { "Rooting", ("Spreading", "Runners") },
        { "Seeding", ("Generative", "Seeds") },
        { "Spreading", ("Dispersive", "Dissemination") },
        { "Sporing", ("Mycelial", "Spore-Cast") },
        
        // Categories 32-35: Functional categorization tracks
        { "Herbaceous-Habit", ("Seasonal", "Herbage") },
        { "Woody-Habit", ("Durable", "Longevity") },
        { "Climbing-Habit", ("Ascending", "Heights") },
        { "Creeping-Habit", ("Sprawling", "Ground") },
        { "Epiphytic-Habit", ("Aerial", "Branches") },
        { "Fungal-Habit", ("Mycelial", "Fungi") },
        { "Single-Stem", ("Singular", "Stalks") },
        { "Multi-Stem", ("Branched", "Profusion") },
        { "Vining-Struct", ("Flexible", "Twining") },
        { "Canopy-Struct", ("Expansive", "Overhead") },
        { "Bulbous-Struct", ("Tuberous", "Storage") },
        { "Mat-Forming", ("Carpeted", "Density") },
        { "Spore-Cluster", ("Fungal-Body", "Fruiting") },
        { "Leaves-Output", ("Leafy", "Foliage") },
        { "Flowers-Output", ("Floral", "Petals") },
        { "Fruit-Output", ("Fructose", "Berries") },
        { "Seeds-Output", ("Seeded", "Kernels") },
        { "Bark-Output", ("Barked", "Layers") },
        { "Wood-Output", ("Timber", "Lumber") },
        { "Resin-Output", ("Resinous", "Exudate") },
        { "Sap-Output", ("Liquid", "Flow") },
        { "Roots-Output", ("Tuberous", "Tubers") },
        { "Nectar-Output", ("Sweet", "Nectar") },
        { "Fiber-Output", ("Stringy", "Fibers") },
        { "Culinary-Role", ("Edible", "Sustenance") },
        { "Medicinal-Role", ("Healing", "Wellness") },
        { "Alchemical-Role", ("Arcane", "Reagents") },
        { "Construction-Role", ("Structural", "Building") },
        { "Textile-Role", ("Woven", "Fabric") },
        { "Fuel-Role", ("Combustible", "Energy") },
        { "Trade-Role", ("Valuable", "Commerce") },
        { "Ritual-Role", ("Sacred", "Ceremony") },
        { "Environmental-Role", ("Ecological", "Balance") },
        { "Utility-Role", ("Practical", "Tools") }
    };

    // Biome and Season Prefixes
    private static readonly Dictionary<string, string> BiomePrefixes = new()
    {
        { "Spring", "Vernal" },
        { "Summer", "Estival" },
        { "Autumn", "Autumnal" },
        { "Winter", "Hibernal" },
        { "Eternal", "Timeless" },
        { "Nocturnal", "Lunar" },
        { "Forest", "Sylvan" },
        { "Mountain", "Alpine" },
        { "Plains", "Pastoral" },
        { "Swamp", "Boggy" },
        { "Desert", "Arid" },
        { "Underwater", "Aqueous" }
    };

    /// <summary>
    /// Generates a procedural flora name based on base species and properties.
    /// Supports all 35 flora categories: 1-23 base properties, 24-27 morphology matrix, 28-31 secondary traits, 32-35 functional categorization.
    /// </summary>
    /// <param name="baseSpecies">Plant species name (e.g., 'Rose', 'Moonflower', 'Thornwood')</param>
    /// <param name="properties">Dictionary of the 35 rolled attributes.
    /// Numeric properties use a floating scale (0.0 - 1.0). String properties are category values.</param>
    /// <returns>A procedurally generated flora name.</returns>
    public static string GenerateProceduralName(string baseSpecies, Dictionary<string, object> properties)
    {
        // 1. Grab base structural information
        string rarity = properties.ContainsKey("Rarity") ? (string)properties["Rarity"] : "Common";
        string value = properties.ContainsKey("Value") ? (string)properties["Value"] : "Standard";
        string bloomSeason = properties.ContainsKey("Bloom Season") ? (string)properties["Bloom Season"] : "Eternal";
        string biome = properties.ContainsKey("Biome") ? (string)properties["Biome"] : "Forest";

        // Final string components
        string rarityWord = RarityTitles.ContainsKey(rarity) ? RarityTitles[rarity] : "";
        string valueWord = ValueTitles.ContainsKey(value) ? ValueTitles[value] : "";
        string biomeWord = "";
        string adjWord = "";
        string nounSuffix = "";

        // Assemble base species identifier
        string baseName = baseSpecies;

        // 2. Extract biome/season background modifiers
        if (BiomePrefixes.ContainsKey(bloomSeason))
        {
            biomeWord = BiomePrefixes[bloomSeason];
        }
        else if (BiomePrefixes.ContainsKey(biome))
        {
            biomeWord = BiomePrefixes[biome];
        }

        // 3. Prioritize physical property modifiers (Sort by extreme statistical deviation)
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

        // 4. Compile layout cleanly
        var prefixChain = new List<string> { rarityWord, valueWord, biomeWord, adjWord };
        var cleanedPrefixes = prefixChain.Where(p => !string.IsNullOrEmpty(p)).ToList();

        string finalName = string.Join(" ", cleanedPrefixes) + $" {baseName}";
        if (!string.IsNullOrEmpty(nounSuffix))
        {
            finalName += $" {nounSuffix}";
        }

        // Strip duplicate spaces
        return System.Text.RegularExpressions.Regex.Replace(finalName, @"\s+", " ").Trim();
    }
}
```

### Usage Examples

**Example A:** Rare spring flower with antitoxin properties

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Bloodmoss", new()
{
    { "Rarity", "Rare" },
    { "Value", "Precious" },
    { "Bloom Season", "Spring" },
    { "Biome", "Forest" },
    { "Antitoxin", 0.92 },
    { "Medicinal Potency", 0.88 }
});
// Output: Blessed Vernal Purifying Bloodmoss of Antidotes
```

**Example B:** Mythic void-aligned parasitic plant

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Voidthorn", new()
{
    { "Rarity", "Mythic" },
    { "Value", "Priceless" },
    { "Bloom Season", "Nocturnal" },
    { "Biome", "Swamp" },
    { "Elemental Affinity", "Void" },
    { "Symbiotic Relationships", "Parasitic" }
});
// Output: Primordial Regal Lunar Umbral Voidthorn of Predation
```

**Example C:** Common humble herb with medicinal properties

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Sage", new()
{
    { "Rarity", "Common" },
    { "Value", "Cheap" },
    { "Bloom Season", "Summer" },
    { "Biome", "Plains" },
    { "Medicinal Potency", 0.65 },
    { "Fragrance Intensity", 0.5 }
});
// Output: Humble Common Sage
```

**Example D:** Epic climbing woody plant with high-value timber output for construction

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Ironvine", new()
{
    { "Rarity", "Epic" },
    { "Value", "Precious" },
    { "Bloom Season", "Eternal" },
    { "Biome", "Forest" },
    { "Growth Habit", "Climbing-Habit", 0.88 },  // Category 32
    { "Structural Type", "Canopy-Struct", 0.85 }, // Category 33
    { "Harvest Output", "Wood-Output", 0.92 },    // Category 34
    { "Resource Role", "Construction-Role", 0.89 } // Category 35
});
// Output: Arcane Eternal Ascending Ironvine of Building
```

**Example E:** Legendary fungal subterranean plant with spore cluster anatomy and alchemical utility

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Luminagaric", new()
{
    { "Rarity", "Legendary" },
    { "Value", "Relic" },
    { "Bloom Season", "Eternal" },
    { "Biome", "Caverns" },
    { "Luminous", 0.95 },
    { "Mana Saturation", "Saturated", 0.91 },
    { "Growth Habit", "Fungal-Habit", 0.99 },     // Category 32
    { "Structural Ty
```

## Chunk 4/5

```markdown
pe", "Spore-Cluster", 0.97 }, // Category 33
    { "Harvest Output", "Spores-Output", 0.94 },  // Category 34
    { "Resource Role", "Alchemical-Role", 0.96 }  // Category 35
});
// Output: Eternal Venerated Arcane Luminagaric of Reagents
```

---

## Botanical Classification and Harvesting

### Plant Family Types

- **Herbs**: Small plants used for medicine, cooking, and alchemy
- **Flowers**: Ornamental and functional plants with blossoms
- **Crops**: Cultivated plants for food and sustenance
- **Trees**: Large woody plants providing timber and fruits
- **Shrubs**: Medium-sized woody plants with multiple stems
- **Vines**: Climbing or trailing plants that spread along surfaces
- **Fungi**: Non-photosynthetic organisms including mushrooms and molds
- **Algae**: Aquatic plant-like organisms for water-based harvesting

### Harvesting Methods

- **Hand-Picking**: Manual collection of fruits, flowers, or leaves
- **Cutting**: Slicing stems and branches with tools
- **Digging**: Excavating root systems and bulbs
- **Scraping**: Collecting bark, lichen, or fungal growths
- **Milking**: Extracting plant fluids and saps
- **Threshing**: Separating seeds from plant matter
- **Spore Collection**: Gathering reproductive spores from fungi
- **Pressing**: Extracting oils and essences from plants

### Growth Mechanics

```csharp
using System;

public class PlantGrowthCalculator
{
    /// <summary>
    /// Calculates the growth progress of a plant.
    /// </summary>
    public static double CalculateGrowthProgress(
        Flora plant,
        double elapsedDays,
        EnvironmentalConditions conditions)
    {
        // Base growth rate from plant species
        double baseGrowthRate = plant.GrowthRateModifier;

        // Environmental modifiers
        double lightModifier = CalculateLightModifier(plant.LightRequirements, conditions.LightLevel);
        double waterModifier = CalculateWaterModifier(plant.WaterDependency, conditions.Moisture);
        double temperatureModifier = CalculateTemperatureModifier(plant.PreferredTemperature, conditions.CurrentTemperature);
        double soilModifier = CalculateSoilModifier(plant.SoilPreference, conditions.SoilComposition);

        // Seasonal adjustments
        double seasonalModifier = GetSeasonalModifier(plant.BloomSeason, conditions.CurrentSeason);

        // Combined growth calculation
        double totalGrowthRate = baseGrowthRate * lightModifier * waterModifier *
                                temperatureModifier * soilModifier * seasonalModifier;

        // Progress toward maturity (0.0 to 1.0)
        double growthProgress = Math.Min(1.0, (elapsedDays * totalGrowthRate) / plant.MaturityDays);

        return growthProgress;
    }

    private static double CalculateLightModifier(string requirement, double lightLevel)
    {
        return requirement switch
        {
            "Nocturnal" => 1.0 - (lightLevel * 0.5), // Prefers darkness
            "Shade" => Math.Max(0.2, 1.0 - (lightLevel * 0.3)),
            "Partial" => 1.0, // Optimal at moderate light
            "Sunlight" => Math.Min(1.2, lightLevel),
            "Intense" => Math.Min(1.5, lightLevel * 1.3),
            _ => 1.0
        };
    }

    private static double CalculateWaterModifier(string dependency, double moisture)
    {
        return dependency switch
        {
            "Xerophytic" => 1.0 - (moisture * 0.4), // Prefers dry
            "Low" => Math.Max(0.6, 1.0 - (moisture * 0.2)),
            "Moderate" => moisture >= 0.4 && moisture <= 0.7 ? 1.0 : 0.8,
            "High" => moisture >= 0.6 && moisture <= 0.9 ? 1.0 : 0.7,
            "Aquatic" => moisture > 0.8 ? 1.2 : 0.3,
            _ => 1.0
        };
    }

    private static double CalculateTemperatureModifier(double preferredTemp, double currentTemp)
    {
        double difference = Math.Abs(preferredTemp - currentTemp);
        
        if (difference < 5)
            return 1.0; // Optimal temperature
        
        if (difference < 15)
            return 0.8; // Acceptable range
        
        if (difference < 25)
            return 0.5; // Difficult conditions
        
        return 0.1; // Nearly impossible conditions
    }

    private static double CalculateSoilModifier(string preference, string soilType)
    {
        // Exact match is optimal
        if (preference == soilType)
            return 1.0;

        // Compatible soils work at reduced efficiency
        return soilType switch
        {
            "Neutral" => 0.9, // Works with most plants
            _ => 0.6 // Suboptimal conditions
        };
    }

    private static double GetSeasonalModifier(string bloomSeason, string currentSeason)
    {
        // Exact bloom season match
        if (bloomSeason == currentSeason)
            return 1.2; // Boost during bloom season

        // Off-season penalties
        if (bloomSeason == "Eternal")
            return 1.0; // No seasonal effect

        return 0.7; // Reduced growth out of season
    }
}

/// <summary>
/// Represents a flora specimen with growth and harvest properties.
/// </summary>
public class Flora
{
    public string Name { get; set; }
    public string Species { get; set; }
    public double GrowthRateModifier { get; set; } // 0.0 - 1.0
    public double MaturityDays { get; set; }
    public string LightRequirements { get; set; }
    public string WaterDependency { get; set; }
    public double PreferredTemperature { get; set; } // Celsius
    public string SoilPreference { get; set; }
    public string BloomSeason { get; set; }
    public int YieldPerHarvest { get; set; }
    public double HarvestQuality { get; set; }
}

/// <summary>
/// Represents environmental conditions affecting plant growth.
/// </summary>
public class EnvironmentalConditions
{
    public double LightLevel { get; set; } // 0.0 - 1.0
    public double Moisture { get; set; } // 0.0 - 1.0
    public double CurrentTemperature { get; set; } // Celsius
    public string SoilComposition { get; set; }
    public string CurrentSeason { get; set; }
}
```

---

## Processing and Refinement

### Herbalism and Preparation

- **Drying**: Removing moisture to preserve herbs for later use
- **Infusion**: Steeping plants in liquid to extract properties
- **Decoction**: Boiling plant matter to concentrate active compounds
- **Tincture Creation**: Extracting plant essence in alcohol solution
- **Powdering**: Grinding dried plants into fine powder

### Alchemy and Potion Crafting

- **Ingredient Combination**: Mixing flora with minerals for synergistic effects
- **Fermentation**: Using flora to create alcoholic beverages with special properties
- **Extract Production**: Concentrating plant essences into potent extracts
- **Oil Infusion**: Creating oils imbued with plant properties
- **Essence Distillation**: Separating pure magical essence from plant matter

### Cultivation and Gardening

- **Soil Preparation**: Creating optimal growing conditions
- **Seed Starting**: Germinating seeds in controlled environments
- **Transplanting**: Moving seedlings to permanent growing locations
- **Companion Planting**: Growing compatible plants together for enhanced yields
- **Pest Management**: Protecting plants from disease and harmful creatures

---

## Economic Flora Systems

### Harvest Value Calculation

```csharp
using System;
using System.Collections.Generic;

public class FloraValueCalculator
{
    private static readonly Dictionary<string, double> QualityMultipliers = new()
    {
        { "Withered", 0.3 },
        { "Poor", 0.5 },
        { "Fair", 0.8 },
        { "Good", 1.0 },
        { "Excellent", 1.5 },
        { "Pristine", 2.5 }
    };

    /// <summary>
    /// Calculates the total market value of a flora harvest.
    /// </summary>
    public static double CalculateFloraValue(
        Flora flora,
        string quality,
        int quantity,
        MarketConditions marketConditions)
    {
        // Base value per unit
        double baseValue = flora.BaseMarketValue;

        // Quality multiplier
        if (!QualityMultipliers.TryGetValue(quality, out double qualityValue))
            qualityValue = 1.0;
        double qualityAdjustedValue = baseValue * qualityValue;

        // Rarity modifier (affects demand)
        double rarityBonus = 1.0 + (flora.RarityScore * 0.15);

        // Quantity discount (bulk sales slightly less per unit)
        double quantityDiscount = Math.Min(1.0, Math.Pow(0.95, quantity / 50.0));

        // Market demand
        double demandModifier = CalculateDemandFactor(flora, marketConditions);

        // Freshness penalty (harvested flora loses value over time)
        double freshnessModifier = Math.Max(0.4, 1.0 - (marketConditions.DaysSinceHarvest * 0.1));

        // Calculate total value
        double totalValue = qualityAdjustedValue * quantity * rarityBonus *
                           quantityDiscount * demandModifier * freshnessModifier;

        return totalValue;
    }

    private static double CalculateDemandFactor(Flora flora, MarketConditions conditions)
    {
        double modifier = 1.0;

        // Medicinal herbs have high demand
        if (flora.MedicinalPotency > 0.7)
            modifier *= 1.2;

        // Alchemy ingredients
        if (flora.AlchemyValue > 0.5)
            modifier *= 1.15;

        // Seasonal demand
        if (conditions.CurrentSeason == flora.BloomSeason)
            modifier *= 0.85; // More abundant = lower price
        else if (flora.BloomSeason != "Eternal")
            modifier *= 1.3; // Out of season = higher price

        // Global supply shortage
        if (conditions.GlobalSupply < 0.2)
            modifier *= 1.5;
        else if (conditions.GlobalSupply > 0.9)
            modifier *= 0.7;

        return modifier;
    }
}

public class MarketConditions
{
    public double GlobalSupply { get; set; } // 0.0 - 1.0
    public double GlobalDemand { get; set; } // 0.0 - 1.0
    public string CurrentSeason { get; set; }
    public int DaysSinceHarvest { get; set; }
    public bool IsPlagueActive { get; set; }
    public bool IsWarTime { get; set; }
}
```

### Trade Networks

- **Herbalist Guilds**: Organizations controlling herb gathering and distribution
- **Alchemist Circles**: Networks of potion makers and ingredient traders
- **Farmer Cooperatives**: Groups of cultivators sharing resources and knowledge
- **Merchant Routes**: Trade paths for distributing flora to distant regions
- **Black Market Botanicals**: Illegal trade in restricted or toxic plants

### Resource Management

- **Crop Rotation**: Planting different species in sequence to maintain soil health
- **Sustainable Harvesting**: Leaving portions of plants to regenerate
- **Seed Banking**: Storing seeds for future planting seasons
- **Cross-Breeding**: Combining traits from different flora to create hybrids
- **Magical Cultivation**: Using arcane methods to enhance growth and properties

---

## Advanced Flora Features

### Magical Flora Properties

- **Mana Affinity**: Plants' ability to absorb and store magical energy
- **Spell Components**: Certain flora serve as catalysts for magical effects
- **Enchantment Receptiveness**: Plants' capacity to be magically enhanced
- **Aura Emission**: Flora that radiate magical auras affecting nearby beings
- **Arcane Mutations**: Plants altered by magical exposure with unique properties

### Environmental Flora

- **Bioluminescence**: Plants that naturally emit light
- **Symbiotic Ecosystems**: Flora that depend on or enhance other organisms
- **Weather Manipulation**: Plants that influence local climate conditions
- **Dimensional Rifts**: Flora existing partially in other planes
- **Temporal Anomalies**: Plants affected by or affecting time flow

### Specialized Cultivation

- **Greenhouse Farming**: Controlled environments for year-round cultivation
- **Hydroponic Gardens**: Growing plants in water-based systems
- **Floating Gardens**: Cultivation in mid-air using magical suspension

```

## Chunk 5/5

```markdown
- **Underground Caverns**: Cultivating shade and cave-dwelling plants
- **Dimensional Gardens**: Growing flora in magically-enhanced pocket dimensions

### Hybrid and Mutations

- **Intentional Hybrids**: Cross-bred plants with enhanced properties
- **Magical Mutations**: Plants permanently altered by magical exposure
- **Radiation Variants**: Flora growing near magical hotspots
- **Cursed Plants**: Plants corrupted by dark magic with special effects
- **Blessed Flora**: Plants infused with divine or protective magic

---

## Performance Optimization

### Flora Management

- **Growth Caching**: Store calculated growth states for efficient updates
- **Spatial Flora Indexing**: Efficient storage of plant locations in garden systems
- **Procedural Generation**: Dynamic creation of flora during exploration
- **LOD Systems**: Reduce plant detail based on distance from player
- **Batch Harvesting**: Process multiple plant harvests simultaneously

### Cultivation Efficiency

- **Seasonal Updates**: Update all plants once per season rather than each tick
- **Dormancy Pooling**: Group dormant plants to reduce processing
- **Lazy Evaluation**: Only calculate stats when flora is directly interacted with
- **Garden Snapshots**: Store garden states to reduce recalculation
- **Yield Prediction**: Precalculate harvest values to avoid runtime computation

---

## Missing Information Checklist

The following information has been verified as complete in this system:

- ✓ 23 distinct flora property categories with detailed definitions
- ✓ Comprehensive data dictionary with stat bonuses and mechanical effects
- ✓ Complete procedural naming system with C# examples
- ✓ Plant growth calculations with environmental modifiers
- ✓ Market value calculations for harvested flora
- ✓ Botanical classification and harvesting methods
- ✓ Processing and refinement mechanics for alchemy
- ✓ Trade networks and economic interactions
- ✓ Advanced magical and environmental features
- ✓ Performance optimization strategies

### Potential Future Enhancements

- Flora mutation and evolution systems
- Seed breeding mechanics for custom plant creation
- Invasive species and ecological balance mechanics
- Endangered flora preservation quests
- Seasonal migration of harvestable plants
- Flora-based building materials and construction
- Plant-based poisons and toxicology systems
- Cooperative garden management
- Flora-centered NPCs and herbalist storylines
- Cross-game seasonal event flora appearances

---

```

---

# FILE: `docs/01_world/minerals.md`

| Metric | Value |
|----------|----------|
| Size | 27,063 bytes |
| Lines | 749 |
| Tokens | 6,764 |
| SHA256 | `18f5d7f4b986095f30ebfc78825dc8901c205ef43d4f59eab9c46a680a0d7219` |

## Chunk 1/3

```markdown
# Minerals and Geological Resources System

**Description:** Comprehensive documentation of mineral resources and geological materials in Aetherbourne
**Last Updated:** 2025-10-04

---

## Overview

This system manages all mineral deposits, ores, gems, and geological materials that form the foundation of crafting, construction, and magical systems in the game world. Minerals integrate with the global macro drivers (Latitude, Altitude, Humidity, DepthLayer, Magical Anomalies, Contamination) to procedurally generate contextual resources tailored to geological conditions across all 15 biomes. Custom 2D rendering properties enable hex-color palette matching, sprite animation, particle effects, and Y-layer sorting for pixel-perfect 32x32 tile rendering.

---

## Macro Global Drivers (Planetary Context)

Mineral generation uses the same environmental parameter vectors as flora:

- **Latitude** (0.0 = Equator/Hot → 1.0 = Poles/Cold): Drives thermal mineral generation
- **Altitude** (0.0 = Sea Level → 1.0 = Mountain Peaks): Determines ore richness and metallurgic types
- **Humidity** (0.0 = Arid → 1.0 = Saturated): Influences mineral purity and oxidation state
- **Depth Layer** (0 = Surface, 1 = Subterranean, 2 = Mantle): Dictates geological origin (Sedimentary → Magmatic → Mantle)
- **System Flags** (Boolean): `IsMagicalAnomaly` spawns Glowstone/Gems; `IsContaminated` spawns Toxic/Irradiated variants

---

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

---

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

------------------------------
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
        { "Non-Magickal", ("Inert", "Nullifica
```

## Chunk 2/3

```markdown
tion") },
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
    # Base value per unit
    base_value = mineral.base_market_value

    # Quality multiplier
   
```

## Chunk 3/3

```markdown
 quality_multipliers = {
        'poor': 0.5,
        'fair': 0.8,
        'good': 1.0,
        'excellent': 1.5,
        'flawless': 2.5
    }
    quality_value = base_value * quality_multipliers[quality]

    # Quantity discount (bulk sales are slightly less per unit)
    quantity_discount = min(1.0, 0.95 ** (quantity / 10))

    # Market conditions
    supply_demand_modifier = calculate_supply_demand(mineral, market_conditions)

    # Rarity bonus
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
```

---

# FILE: `docs/01_world/world.md`

| Metric | Value |
|----------|----------|
| Size | 13,615 bytes |
| Lines | 817 |
| Tokens | 3,393 |
| SHA256 | `734bf9d3006349db4c70b38de45d8d46eb7008ce006015fe6c0be758ae8640fb` |

## Chunk 1/2

```markdown
# World and Biome Systems

**Description:** Core environmental driver systems and biome taxonomy for Aetherbourne
**Last Updated:** 2026-06-15

---

# Planetary Context (Macro Global Drivers)

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

---

# Climate Overlays

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

---

# Hazard Layers

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

---

# Water Features

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

# The 15 Base Biomes

A deterministic cascade evaluates the PlanetaryContext to assign a single BaseBiome enum.

This biome then drives:

* Visual rendering
* Tile generation
* Physics modifiers
* Flora generation
* Fauna spawning
* Ambient effects
* Resource tables

---

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

---

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

---

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

---

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

---

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

---

### 6. Rockland

High altitude, low moisture, exposed bedrock.

Mountainous stone terrain with minimal vegetation.

**Tile Movement Speed:** 0.7 (rough stone)

**Ambient Light:** Radiant

**Common Water Features**

* Springs
* Waterfalls

---

### 7. Shrubland

Transitional humidity and sparse brush.

Acts as a transitional biome between forest and grassland.

**Tile Movement Speed:** 0.9 (minor vegetation)

**Ambient Light:** Radiant (partial canopy)

---

### 8. Coastal

Land-meets-water transition zone.

Sandy beach autotiles and salt-tolerant vegetation.

**Tile Movement Speed:** 0.6 (sand and surf)

**Ambient Light:** Radiant

**Common Water Features**

* Beaches
* Estuaries
* Coastal wetlands

---

### 9. Freshwater

Inland lakes and rivers.

Aquatic plant life and drinkable water sources.

**Tile Movement Speed:** 0.2 (swimming)

**Atmospheric Pressure:** Crushing (depth dependent)

**Common Water Features**

* Lakes
* Rivers
* Ponds

---

### 10. Ocean

Deep saltwater ecosystems.

Bioluminescent organisms, deep trenches, and thermal vents.

**Tile Movement Speed:** 0.1 (water resistance)

**Atmospheric Pressure:** Crushing

**Ambient Light:** Dim (light absorption)

**Common Water Features**

* Deep trenches
* Thermal vent fields

---

# Emergent Surface Biomes

Emergent biomes occur when specific environmental thresholds are met.

---

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

---

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

---

# Subterranean Biomes

---

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

---

### 14. Abyssal Chasms

Massive deep cave vaults.

Pitch-black environments containing toxic gases, ancient fossils, and biological dead zones.

**Atmospheric Pressure:** Crushing

**Ambient Light:** Pitch-Black

**Acoustic Profile:** Echoing

**Common Water Features**

* Deep underground rivers
* Toxic underground pools

---

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

---

# Biome Physics Modifiers

---

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

---

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

---

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

---

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

---

# Hazard Layer Effects

## Pristine

No additional environmental hazards.

---

## Miasmic

Poisonous gas clouds and decomposition zones.

* 2 Poison Damage/Second
* Reduced Visibility

---

## Irradiated

Radioactive contamination.

* 1 Radiation Damage/Second
* Increased mutation rates

---

## Cursed

Arcane corruption.

* 1 Curse Damage/Second
* Temporary magical suppression

---

## Volatile

Extreme geological instability.

* Lava hazards
* Fire damage
* Explosive geothermal activity

---

# Fertility System

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

---

# Drainage System

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

---

# Hydrology Generation

Water is generated before biome assignment and acts as a primary ecosystem driver.

---

## Springs

Generated at high elevations where underground water reaches the surface.

---

## Streams

Generated from springs and runoff.

---

## Rivers

Generated when multiple streams converge.

Rivers act as major biodiversity corridors.

---

## Lakes

Generated in natural depressions with sufficient water accumulation.

---

## Ponds

Small isolated water bodies.

---

## Marshes and Bogs

Generated from:

* High Humidity
* Low Drainage
* Shallow Water

---

## Oases

Generated when groundwater surfaces within desert regions.

Oases become ecological hotspots.

---

## Underground Water Systems

Generated within subterranean layers.

Includes:

* Underground Rivers
* Underground Lakes

---

# Seasonal Hydrology

Water systems fluctuate dynamically throughout the year.

---

## Spring

* Rivers swell
* Wetlands expand
* Plant growth accelerates

---

## Summer

* Water levels decrease
* Drought risk increases

---

## Autumn

* Stable water distribution

---

## Winter

* Surface water freezes
* Snow accumulation increases
* River flow slows

---

# Ecological Influence Chain

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

```

## Chunk 2/2

```markdown
Settlement Growth
      ↓
Civilization Development
```

This creates emergent ecological and societal behavior without relying on scripted events.

---

# Biome Distribution Parameters

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

# Design Philosophy

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
```

---

# FILE: `docs/02_creatures/actions.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/creatures.md`

| Metric | Value |
|----------|----------|
| Size | 4,620 bytes |
| Lines | 348 |
| Tokens | 1,140 |
| SHA256 | `b40cdf400c3858402b34406392dd5880be0f98533e2b45514adf1b664c3865aa` |

```markdown
These are not traditional RPG stats where they directly modify combat calculations. Instead, they are **layers of abstraction** that help drive behavior, skill growth, personality development, and emergent outcomes.

The hierarchy itself is interesting:

```
Core Stats (Inherited + Trainable)
├─ Strength
├─ Stamina
├─ Dexterity
├─ Perception
└─ Willpower

Advanced Stats (Derived)
├─ Endurance
├─ Prowess
├─ Finesse
├─ Conviction
└─ Vitality

Hidden Stats (Second-order Derived)
├─ Focus
├─ Insight
├─ Creativity
├─ Fortitude
└─ Momentum
```

---

## Core Stats

These should be the only stats that actually exist on the creature.

### Strength

Represents force production.

Affects:

* Carrying capacity
* Melee damage
* Mining
* Woodcutting
* Construction
* Grappling
* Throwing

### Stamina

Represents physical endurance.

Affects:

* Energy consumption
* Fatigue resistance
* Travel distance
* Work duration
* Recovery speed

### Dexterity

Represents coordination and precision.

Affects:

* Crafting quality
* Accuracy
* Dodging
* Tool use
* Harvesting efficiency

### Perception

Represents awareness.

Affects:

* Detection radius
* Resource spotting
* Threat recognition
* Tracking
* Memory acquisition

### Willpower

Represents mental persistence.

Affects:

* Goal commitment
* Fear resistance
* Pain tolerance
* Emotional stability
* Long-term planning

---

# Advanced Stats

Don't store them.

Compute dynamically:

```cpp
Endurance = (Strength + Stamina) / 2
Prowess   = (Strength + Dexterity) / 2
Finesse   = (Dexterity + Perception) / 2
Conviction= (Willpower + Perception) / 2
Vitality  = (Stamina + Willpower) / 2
```

These become useful because they represent broad competencies.

---

## Endurance

How long a creature can physically perform.

Used by:

* Hunting
* Long travel
* Combat duration
* Labor

---

## Prowess

Physical effectiveness.

Used by:

* Fighting
* Athletics
* Physical skill learning

---

## Finesse

Precision and awareness combined.

Used by:

* Crafting
* Gathering
* Tracking
* Tool mastery

---

## Conviction

Mental clarity and awareness.

Used by:

* Decision making
* Leadership
* Social influence
* Maintaining goals

---

## Vitality

Overall resilience.

Used by:

* Recovery
* Disease resistance
* Survival

---

# Hidden Stats

These are where things become really interesting.

These shouldn't be visible to players.

Instead they should influence emergent behavior.

---

## Focus

```cpp
Focus = (Endurance + Finesse) / 2
```

Represents sustained attention.

Affects:

* Learning speed
* Task completion rate
* Skill gain

Creatures with high Focus:

* Finish what they start
* Learn faster
* Switch tasks less often

---

## Insight

```cpp
Insight = (Prowess + Conviction) / 2
```

Represents understanding.

Affects:

* Decision quality
* Pattern recognition
* Tactical choices

High Insight creatures:

* Make smarter choices
* Predict danger better
* Select better actions

---

## Creativity

```cpp
Creativity = (Finesse + Vitality) / 2
```

Represents adaptability.

Affects:

* Discovering solutions
* Inventing behaviors
* Exploration

High Creativity creatures:

* Try unusual actions
* Explore more
* Develop unique strategies

---

## Fortitude

```cpp
Fortitude = (Endurance + Conviction) / 2
```

Represents perseverance.

Affects:

* Surviving hardship
* Emotional resilience
* Persistence

High Fortitude creatures:

* Don't quit easily
* Survive disasters
* Continue goals despite setbacks

---

## Momentum

```cpp
Momentum = (Vitality + Prowess) / 2
```

Represents action tendency.

Affects:

* Initiative
* Activity level
* Goal pursuit

High Momentum creatures:

* Act quickly
* Explore aggressively
* Accomplish more during their lifetime

---

# The interesting part

**Personality emerges partly from these hidden stats.**

Not through genetics directly.

Instead:

```cpp
Personality =
(
Genetics
+
Memories
+
Experiences
+
Hidden Stats
)
```

Example:

Two creatures can have identical personalities at birth.

One grows into:

* High Focus
* High Fortitude

because it trained constantly.

The other develops:

* High Creativity
* High Momentum

because it spent its life exploring.

Now they begin making different decisions and slowly diverge into different personalities despite sharing similar genetics.

This aligns with the philosophy:

> Genetics determine inherited capabilities.
>
> Personality emerges from experience.

The hidden stats become the bridge between raw capabilities and the emergent personalities that develop over a creature's lifetime.


```

---

# FILE: `docs/02_creatures/emotions.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/genetics.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/memories.md`

| Metric | Value |
|----------|----------|
| Size | 722 bytes |
| Lines | 60 |
| Tokens | 180 |
| SHA256 | `872f5a3c8fa7a7ec31b447b02b25af130c85ac094ccb2be5a9f759ff2e463089` |

```markdown

## Memory Formation

Not all events become memories.

Memory creation depends on:

* Event Severity
* Personal Relevance
* Emotional Response

Formula:

MemoryStrength =
Severity
× PersonalRelevance
× EmotionalResponse

Low-strength memories may never be stored.

High-strength memories may persist for years or an entire lifetime.

---

## Memory Decay

Memories decay over time.

```csharp
public struct Memory
{
    public EventData SourceEvent;

    public float Strength;

    public float EmotionalWeight;

    public float DecayRate;
}
```

Minor events fade quickly.

Major life events decay slowly.

Examples:

Shared Food

Strength = 10

DecayRate = High

Lost Parent

Strength = 95

DecayRate = Very Low

---
```

---

# FILE: `docs/02_creatures/needs.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/personality.md`

| Metric | Value |
|----------|----------|
| Size | 7,092 bytes |
| Lines | 364 |
| Tokens | 1,756 |
| SHA256 | `d505e12cd6ff9c5b33085d58db5baf7daeed4b34173369beb203038c6b003538` |

```markdown
# Aging & Personality Evolution

Personality develops throughout a creature's life as new psychological domains emerge and existing domains mature.

Each personality domain contains two axes ranging from **-100 to 100**. These axes are gradually shaped by genetics, experiences, memories, relationships, and life events.

Domains do not disappear when a creature ages. Instead, they become foundational personality layers that influence the development of later domains. For example, a creature's Temperament evolves into Emotional traits during childhood, while the original Temperament domain remains as part of the creature's underlying personality foundation.

This system allows personality to develop organically across a lifetime while preserving the influence of earlier experiences and developmental stages.

## Personality Development by Age

| Age         | New Domain    | Evolution                   | Active Domains                                       | Mature Domains                                           |
| ----------- | ------------- | --------------------------- | ---------------------------------------------------- | -------------------------------------------------------- |
| Infant      | Temperament   | N/A                         | Temperament                                          | N/A                                                      |
| Toddler     | Socialization | N/A                         | Temperament, Socialization                           | N/A                                                      |
| Child       | Cognition     | Temperament → Emotional     | Emotional, Socialization, Cognition                  | Temperament                                              |
| Teenager    | Identity      | Socialization → Interaction | Emotional, Interaction, Cognition, Identity          | Temperament, Socialization                               |
| Young Adult | Morals        | Cognition → Purpose         | Emotional, Interaction, Purpose, Identity, Morals    | Temperament, Socialization, Cognition                    |
| Adult       | N/A           | Identity → Perspective      | Emotional, Interaction, Purpose, Perspective, Morals | Temperament, Socialization, Cognition, Identity          |
| Elder       | N/A           | Purpose → Legacy            | Emotional, Interaction, Legacy, Perspective, Morals  | Temperament, Socialization, Cognition, Identity, Purpose |

### Domain Evolution Tree

```
Temperament
    ↓
Emotional
```
```
Socialization
    ↓
Interaction
```
```
Cognition
    ↓
Purpose
    ↓
Legacy
```
```
Identity
    ↓
Perspective
```
```
Morals
    (Independent)
```
# Personality Domains

Personality develops throughout a creature's life.

Each domain contains two axes ranging from **-100 to 100**.

Earlier domains do not disappear as creatures age. Instead, they become foundational personality layers that influence later domains.

---

## Temperament (Infant)

Represents innate emotional tendencies.

#### Emotional Reactivity

```text
Calm (-100) ↔ Reactive (+100)
```

How strongly emotions are triggered.

#### Security

```text
Content (-100) ↔ Anxious (+100)
```

Baseline sense of safety and comfort.

---

## Socialization (Toddler)

Represents early social learning.

#### Dependence

```text
Dependent (-100) ↔ Independent (+100)
```

Reliance on others versus self-reliance.

#### Cooperation

```text
Reserved (-100) ↔ Cooperative (+100)
```

Willingness to engage and work with others.

---

## Cognition (Child)

Represents how a creature understands the world.

#### Curiosity

```text
Cautious (-100) ↔ Curious (+100)
```

Desire to explore and discover.

#### Thinking Style

```text
Practical (-100) ↔ Imaginative (+100)
```

Preference for concrete versus abstract thinking.

---

## Identity (Teenager)

Represents self-discovery and self-image.

#### Individuality

```text
Conforming (-100) ↔ Independent (+100)
```

Need for self-expression and uniqueness.

#### Self-Worth

```text
Humble (-100) ↔ Proud (+100)
```

Perception of personal value and importance.

---

## Emotional (Child+)

Evolved from Temperament.

Represents emotional regulation and outlook.

#### Regulation

```text
Impulsive (-100) ↔ Composed (+100)
```

Ability to regulate emotional responses.

#### Outlook

```text
Pessimistic (-100) ↔ Optimistic (+100)
```

Expectation of future outcomes.

---

## Interaction (Teenager+)

Evolved from Socialization.

Represents social behavior and influence.

#### Sociability

```text
Introverted (-100) ↔ Extroverted (+100)
```

Preference for social engagement.

#### Social Presence

```text
Passive (-100) ↔ Assertive (+100)
```

Willingness to influence others.

---

## Purpose (Young Adult+)

Evolved from Cognition.

Represents motivation and direction.

#### Ambition

```text
Content (-100) ↔ Ambitious (+100)
```

Desire for achievement and advancement.

#### Persistence

```text
Flexible (-100) ↔ Determined (+100)
```

Commitment to long-term goals.

---

## Morals (Young Adult+)

Represents ethical beliefs and values.

#### Compassion

```text
Cruel (-100) ↔ Compassionate (+100)
```

Concern for the wellbeing of others.

#### Ethics

```text
Pragmatic (-100) ↔ Principled (+100)
```

Outcome-focused versus value-focused decision making.

---

## Perspective (Adult+)

Evolved from Identity.

Represents worldview and accumulated wisdom.

#### Tradition

```text
Traditional (-100) ↔ Progressive (+100)
```

Openness to change and new ideas.

#### Scope

```text
Local (-100) ↔ Global (+100)
```

Focus on immediate surroundings versus broader systems.

---

## Legacy (Elder)

Evolved from Purpose.

Represents concern for lasting impact.

#### Endurance

```text
Momentary (-100) ↔ Enduring (+100)
```

Preference for immediate outcomes versus lasting impact.

#### Generativity

```text
Individualistic (-100) ↔ Generative (+100)
```

Focus on personal benefit versus creating value that outlives oneself.

```

A creature high in Enduring and Generative traits is more likely to mentor others, preserve knowledge, establish traditions, and invest in future generations.
```
---
## Personality Development

Events never directly modify personality.

Instead:

Event
→ Memory
→ Personality Drift

This allows creatures to gradually evolve through lived experiences.

---

## Personality Drift

Each memory contains personality influence values.

Example:

Betrayal Memory

Trusting = -5

Hopeful = -3

Empathetic = -2

Mentorship Memory

Trusting = +3

Cooperative = +4

Merciful = +2

These influences accumulate over time.

---

## Personality Drift Formula

PersonalityChange =
(
MemoryStrength
× EmotionalWeight
× AxisModifier
)
/
PersonalityResistance

Repeated experiences create larger changes than isolated incidents.

---

## Personality Persistence

Memories may fade.

Personality changes may remain.

Example:

Repeated Childhood Betrayal

Memory eventually decays.

Trusting → Guarded shift remains.

This allows experiences to permanently shape creatures.

```

---

# FILE: `docs/02_creatures/relationships.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/skills.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/02_creatures/stats.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/03_simulation/events.md`

| Metric | Value |
|----------|----------|
| Size | 5,255 bytes |
| Lines | 402 |
| Tokens | 1,309 |
| SHA256 | `51ef073f467e3e95f76f640901a37f326be0cc73adc93a561769c7c6521d8266` |

```markdown
# Event System

**Description:** Modular event generation, memory formation, and personality development systems for Aetherbourne

**Last Updated:** 2026-06-15

---

## Overview

The Event System serves as the primary bridge between simulation activity and emergent storytelling.

Events are generated whenever actors perform actions under specific conditions and for specific reasons. Events may affect individuals, groups, settlements, regions, or the entire world.

Events do not directly modify personality.

Instead:

Event
→ Emotional Response
→ Memory
→ Personality Drift
→ Behavioral Change
→ Future Events

This creates a feedback loop where creatures are shaped by their experiences throughout their lives.

---

## Event Philosophy

Events are not handcrafted narrative content.

Events emerge naturally from simulation systems.

Just as biomes emerge from environmental variables, events emerge from:

* Actors
* Witnesses
* Actions
* Targets
* Causes
* Conditions
* Outcomes

Events are simulation facts.

Narratives emerge later from collections of related events.

---

## Event Structure

```csharp
public struct EventData
{
    public EventCategory Category;

    public EventScale Scale;

    public float Severity;

    public EventActor[] Actors;

    public EventWitnesses[] Witnesses;

    public EventAction Action;

    public EventTarget[] Targets;

    public EventCause Cause;

    public EventCondition[] Conditions;

    public EventOutcome[] Outcomes;

    public long Timestamp;
}
```

---

## Event Formula

Cause + Conditions = Action

Actor + Action + Target = Event

Event + Severity + Scale = Outcomes

---

## Event Categories

Events are grouped into broad simulation domains.

### Environmental

World-driven events.

Examples:

* Storms
* Floods
* Droughts
* Earthquakes
* Volcanic Eruptions
* Cave-ins

### Biological

Life-cycle and ecological events.

Examples:

* Birth
* Death
* Predation
* Migration
* Disease
* Mutation

### Social

Relationship-driven events.

Examples:

* Friendship
* Mentorship
* Marriage
* Adoption
* Betrayal
* Reconciliation

### Conflict

Competitive interactions.

Examples:

* Arguments
* Fights
* Territory Disputes
* Raids
* Wars

### Discovery

Knowledge and exploration events.

Examples:

* Resource Discovery
* New Territory Found
* Ancient Ruin Discovered

### Economic

Resource exchange events.

Examples:

* Trade
* Theft
* Resource Shortage
* Resource Surplus

### Cultural

Shared group events.

Examples:

* Rituals
* Festivals
* Ceremonies
* Religious Gatherings

### Personal

Individual milestones.

Examples:

* Coming of Age
* Skill Mastery
* First Hunt
* Leadership Appointment

---

## Event Scale

Scale determines event reach.

#### Individual

Affects a single creature.

#### Family

Affects related creatures.

#### Group

Affects a social group.

#### Settlement

Affects an entire settlement.

#### Regional

Affects a biome or large territory.

#### Global

Affects the entire world.

---

## Event Severity

Severity measures event impact.

Range:

0.0 - 100.0

| Severity | Classification |
| -------- | -------------- |
| 0-20     | Minor          |
| 21-40    | Moderate       |
| 41-60    | Major          |
| 61-80    | Severe         |
| 81-100   | Catastrophic   |

Severity influences:

* Memory formation
* Memory longevity
* Personality drift magnitude
* Story significance

---

## Actors

Actors initiate events.

Examples:

* 
* Family
* Group
* Settlement
* Species
* Volcano
* Storm
* Region

Multiple actors may participate.

---

## Actions

Actions describe what occurred.

Examples:

* Hunt
* Attack
* Trade
* Share
* Betray
* Defend
* Explore
* Discover
* Erupt
* Flood

Actions are reusable and independent of category.

---

## Targets

Targets receive event effects.

Examples:

* Indiviual
* Group
* Resource
* Settlement
* Region

Events may affect multiple targets.

---

## Causes

Causes explain why an action occurred.

Examples:

* Hunger
* Fear
* Loyalty
* Curiosity
* Ambition
* Resource Scarcity
* Territorial Pressure
* Tectonic Pressure

Causes represent motivation.

---

## Conditions

Conditions determine whether an event can occur.

Examples:

* Food Nearby
* Prey Visible
* Relationship > 50
* Territory Overlap
* Humidity > 0.8
* Tectonic Activity = Volcanic

Conditions represent possibility.

An event may have a valid cause but fail if conditions are not met.

---

## Outcomes

Outcomes represent state changes.

Outcomes should be modular.

Examples:

* Health -10
* Trust +5
* Relationship +10
* Food +3
* Territory Expanded
* Creature Dead
* Resource Created

Events may generate multiple outcomes.

---
## Event Consequences

Events may generate immediate outcomes and long-term psychological effects.

Immediate effects are applied through Outcomes.

Long-term effects are handled by the Emotion, Memory, and Personality systems.

### Event → Story Pipeline

Simulation Layer

Events

↓

Memory Layer

Personal Memories

↓

Personality Layer

Personality Development

↓

Behavior Layer

Decision Making

↓

Narrative Layer

Emergent Stories

Stories are not authored.

Stories emerge naturally from the accumulation of events, memories, relationships, and personality development.

```

---

# FILE: `docs/03_simulation/time.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/04_society/communities.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/04_society/culture.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/05_content/consumables.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/05_content/equipment.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/05_content/items.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/05_content/stations.md`

| Metric | Value |
|----------|----------|
| Size | 9 bytes |
| Lines | 1 |
| Tokens | 3 |
| SHA256 | `1c09f5a7f47df2ee11dac3abd4010d9b70fb62c46446fd0c872c67a37609a52d` |

```markdown
equipment
```

---

# FILE: `docs/05_content/tools.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `docs/05_content/weapons.md`

| Metric | Value |
|----------|----------|
| Size | 0 bytes |
| Lines | 1 |
| Tokens | 0 |
| SHA256 | `e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855` |

---

# FILE: `files.py`

| Metric | Value |
|----------|----------|
| Size | 6,669 bytes |
| Lines | 311 |
| Tokens | 1,664 |
| SHA256 | `5dfca0dd55df5b03ed8c1758fcd0a2d203cee7c97a10b27f59a7793e581601a9` |

```python
from pathlib import Path
import hashlib
import mimetypes
import math
import sys

# ============================================================
# CONFIG
# ============================================================

ROOT_DIR = Path(".").resolve()
OUTPUT_FILE = "project_dump.md"

MAX_FILE_SIZE_MB = 5
MAX_TOTAL_FILES = 5000

CHUNK_SIZE = 12000

SKIP_HIDDEN = True

SKIP_DIRS = {
    ".git",
    ".github",
    ".idea",
    ".vscode",
    "__pycache__",
    ".pytest_cache",
    ".mypy_cache",
    ".tox",
    ".venv",
    "venv",
    "env",
    "node_modules",
    "dist",
    "build",
    "target",
    ".next",
    ".nuxt",
    ".cache",
    "coverage",
    "vendor",
}

SKIP_FILENAMES = {
    ".DS_Store",
    "Thumbs.db",
    "package-lock.json",
    "yarn.lock",
    "pnpm-lock.yaml",
    "poetry.lock",
    "Cargo.lock",
}

SKIP_EXTENSIONS = {
    ".png", ".jpg", ".jpeg", ".gif", ".webp",
    ".bmp", ".ico", ".svg",
    ".mp4", ".avi", ".mov", ".mkv",
    ".mp3", ".wav", ".ogg",
    ".zip", ".rar", ".7z", ".tar", ".gz",
    ".exe", ".dll", ".so", ".dylib",
    ".pdf",
    ".woff", ".woff2", ".ttf", ".otf",
    ".class",
    ".pyc",
}

# ============================================================
# HELPERS
# ============================================================

def estimate_tokens(text: str) -> int:
    return math.ceil(len(text) / 4)


def sha256(path: Path):
    h = hashlib.sha256()

    with open(path, "rb") as f:
        while chunk := f.read(65536):
            h.update(chunk)

    return h.hexdigest()


def detect_language(path: Path):
    ext = path.suffix.lower()

    mapping = {
        ".py": "python",
        ".js": "javascript",
        ".ts": "typescript",
        ".tsx": "tsx",
        ".jsx": "jsx",
        ".json": "json",
        ".yaml": "yaml",
        ".yml": "yaml",
        ".html": "html",
        ".css": "css",
        ".md": "markdown",
        ".txt": "text",
        ".java": "java",
        ".c": "c",
        ".cpp": "cpp",
        ".h": "c",
        ".hpp": "cpp",
        ".cs": "csharp",
        ".rs": "rust",
        ".go": "go",
        ".sh": "bash",
        ".toml": "toml",
        ".xml": "xml",
    }

    return mapping.get(ext, "")


def is_binary(path: Path):
    try:
        with open(path, "rb") as f:
            chunk = f.read(8192)

        if b"\x00" in chunk:
            return True

        text_chars = sum(
            (32 <= b <= 126) or b in b"\n\r\t"
            for b in chunk
        )

        if len(chunk) == 0:
            return False

        return (text_chars / len(chunk)) < 0.70

    except:
        return True


def should_skip(path: Path):
    if path.name in SKIP_FILENAMES:
        return True

    if path.suffix.lower() in SKIP_EXTENSIONS:
        return True

    if SKIP_HIDDEN and path.name.startswith("."):
        return True

    if any(part in SKIP_DIRS for part in path.parts):
        return True

    return False


def chunk_text(text, chunk_size):
    for i in range(0, len(text), chunk_size):
        yield text[i:i + chunk_size]


# ============================================================
# BUILD TREE
# ============================================================

tree_lines = []


def build_tree(path, prefix=""):
    try:
        items = sorted(
            [
                p for p in path.iterdir()
                if not should_skip(p)
            ],
            key=lambda x: (x.is_file(), x.name.lower())
        )
    except:
        return

    for i, item in enumerate(items):

        last = i == len(items) - 1

        connector = "└── " if last else "├── "

        tree_lines.append(
            f"{prefix}{connector}{item.name}"
        )

        if item.is_dir():
            extension = "    " if last else "│   "
            build_tree(item, prefix + extension)


# ============================================================
# COLLECT FILES
# ============================================================

files = []

for path in ROOT_DIR.rglob("*"):

    if not path.is_file():
        continue

    if should_skip(path):
        continue

    if is_binary(path):
        continue

    try:
        size_mb = path.stat().st_size / 1024 / 1024

        if size_mb > MAX_FILE_SIZE_MB:
            continue

    except:
        continue

    files.append(path)

files = sorted(files)

if len(files) > MAX_TOTAL_FILES:
    files = files[:MAX_TOTAL_FILES]

# ============================================================
# OUTPUT
# ============================================================

build_tree(ROOT_DIR)

total_size = 0
total_tokens = 0

with open(OUTPUT_FILE, "w", encoding="utf-8") as out:

    out.write("# Project Dump\n\n")

    out.write("## Summary\n\n")

    out.write(f"- Root: `{ROOT_DIR}`\n")
    out.write(f"- Files Included: {len(files):,}\n")
    out.write(f"- Max File Size: {MAX_FILE_SIZE_MB} MB\n")
    out.write(f"- Chunk Size: {CHUNK_SIZE:,} chars\n\n")

    out.write("---\n\n")

    out.write("## Directory Structure\n\n")

    out.write("```text\n")
    out.write("\n".join(tree_lines))
    out.write("\n```\n\n")

    out.write("---\n\n")

    for idx, path in enumerate(files, start=1):

        print(
            f"[{idx}/{len(files)}] {path.relative_to(ROOT_DIR)}",
            flush=True
        )

        try:
            content = path.read_text(
                encoding="utf-8",
                errors="replace"
            )
        except:
            continue

        size = path.stat().st_size
        tokens = estimate_tokens(content)

        total_size += size
        total_tokens += tokens

        rel = path.relative_to(ROOT_DIR)

        out.write(f"# FILE: `{rel}`\n\n")

        out.write("| Metric | Value |\n")
        out.write("|----------|----------|\n")
        out.write(f"| Size | {size:,} bytes |\n")
        out.write(f"| Lines | {content.count(chr(10)) + 1:,} |\n")
        out.write(f"| Tokens | {tokens:,} |\n")
        out.write(f"| SHA256 | `{sha256(path)}` |\n\n")

        lang = detect_language(path)

        chunks = list(chunk_text(content, CHUNK_SIZE))

        for chunk_num, chunk in enumerate(chunks, start=1):

            if len(chunks) > 1:
                out.write(
                    f"## Chunk {chunk_num}/{len(chunks)}\n\n"
                )

            out.write(f"```{lang}\n")
            out.write(chunk)
            out.write("\n```\n\n")

        out.write("---\n\n")

    out.write("# Final Statistics\n\n")
    out.write(f"- Total Files: {len(files):,}\n")
    out.write(f"- Total Size: {total_size:,} bytes\n")
    out.write(f"- Estimated Tokens: {total_tokens:,}\n")

print(f"\nCreated: {OUTPUT_FILE}")
```

---

# Final Statistics

- Total Files: 26
- Total Size: 115,908 bytes
- Estimated Tokens: 28,918
