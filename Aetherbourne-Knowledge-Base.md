
# Aetherbourne Knowledge Base

> Auto-generated from project documentation.
> Do not edit manually.

---

# Contents

- README.md
- docs/01_world/world.md
- docs/01_world/flora.md
- docs/01_world/minerals.md
- docs/02_creatures/creatures.md
- docs/02_creatures/genetics.md
- docs/01_world/cosmology.md
- docs/02_creatures/personality.md
- docs/02_creatures/stats.md
- docs/02_creatures/needs.md
- docs/02_creatures/emotions.md
- docs/02_creatures/memories.md
- docs/02_creatures/actions.md
- docs/03_simulation/time.md

---

---

# FILE: README.md

# Aetherbourne

Aetherbourne is a 2D top-down pixel-art life simulation built around systemic design, procedural generation, and emergent storytelling. Rather than relying on scripted narratives, the world operates through interconnected systems that allow unique stories to emerge naturally from the actions, experiences, and relationships of its inhabitants.

Every creature is an individual. They are born with inherited genetic traits that determine their physical characteristics, natural capabilities, strengths, and weaknesses. Beyond genetics, creatures possess needs, emotions, memories, and evolving personalities that develop throughout their lives. Who a creature becomes is shaped not only by what it inherits, but by what it experiences.

The world itself is procedurally generated from environmental factors such as climate, temperature, humidity, fertility, drainage, water access, geological conditions, and other planetary influences. These factors determine which biomes form, what resources are available, how hospitable an area is, and what challenges life must overcome. Rather than existing as isolated features, landscapes, ecosystems, water systems, hazards, and resources emerge from the same underlying environmental logic.

Plant life and mineral resources are generated as part of these ecosystems. Flora vary in rarity, growth patterns, physical characteristics, toxicity, medicinal properties, and other traits, while minerals differ in abundance, value, geological origin, and physical properties. Resources are not simply decorative objects; they exist as functional parts of the world and influence survival, exploration, crafting, trade, and future systems.

Creatures are driven by needs. Biological needs such as hunger, thirst, rest, and safety compete alongside psychological needs such as belonging, purpose, achievement, and fulfillment. These needs create motivations that influence which goals a creature chooses to pursue.

Goals lead to actions. Actions produce events. Events create emotional responses. Emotional experiences may become memories, and repeated memories gradually influence personality over time. Personality does not change instantly; it evolves slowly as creatures accumulate lived experiences throughout their lives.

Emotions serve as the bridge between objective events and subjective experience. The same event may affect different creatures in different ways depending on their personality, relationships, needs, past experiences, and current circumstances. Significant experiences can become lasting memories, while minor experiences fade away. Over time, repeated patterns of experience shape how creatures think, react, and behave.

Creatures possess a small set of core capabilities from which more complex competencies emerge. Learning, adaptation, problem-solving, creativity, focus, insight, and other behavioral tendencies influence how effectively a creature interacts with the world and responds to challenges.

Relationships form naturally through interaction. Social experiences, cooperation, conflict, competition, and shared histories influence how creatures perceive one another. These connections become part of each creature’s memory and contribute to future decisions and personality development.

As generations pass, inherited traits move through populations while environmental pressures influence survival and success. Lineages evolve, populations adapt, and communities develop distinct characteristics shaped by both genetics and experience.

The result is a living world where ecosystems, resources, creatures, and societies are all connected through shared systems. Every creature carries a unique combination of genetics, memories, emotions, needs, relationships, and experiences. Every life leaves traces behind. Every generation changes the future. The stories of Aetherbourne are not written in advance—they emerge naturally from the simulation itself.


---

# FILE: docs/01_world/world.md

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


---

# FILE: docs/01_world/flora.md

# Flora and Botanical Systems

**Description:** Comprehensive documentation of flora, plants, vegetation, and botanical resources in Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

This system manages all plant species, vegetation, herbs, crops, and botanical materials that form the foundation of alchemy, medicine, sustenance, and magical systems in the game world. Flora integrates with the global macro drivers (Latitude, Altitude, Humidity, DepthLayer, Magical Anomalies, Contamination) to procedurally generate contextual plants tailored to environmental conditions across 15 distinct biomes. Custom 2D rendering properties enable pixel-perfect sprite composition using a modular morphology matrix.

## Macro Global Drivers (Planetary Context)

All flora generation references these normalized (0.0 to 1.0) environmental parameters:

- **Latitude** (0.0 = Equator/Hot → 1.0 = Poles/Cold): Drives thermal and biome selection
- **Altitude** (0.0 = Sea Level → 1.0 = Mountain Peaks): Dictates atmospheric pressure and growth constraints
- **Humidity** (0.0 = Arid → 1.0 = Saturated): Determines water dependency and plant form
- **Distance From Water** (0.0 = Shoreline → 1.0 = Landlocked): Drives aquatic vs. xerophytic traits
- **Depth Layer** (0 = Surface, 1 = Subterranean, 2 = Mantle): Determines light level and biome type
- **System Flags** (Boolean): `IsMagicalAnomaly`, `IsContaminated` trigger special mutations

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

---

## Design Philosophy

High-level principles for botanical system design, procedural generation, and ecosystem consistency.

## Core Concepts

- Biome-driven plant generation
- Flora properties and categories
- Harvest and growth lifecycle

---

## Implementation / Notes

* Notes on data structure, flora generation rules, and rendering guidance.

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
* Alchemical (Used as potion, enchantment, or spellcraft components)
* Construction (Used for building, crafting, or structural materials)
* Textile (Used for fabric, rope, weaving, and soft goods)
* Fuel (Used for fire, steam, or energy production)
* Trade (High-value goods intended for merchants and barter)
* Ritual (Used for ceremonies, offerings, and magical rites)
* Environmental (Used to shape ecosystems, terrain, or weather)
* Utility (Used for traps, tools, dyes, preservatives, or household goods)

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
        { "Cryo", ("Glacial", "Frost") },
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
    { "Structural Type", "Spore-Cluster", 0.97 }, // Category 33
    { "Harvest Output", "Spores-Output", 0.94 },  // Category 34
    { "Resource Role", "Alchemical-Role", 0.96 }  // Category 35
});
// Output: Eternal Venerated Arcane Luminagaric of Reagents
```

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
- **Underground Caverns**: Cultivating shade and cave-dwelling plants
- **Dimensional Gardens**: Growing flora in magically-enhanced pocket dimensions

### Hybrid and Mutations

- **Intentional Hybrids**: Cross-bred plants with enhanced properties
- **Magical Mutations**: Plants permanently altered by magical exposure
- **Radiation Variants**: Flora growing near magical hotspots
- **Cursed Plants**: Plants corrupted by dark magic with special effects
- **Blessed Flora**: Plants infused with divine or protective magic

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

# FILE: docs/01_world/minerals.md

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

---

# FILE: docs/02_creatures/creatures.md

# Creatures System

**Description:** Creature types, species classification, and biological systems for all creatures in Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

The creatures system defines the fundamental types, species, and biological properties that characterize all living beings in Aetherbourne.

## Content Coming Soon

This documentation is currently in development. Please check back for updates.

---

## Design Philosophy

Intent and guiding principles for creature categories, lifecycles, and taxonomy.

## Core Concepts

- Species definition
- Life stages and reproduction
- Interaction hooks (AI, spawn rules)

---

## Implementation / Notes

* Data schemas, spawn tables, and reference examples.

---

# FILE: docs/02_creatures/genetics.md

# Genetics System

**Description:** Genetic inheritance, trait passing, and mutation systems for creature reproduction in Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

The genetics system defines how traits are inherited, how mutations arise, and how biodiversity emerges through reproduction.

## Content Coming Soon

This documentation is currently in development. Please check back for updates.

---

## Design Philosophy

Principles for heredity, mutation rates, and trait expression.

## Core Concepts

- Genotype vs phenotype
- Inheritance models
- Mutation and recombination

---

## Implementation / Notes

* Genetic encoding formats, example trait tables, and testing notes.

---

# FILE: docs/01_world/cosmology.md

# Cosmology & Aethersigns

**Description:** Celestial influences, Aethersigns, and personality predispositions for creatures in Aetherbourne
**Last Updated:** 2026-06-21

---

# Overview

The Cosmology System defines how celestial cycles influence creature development.

Every creature is born under an Aethersign determined by the current Phase, Selene's phase, and Karael's phase at the moment of birth.

Aethersigns do not determine behavior directly. Instead, they create developmental predispositions that influence personality formation throughout life. This system integrates with the [Personality System](docs/02_creatures/personality.md) by affecting initial tendencies, resistance, and memory weighting.

This system integrates with the Personality System by affecting:

- Initial personality tendencies
- Personality resistance
- Memory weighting
- Domain affinities

Personality ultimately emerges through experiences, memories, relationships, and environmental factors.

---

## Design Philosophy
*   **Influence, Not Destiny:** Astrology should guide development without forcing a specific behavioral outcome.
*   **Emergent Diversity:** Two creatures with the same Aethersign will still develop differently based on their unique lived experiences.
*   **Systemic Integration:** Celestial influences interact naturally with personality drift and resistance formulas.

## The Three Pillars of the Aethersign
An Aethersign consists of three components: **State**, **Modality**, and **Drive**.

Together these influences create a creature's astrological predispositions.

---

# 1. State (Foundational Nature)
Determined by the **Birth Phase**. It represents a creature's foundational nature and influences which personality domains they are naturally affined to.

| Phase | State | Domain Affinities |
| :--- | :--- | :--- |
| Brigide, Aestium | **Solid** | Temperament, Purpose, Legacy |
| Imbolka, Mabonel | **Liquid** | Socialization, Interaction, Morals |
| Floralis, Ceresio | **Gas** | Cognition, Perspective |
| Lithara, Yulith | **Plasma** | Identity, Purpose |
| Heliax, Hibernis | **Aether** | Emotional, Morals, Perspective |

Each State appears twice during every Span.

---

# States

## Solid

Associated Concepts:

- Stability
- Structure
- Reliability
- Endurance

Domain Affinities:

- Temperament
- Purpose
- Legacy

---

## Liquid

Associated Concepts:

- Adaptation
- Connection
- Empathy
- Cooperation

Domain Affinities:

- Socialization
- Interaction
- Morals

---

## Gas

Associated Concepts:

- Curiosity
- Exploration
- Knowledge
- Possibility

Domain Affinities:

- Cognition
- Perspective

---

## Plasma

Associated Concepts:

- Action
- Ambition
- Transformation
- Expression

Domain Affinities:

- Identity
- Purpose

---

## Aether

Associated Concepts:

- Reflection
- Meaning
- Consciousness
- Spirituality

Domain Affinities:

- Emotional
- Morals
- Perspective

---
# 2. Modality (Developmental Pace)

Modality is determined by Selene.

Modality influences how readily personality changes throughout life.

Modality primarily affects Personality Resistance.

Determined by **Selene's Phase**. It influences how readily a creature's personality changes in response to experiences.

| Selene Phase | Modality | Personality Effect |
| :--- | :--- | :--- |
| New Moon, Full Moon | **Anchor** | Higher Personality Resistance (+20%) |
| Waxing (Crescent, Quarter, Gibbous) | **Catalyst** | Lower Personality Resistance (-20%) |
| Waning (Gibbous, Quarter, Crescent) | **Current** | Situational/Contextual Resistance (±15%) |
---

# Modalities

Modalities describe how a creature responds to change and development.

## Catalyst

Characteristics:

- Initiates change
- Learns quickly
- Adapts rapidly

Personality Effect:

Lower Personality Resistance

---

## Anchor

Characteristics:

- Maintains stability
- Resists change
- Preserves consistency

Personality Effect:

Higher Personality Resistance

---

## Current

Characteristics:

- Adapts to circumstances
- Balances stability and change
- Responds to context

Personality Effect:

Situational Personality Resistance

---

# 3. Drive (Memory Weighting)

Drives determine which experiences exert the greatest influence on personality development.

Drive is determined by Karael.

Drive influences which experiences produce the strongest personality drift.

Different Drives assign greater weight to different categories of memories.

Determined by **Karael's Orbital Region**. It determines which categories of experiences produce the strongest personality drift.

| Orbital Region | Drive | Memory Affinities |
| :--- | :--- | :--- |
| Region I | **Growth** | Family, Teaching, Community |
| Region II | **Conflict** | Rivalry, Victory, Failure |
| Region III | **Discovery** | Travel, Research, Mystery |
| Region IV | **Reflection** | Beauty, Spirituality, Loss |
| Region V | **Renewal** | Migration, Healing, New Beginnings |

Drive is determined by Karael's orbital position at birth.

Karael's 17-Turn orbit is divided into five celestial regions.


Because Karael completes its orbit every 17 Turns, Drive distribution shifts continuously throughout the calendar.

## Growth

Values:

- Learning
- Improvement
- Mentorship

Memory Affinities:

- Family
- Teaching
- Community

---

## Conflict

Values:

- Competition
- Challenge
- Achievement

Memory Affinities:

- Rivalry
- Victory
- Failure

---

## Discovery

Values:

- Exploration
- Curiosity
- Knowledge

Memory Affinities:

- Travel
- Research
- Mystery

---

## Reflection

Values:

- Understanding
- Wisdom
- Meaning

Memory Affinities:

- Beauty
- Spirituality
- Loss

---

## Renewal

Values:

- Adaptation
- Recovery
- Reinvention

Memory Affinities:

- Migration
- Healing
- New Beginnings

---

# Personality Integration

Aethersigns influence personality through three mechanisms.

## Domain Affinity

State influences which personality domains naturally exert greater influence throughout development.

## Personality Resistance

Modality influences how easily personality changes in response to experiences.

## Memory Weighting

Drive influences which memories produce stronger personality drift.

---

# Development Flow

Birth
    ↓
Aethersign
    ↓
Initial Tendencies
    ↓
Experiences
    ↓
Memories
    ↓
Personality Drift
    ↓
Personality Development

Aethersigns influence predispositions.

Life experiences shape the individual.

---

# Implementation / Notes

*   **Generation:** At birth, the simulation captures the Phase, Selene phase, and Karael position to lock the Aethersign.
*   **Integration:** These values are passed to the `PersonalitySystem` to initialize the creature's `PersonalityResistance` and `MemoryWeight` multipliers.
*   **Persistence:** The Aethersign is a permanent part of the creature's identity and does not change, even if the creature moves to a different region or world.

## Personality Modifiers

Aethersigns should influence:

- Initial personality values
- Personality Resistance
- Memory weighting calculations
- Domain affinity calculations

Aethersigns should never directly determine:

- Actions
- Careers
- Relationships
- Beliefs
- Goals

These outcomes should emerge naturally through simulation.

---

# Future Expansion

Potential future systems:

- Cultural astrology traditions
- Religious interpretations
- Compatibility systems
- Astrological events
- Celestial festivals
- Rare alignment effects

---

# FILE: docs/02_creatures/personality.md

# Personality System
**Description:** Personality development, aging, emotional domains, and emergent behavioral systems for Aetherbourne creatures
**Last Updated:** 2026-06-21
---

## Overview
Personality in Aetherbourne is a layered, developmental architecture. It represents a creature's long-term behavioral tendencies that emerge from a combination of celestial predispositions (**Aethersigns**), genetic inheritance, and lived experience.

---

## The Aethersign Layer (Predispositions)
Every creature is born under an **Aethersign**, a celestial imprint that provides "discreet influence" on their psychological development.

*   **State (Foundational Nature):** Defines **Domain Affinity**, providing a -10% reduction in Personality Resistance for traits within specific domains.
*   **Modality (Developmental Pace):** Directly modifies the **Personality Resistance** (PR) stat (e.g., Catalyst -20% PR).
*   **Drive (Memory Weighting):** Determines which categories of experiences produce the strongest **Personality Drift** (+25% weight).

---

## Personality Development by Age
As creatures age, new psychological domains "unlock" and mature. While a domain becomes active at a certain age, its **foundations** are laid by earlier domains.

| Age Stage | Active Domains | Foundation For... |
| :--- | :--- | :--- |
| **Infant** | Temperament | Emotional Regulation |
| **Toddler** | Socialization | Interaction & Morals |
| **Child** | Cognition, Emotional | Purpose |
| **Teenager** | Identity, Interaction | Perspective |
| **Young Adult** | Purpose, Morals | Legacy |
| **Adult** | Perspective | - |
| **Elder** | Legacy | - |

---

## Personality Domains
Each domain contains two unique axes ranging from **-100 to 100**.

### 1. Temperament (Infant)
*Innate biological responses to stimuli.*
#### Sensitivity
`Dull (-100) ↔ Acute (+100)`
#### Baseline Mood
`Somber (-100) ↔ Cheerful (+100)`

### 2. Socialization (Toddler)
*Early attachment and group-entry behaviors. Bridges the gap to adult Morals.*
#### Attachment Style
`Avoidant (-100) ↔ Secure (+100)`
#### Trust Baseline
`Skeptical (-100) ↔ Trusting (+100)`

*Note: High Trust Baseline and Secure Attachment form the "Proto-Morals" that govern early social cooperation before the full Morals domain unlocks.*

### 3. Cognition (Child)
#### Inquiry
`Passive (-100) ↔ Inquisitive (+100)`
#### Mental Focus
`Fluid (-100) ↔ Concentrated (+100)`

### 4. Identity (Teenager)
#### Conformity
`Rebellious (-100) ↔ Compliant (+100)`
#### Ego
`Modest (-100) ↔ Vain (+100)`

### 5. Emotional (Child+)
#### Impulse Control
`Volatile (-100) ↔ Restrained (+100)`
#### Resilience
`Fragile (-100) ↔ Robust (+100)`

### 6. Interaction (Teenager+)
#### Social Energy
`Solitary (-100) ↔ Gregarious (+100)`
#### Influence Strategy
`Submissive (-100) ↔ Dominant (+100)`

### 7. Purpose (Young Adult+)
#### Ambition
`Content (-100) ↔ Driven (+100)`
#### Grit
`Fickle (-100) ↔ Tenacious (+100)`

### 8. Morals (Young Adult+)
*Internalized ethical framework. Influenced by early Socialization.*
#### Empathy
`Callous (-100) ↔ Empathetic (+100)`
#### Integrity
`Opportunistic (-100) ↔ Principled (+100)`

### 9. Perspective (Adult+)
#### Adaptability
`Rigid (-100) ↔ Flexible (+100)`
#### Horizon
`Parochial (-100) ↔ Universal (+100)`

### 10. Legacy (Elder)
#### Preservation
`Transient (-100) ↔ Ancestral (+100)`
#### Mentorship
`Self-Centered (-100) ↔ Altruistic (+100)`

---

## Personality Drift & Resistance
Personality "drifts" based on the accumulation of memories, filtered through the creature's Aethersign and current age.

### Personality Resistance (PR)
**Personality Resistance** represents the "inertia" of a creature's character.
*   **Base Resistance:** Starts at 10.0 for Infants.
*   **Age Scaling:** PR increases by +5.0 per Age Stage.
*   **Modality Modifier:** Applied to the total PR (e.g., Anchor = ×1.2).
*   **Domain Affinity:** If a trait belongs to a domain affined to the creature's **State**, PR for that trait is ×0.9.

### Personality Drift Formula
```text
PersonalityChange = (MemoryStrength × EmotionalWeight × AxisModifier × DriveWeight) / PR
```

---

## Design Philosophy
*   **Slow Emergence:** Personality is a trailing indicator of a life lived.
*   **Layered Complexity:** Adult behavior is the result of infant temperament being filtered through years of socialization and cognition.
*   **Stability with Age:** The older a creature gets, the more "set in its ways" it becomes.

## Implementation / Notes
*   **Storage:** Store Aethersign (State, Modality, Drive) permanently in the creature's data block.
*   **Processing:** Run personality drift calculations during the "Sleep" or "Long Rest" state.


---

# FILE: docs/02_creatures/stats.md

# Stats System

**Description:** Core stats, derived stats, and hidden stats that drive behavior and skill growth for creatures in Aetherbourne
**Last Updated:** 2026-06-21

---

## Overview

Stats are layers of abstraction that help drive behavior, skill growth, personality development, and emergent outcomes.

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

## Advanced Stats

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

## Endurance

How long a creature can physically perform.

Used by:

* Hunting
* Long travel
* Combat duration
* Labor

## Prowess

Physical effectiveness.

Used by:

* Fighting
* Athletics
* Physical skill learning

## Finesse

Precision and awareness combined.

Used by:

* Crafting
* Gathering
* Tracking
* Tool mastery

## Conviction

Mental clarity and awareness.

Used by:

* Decision making
* Leadership
* Social influence
* Maintaining goals

## Vitality

Overall resilience.

Used by:

* Recovery
* Disease resistance
* Survival

## Hidden Stats

These are where things become really interesting.

These shouldn't be visible to players.

Instead they should influence emergent behavior.

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

## The interesting part

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

---

## Design Philosophy

Stats should clearly distinguish base attributes, derived competencies, and hidden emergent factors.

## Core Concepts

- Core stats as primary creature attributes
- Advanced stats as computed values
- Hidden stats as emergent behavior influencers

---

## Implementation / Notes

* Keep core stats explicit and derive others on demand for clarity in simulation code.

---

# FILE: docs/02_creatures/needs.md

# Needs System
**Description:** Biological and psychological drivers for creature behavior in Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Needs are the fundamental drivers of all behavior. They create "pressure" that the creature seeks to alleviate through actions.

---

## Need Urgency & Weighting
The "Decision Pressure" for any need is calculated as:
```text
Pressure = (Urgency × BasePriority) × PersonalityWeight
```
*   **Urgency (0-100):** How much the need is currently neglected.
*   **BasePriority:** Survival needs have higher multipliers (3.5+) than psychological ones (1.0).
*   **PersonalityWeight:** Modified by the creature's traits (e.g., *Ambitious* creatures prioritize *Purpose*).

---

## The Need Hierarchy

| Need | BasePriority | Behavioral Manifestation |
| :--- | :--- | :--- |
| **Health** | 5.0 | Avoidance of hazards, seeking medicine/rest. |
| **Thirst** | 4.0 | Searching for water sources, migration to rivers. |
| **Hunger** | 3.5 | Foraging, hunting, or trading for food. |
| **Energy** | 3.0 | Sleeping, resting, or reducing labor intensity. |
| **Safety** | 2.5 | Seeking shelter, grouping with others, building defenses. |
| **Belonging** | 1.5 | Socializing, gift-giving, participating in rituals. |
| **Curiosity** | 1.2 | Exploring unknown tiles, inspecting new objects. |
| **Purpose** | 1.0 | Pursuing long-term goals, training skills, building legacy. |

---

## Need States
Urgency levels are categorized into states that trigger specific behavioral AI modes:
*   **Satiated (0-20):** Need is satisfied; creature focuses on low-priority psychological goals.
*   **Stable (21-50):** Need is present but not pressing.
*   **Pressing (51-80):** Creature begins actively searching for solutions.
*   **Critical (81-100):** Creature enters "Survival Mode," abandoning all non-essential goals to satisfy the need.

---

## Design Philosophy
*   **Biological Realism:** Survival needs are mathematically "louder" than psychological ones.
*   **Emergent Motivation:** Behavior emerges from the competition between these pressures.


---

# FILE: docs/02_creatures/emotions.md

# Emotion System
**Description:** Emotional state, processing, and influence systems for Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Emotions are the subjective bridge between objective events and lasting memories. They determine how a creature perceives and reacts to the world.

---

## The Emotional Pipeline
`Need → Goal → Action → Event → Interpretation → Emotion → Memory`

---

## Emotional Intensity
```text
EI = EventSeverity × PersonalRelevance × PersonalityAmplifier
```
*   **EventSeverity:** Objective impact (0-100).
*   **PersonalRelevance:** Impact on the creature's current state.
*   **PersonalityAmplifier:** Modified by *Sensitivity* and *Emotional Reactivity*.

---

## Emotional Taxonomy
Emotions are categorized by their influence on behavioral AI.

### Primary Emotions (Immediate Action)
*   **Fear:** Triggers `Flight` or `Hide` behaviors.
*   **Anger:** Triggers `Aggression` or `Assert` behaviors.
*   **Joy:** Triggers `Socialize` or `Celebrate` behaviors.
*   **Sadness:** Triggers `Withdraw` or `Seek Comfort` behaviors.

### Secondary Emotions (Long-term Social)
*   **Pride / Shame:** Influences the *Ego* axis and social status.
*   **Admiration / Contempt:** Influences *Relationship Points* and social energy.
*   **Guilt / Gratitude:** Influences *Trust* and future *Integrity* decisions.

---

## Subjective Interpretation
The same event produces different emotions based on the creature's perspective.
*   **Victor:** Pride / Joy.
*   **Loser:** Shame / Anger.
*   **Witness:** Admiration / Fear (influenced by *Empathy* trait).

---

## Design Philosophy
*   **Subjectivity:** Events are facts; emotions are interpretations.
*   **Volatility:** Emotions are short-lived but drive long-term character change via memories.


---

# FILE: docs/02_creatures/memories.md

# Memory System
**Description:** Memory formation, decay, and influence on personality for Aetherbourne
**Last Updated:** 2026-06-21
---

## Overview
Memories are the stored records of significant emotional experiences. They are the primary driver of **Personality Drift**.

---

## Memory Formation
A memory is formed when the **Emotional Intensity** of an event exceeds the creature's storage threshold.
```text
MemoryStrength = EmotionalIntensity × DriveWeight
```
*   **DriveWeight:** If the event category matches the creature's **Aethersign Drive**, the memory is 25% stronger.

---

## Memory Taxonomy
*   **Episodic:** Records of specific events (e.g., "The time I found the cave").
*   **Semantic:** Generalized knowledge derived from events (e.g., "Caves are dangerous").
*   **Procedural:** Skills and habits learned through repetition (e.g., "How to forge iron").

---

## Memory Decay & Persistence
All memories decay over time, but at different rates.
```text
CurrentStrength = InitialStrength × e^(-DecayRate × Time)
```
*   **Minor Events:** High DecayRate (fades in days).
*   **Traumatic/Significant Events:** Low DecayRate (may last a lifetime).

---

## Memory Retrieval & Association
Memories are not static; they are retrieved when the creature encounters similar stimuli.
*   **Association:** Encountering a "Snake" may trigger a memory of a "Snake Bite," spiking current *Fear* levels.
*   **Recall:** High *Cognition* traits increase the accuracy and speed of memory retrieval.

---

## Influence on Personality
Memories provide "drift" values that accumulate over time.
`DriftContribution = CurrentStrength × AxisModifier`

---

## Design Philosophy
*   **Selective Retention:** The simulation only keeps what matters.
*   **Dynamic History:** As memories decay, their influence on future decisions weakens, but their effect on the *past* personality drift is permanent.


---

# FILE: docs/02_creatures/actions.md

# Actions System

**Description:** Reusable, modular creature actions that bridge **Needs → Goals → Action → Events → Outcomes**
**Last Updated:** 2026-06-21

---

## Overview

Actions are the executable layer of the creature simulation.

They translate:
- **Needs/urgency** (from `needs.md`) into **Goals** (planner output)
- **Goals** into **Actions** (what the creature does)
- **Actions** into **Events/Outcomes** (what the world records)
- **Events** into **Emotions → Memories → Personality drift** (from the creature pipeline)

Actions **do not modify personality directly**.

Instead:

```text
Action
↓ (preconditions)
Execute
↓ (outcomes)
Event(s)
↓
Emotion
↓
Memory
↓
Personality drift
```

## Design Goals

1. **Simple and clear**: an action template should be readable in seconds.
2. **Versatile**: one action can support variants (tool/target/difficulty) without rewriting everything.
3. **Consistent with events**: actions emit standardized event categories + scales.
4. **Data-driven**: the same action definition should drive AI planning and simulation execution.

## Core Concepts

## ActionCategory
Group actions into domains so the planner can reason globally.

```csharp
public enum ActionCategory
{
    Survival,      // food/water/health maintenance
    Work,          // labor/farming/building
    Exploration,   // scouting/learning/locating
    Gathering,     // flora/minerals resources
    Crafting,      // tool/item production
    Combat,        // attack/defend/fight
    Escape,        // flee/evade
    Social,        // talk/share/mentor
    Economic,      // trade/theft/assist exchanges
    Rest,          // sleep/rest/heal-by-time
    Culture,       // rituals/festivals/ceremonies
    Magic          // spellcasting
}
```
```csharp
public enum AltActionCategory
{
  Movement,        // walk/run/jump/climb/carry/crouch/swim
  Interaction,     // inspect/pick up/use/speak/trade/fight
  Social,          // befriend/persuade/lie/intimidate/bond/appease/rally/reproduce/flee/steal/give/observe/conceal 
  Trade,           // haggle/deliver/manage
  Combat,          // attack/defend/dodge/equip or swap/feint/counter
  Tactical,        // wait/prepare/distract/camo/ambush/track/strageize/scout
  Utility,         // craft/heal/rest/signal
  Construction,    // build/repair/survey/excavate/fortify/decorate
  Resource,        // plant/harvest/tame/hunt/fish/mine/gather/trap/preserve
  Crafting,        // forge/carve/weave/tinker/refine/assemble
  Consumable,      // cook/bake/brew
  Daily,           // clean/organize/care/teach
  Magic,           // mix/cast spell/enchant/divine
  Culture,         // preform/write/study/paint
  Cognitive        // desire/remember/decide/plan/forget/learn
}

## Goal Link
Each action declares which needs/goals it can satisfy.

Actions should not “decide urgency” (that’s the needs arbitration). Instead, they declare compatibility:

- **Consumes or restores**: Hunger/Thirst/Energy/Health/Belonging/Purpose/Fulfillment
- **Advances**: Exploration discoveries; crafting progress; relationship progress

## Standard Action Definition Template

Every action definition should follow the same structure.

## 1) Purpose
- One short paragraph describing what the creature is trying to do.
- Which needs/goals it is intended to satisfy.

## 2) Requirements
Two types:

### MustExist (world facts)
- Target availability/type
- Terrain/biome/water/hazard thresholds
- Line-of-sight or adjacency rules

### MustHave (actor capabilities/resources)
- Relevant skills thresholds
- Tools required (or allowed)
- Minimum relationships (for social/economic actions)
- Minimum current health/energy to attempt

## 3) Results
Must specify:

### Outcomes on Success
- State changes (health/energy/hunger/etc.)
- Inventory changes (+food, −tool durability)
- Relationship changes (trust, respect)
- Discovery/knowledge seeds
- Hazard exposure or mitigation

### Outcomes on Failure
- What partial progress happens (if any)
- Wasted time/costs
- Injury/negative state changes (if applicable)
- Optional fear/anger emotional drivers via event emission

### Events emitted
List event categories + recommended visibility and scale.

## Action Lifecycle (Execution Model)

Actions run through a common lifecycle so they plug into the event/emotion/memory pipeline.

```text
Action Start
↓ Precondition checks
↓ Plan parameters
   (target, tool, route, timing)
↓ Execute (duration + movement + consumes)
↓ Resolve (success/failure)
↓ Apply Outcomes (state/inventory/relationships)
↓ Emit Event(s)
↓ Finish / cooldown / next decision
```

## Action duration and tick model
To keep docs simple, define actions in one of these execution styles:

- **Instant**: single resolution (share a piece of food, drink from a nearby source)
- **Timed**: duration-based (forage/mine/build/craft)
- **Ongoing**: continues while condition remains (harvest until depleted, escort until destination)

## Standard Outcome Tags

To keep actions versatile without huge prose, outcomes should use a small vocabulary.

## StateChange
- **Health Δ**
- **Energy Δ**
- **Stamina Δ**
- **Hunger Δ**
- **Thirst Δ**
- **Bladder discomfort / urgency Δ**

## InventoryChange
- **+Food / −Food**
- **+Flora / +Minerals**
- **−ToolDurability**
- **+Parts / +Materials**

## RelationshipChange
- **Trust Δ** (relationship-specific)
- **Respect Δ**

## Knowledge / Discovery
- **MemorySeed** strength/severity band (e.g. 20..60)
- **LearnedFact** / **MapPin** / **EncounterTag**

## Hazard Exposure
- Infection/poison/radiation/curse exposure checks
- Injury risks (falls, bites, heat, cold)

## Standard Event Emission Rules

Actions should emit event(s) rather than directly causing emotional change.

## Recommended mapping
- **Gather / Hunt / Mine / Build** → usually **Biological**, **Environmental**, or **Economic** events
- **Attack / Defend** → **Conflict** events
- **Share / Socialize / Mentor** → **Social** events
- **Rest / Sleep / Heal** → **Personal** + **Biological** (injury recovery) events
- **Explore / Discover** → **Discovery** events

## Scale and severity
Use these ranges consistently:
- **Severity**: `0..100` (minor to catastrophic)
- **Scale**:
  - Individual / Family / Group / Settlement / Regional / Global

If an action has failure that causes injury, severity should skew moderate:
- typical failure injury: **15..55**

## Action Variants (Versatility)

Instead of redefining actions, use variants as parameters.

Each action supports:
- **ToolVariant** (barehand / hand-tool / specialized tool)
- **TargetVariant** (deer/fish/herb/ore/ruin node)
- **DifficultyVariant** (safe/normal/dangerous/cursed)

The action template remains identical; only requirements/outcomes/event severity bands shift.

## Core Action Set (Start Here)

Below are initial actions designed to cover most gameplay loops.

## 1) Gather (Flora/Minerals)

### Purpose
Collect nearby resource nodes (plants or geological materials) for food, crafting, alchemy, or construction.

Supports:
- Hunger/Thirst (if food/water flora)
- Work and economic goals (materials)
- Discovery (learning resource locations)

### Requirements
**MustExist**
- Target resource node within interaction range
- Target type is compatible with allowed gather modes (flora/minerals)

**MustHave**
- Dexterity + relevant tool use skill threshold
- Appropriate tool (optional for “basic” gather; required for quality mining/cutting)

### Results
**Success outcomes**
- `+InventoryChange`: harvested flora/minerals (quantity depends on tool + skill)
- `−ToolDurability` (if tool used)
- `MemorySeed`: mild discovery memory (severity band **10..35**)
- Optional hazard exposure check (poisonous spines, contaminated deposit)

**Failure outcomes**
- `−Energy` / `−Stamina` (small)
- `MemorySeed` optional (if failure is costly): **15..40**
- Optional injury if target is hazardous: `Health −Δ`

**Events emitted**
- Category: **Economic** (trade value context) and/or **Environmental** (hazard exposure)
- Scale: **Individual**
- Severity: **0..60** (higher when injury/hazard)

## 2) Forage (Seasonal Gathering)

### Purpose
Search and collect small edible or useful items from the environment without a fixed node.

Supports:
- Hunger
- Thirst (if water sources exist)
- Exploration

### Requirements
**MustExist**
- Forage-able conditions in the current biome/season
- Suitable terrain (not fully hazardous unless specialized)

**MustHave**
- Curiosity/Perception threshold for spotting targets
- Low tool needs (hand gather) or optional simple tools

### Results
**Success outcomes**
- `+Food/−Food` inventory depending on consumption plans
- `Energy −Δ` (activity cost)
- `MemorySeed`: “where to forage next time” (severity band **10..40**)

**Failure outcomes**
- `−Energy` and `Hunger may remain high`
- Potential mild injury if forage in hostile hazard layers

**Events emitted**
- Category: **Discovery** (location/biome knowledge)
- Category: **Biological** (predation/harassment if encountered)
- Scale: **Individual**

## 3) Drink (From Water Source)

### Purpose
Consume water to reduce thirst (and optionally improve recovery if safe and clean enough).

### Requirements
**MustExist**
- WaterFeature present (stream/lake/spring/oasis/etc.)
- Safety check: hazard layer or contamination may require “safe drink” variant

**MustHave**
- Enough energy to perform drinking action

### Results
**Success outcomes**
- `Thirst Δ −` (amount depends on water quality)
- `Energy` small recovery if clean water
- Optional `MemorySeed`: safe source remembered (severity **5..25**)

**Failure outcomes**
- `Thirst remains high`
- Possible `Health −Δ` if contaminated/miasmic

**Events emitted**
- Category: **Environmental** (contamination exposure) and/or **Personal**
- Scale: **Individual**
- Severity: **0..70** (higher if poisoning)

## 4) Hunt (Predation/Chase/Capture)

### Purpose
Chase, track, and capture prey for food or resources.

### Requirements
**MustExist**
- Prey detected within tracking radius
- Pathing possible (terrain/hazard constraints)

**MustHave**
- Perception + stamina
- Combat skill threshold (for active hunting)
- Tool variant optional (trap/spear/club)

### Results
**Success outcomes**
- `+InventoryChange`: meat/edibles (quantity depends on success margin)
- `Hunger Δ −`
- Possible injury from struggle (`Health −Δ`)
- `MemorySeed`: “effective strategy” (severity **20..65**)

**Failure outcomes**
- `Energy −Δ`, `Stamina −Δ`
- Optional `Fear/anger` event trigger via fight interruption

**Events emitted**
- Category: **Conflict** (if fight occurs)
- Category: **Biological** (predation result)
- Scale: **Individual**
- Severity: **0..85**

## 5) Mine (Geological Resource Extraction)

### Purpose
Extract minerals/ores from geological nodes.

### Requirements
**MustExist**
- Ore node within interaction range
- Terrain supports safe access (depth/hazard constraints)

**MustHave**
- Tool quality and relevant mining skill threshold

### Results
**Success outcomes**
- `+InventoryChange`: minerals/ore fragments
- `−ToolDurability`
- `MemorySeed`: efficient vein memory (severity **10..40**)
- Optional hazard exposure: radiation/curse/volatile rock

**Failure outcomes**
- `−Energy`, `Health −Δ` if rock failure
- Possible cave-in trigger (if unstable tectonic activity)

**Events emitted**
- Category: **Environmental** (hazard/cave-in)
- Category: **Economic** (resource production)
- Scale: **Individual**
- Severity: **0..90**

## 6) Rest (Recover by Time)

### Purpose
Recover energy and reduce fatigue.

### Requirements
**MustExist**
- Safe resting conditions (hazard layer check / threat proximity)

**MustHave**
- None beyond basic survival ability

### Results
**Success outcomes**
- `Energy Δ +`
- `Stamina Δ +`
- `MemorySeed` minimal (severity **0..10**)

**Failure outcomes**
- Rest interrupted: `Energy gain reduced`
- Optional exposure to nearby conflict events

**Events emitted**
- Category: **Personal**
- Scale: **Individual**
- Severity: usually low **0..25**

## 7) Heal (Medicine / Care)

### Purpose
Apply medicine, bandages, or rest to improve health.

### Requirements
**MustExist**
- Injured state present OR preventive care goal
- Medicine resource available OR basic bandaging possible

**MustHave**
- Medicinal skill threshold (or tool variant)
- Optional relationship requirement for caring (social vs professional)

### Results
**Success outcomes**
- `Health Δ +` (amount depends on medicine potency)
- Possible removal/mitigation of poison debuffs (if applicable)
- `MemorySeed`: “I was helped” (severity **15..55**)

**Failure outcomes**
- Less effective healing
- Possible infection worsening (if medicine quality poor or contamination)

**Events emitted**
- Category: **Biological** (recovery) and **Social** (if by another creature)
- Scale: **Individual**

## 8) Explore (Scout / Map / Discover)

### Purpose
Move through unknown or partially known territory to find resources, hazards, routes, and settlements.

### Requirements
**MustExist**
- Unscouted tiles or interest points

**MustHave**
- Energy > minimum
- Perception threshold for meaningful discoveries

### Results
**Success outcomes**
- `MemorySeed`: discovery memories (severity **10..45**)
- Possible `Action outcome`: mark route, unlock knowledge nodes

**Failure outcomes**
- Missed opportunities
- If hazard encountered: `Health −Δ` or `Energy −Δ`

**Events emitted**
- Category: **Discovery**
- Category: **Environmental** (if hazards encountered)
- Scale: **Individual**
- Severity: **0..80**

## 9) Trade (Exchange Resources)

### Purpose
Exchange items/resources with another entity or settlement.

### Requirements
**MustExist**
- Trade partner available
- Market availability (if you model it)

**MustHave**
- Relationship trust threshold OR social influence skill
- Items in inventory

### Results
**Success outcomes**
- `InventoryChange`: trade swap
- `RelationshipChange`: trust/respect Δ
- `MemorySeed`: “deal went well” (severity **10..50**)

**Failure outcomes**
- Transaction aborted
- Possible social conflict event if attempted deceit/stealing

**Events emitted**
- Category: **Economic** and **Social**
- Scale: **Settlement** or **Individual** (depending on partner)
- Severity: **0..70**

## 10) Socialize (Share / Talk / Mentor)

### Purpose
Interact to improve belonging, trust, and cooperative bonds.

### Requirements
**MustExist**
- Another creature (or group member) available
- Social context permits interaction

**MustHave**
- Minimum energy
- Personality/social skill influence threshold

### Results
**Success outcomes**
- `RelationshipChange`: trust/respect Δ
- `Belonging` maintenance indirectly via relationship system
- `MemorySeed`: shared experience severity **10..55**

**Failure outcomes**
- Relationship change negative (miscommunication)
- Possible conflict event in high threat context

**Events emitted**
- Category: **Social**
- Scale: **Family/Group/Settlement** depending on participants
- Severity: **0..75**

## 11) Attack (Combat Resolution Wrapper)

### Purpose
Perform an aggressive action intended to injure, disable, or deter a target.

### Requirements
**MustExist**
- Target within combat range
- Combat conditions valid (line-of-sight / adjacency)

**MustHave**
- Combat skill threshold
- Weapon/tool variant availability
- Health/energy minimum

### Results
**Success outcomes**
- `Health −Δ` on target
- `Stamina −Δ` attacker
- Optional status effects (if you model them later)
- `MemorySeed` for both sides based on severity **20..90**

**Failure outcomes**
- Attacker injury risk
- Possible return aggression event

**Events emitted**
- Category: **Conflict**
- Scale: **Individual/Group**
- Severity: **10..100**

## 12) Flee (Escape / Evade)

### Purpose
Avoid danger by disengaging and moving toward safety.

### Requirements
**MustExist**
- Threat source present
- Escape route exists (pathing)

**MustHave**
- Energy > minimum
- Fear/low threat tolerance interacts via emotion system (planner picks flee)

### Results
**Success outcomes**
- `Energy −Δ` but reduces future injury risk
- Optional `MemorySeed`: survival/trauma (severity **15..80**)

**Failure outcomes**
- Panic risk: `Health −Δ`
- Potential conflict escalation events

**Events emitted**
- Category: **Conflict** and/or **Environmental**
- Scale: **Individual**
- Severity: **0..95**

## Extending the Action Library

To add actions without breaking clarity:
1. Start with the **template** sections: Purpose → Requirements → Results.
2. Use **variants** for tool/target/difficulty.
3. Keep outcomes tagged and consistent.
4. Emit events using the same severity/scale approach from `events.md`.

## Consistency Checklist

When writing a new action, confirm:
- [ ] It does not directly modify personality
- [ ] It declares clear preconditions
- [ ] It defines success and failure outcomes
- [ ] It emits one or more event(s)
- [ ] Outcomes are expressible with outcome tags
- [ ] It can be parameterized via variants

---

## Design Philosophy

The actions system is designed to stay modular, data-driven, and aligned with the event/emotion pipeline.

## Core Concepts

- Action definitions use Purpose, Requirements, and Results
- Outcomes are expressed with standardized tags
- Actions emit events rather than directly modifying personality

---

## Implementation / Notes

* Keep new actions consistent with existing templates and variant patterns.

---

# FILE: docs/03_simulation/time.md

# Time System

**Description:** Document summary placeholder
**Last Updated:** 2026-06-21

---

## Overview

The Time System defines how time progresses throughout the simulation.

Time is measured through recurring natural cycles including the passage of light and darkness, seasonal transitions, annual calendar progression, and the movements of the moons Selene and Karael.

These cycles influence creature behavior, agriculture, ecology, scheduling systems, astrology, culture, and long-term world simulation.

---

## Design Philosophy

Time should provide a predictable simulation framework while still feeling natural and alive.

The calendar and celestial systems are designed to:

- Create meaningful seasonal variation
- Support scheduling and long-term planning
- Drive agricultural and ecological systems
- Enable astrology and cultural traditions
- Provide deterministic simulation timing
- Allow creatures to reason about recurring cycles

The simulation should remain deterministic when provided the same seed and inputs.

## Core Concepts

- Tick rate and simulation step
- Day and night progression
- Seasonal cycles
- Calendar and date tracking
- Celestial body simulation
- Event scheduling
- Astrological timing

## Time Units

In Aetherbourne, one simulation tick is equivalent to one minute.

| Common Term | Aetherbourne Term |
| --- | --- |
| Minute | Moment |
| Hour | Bell |
| Day | Turn |
| Week | Cycle |
| Month | Phase |
| Year | Span |

## Calendar Structure

- 60 Moments per Bell
- 24 Bells per Turn
- 10 Turns per Cycle
- 34–38 Turns per Phase
- 10 Phases per Span
- 360 Turns per Span

The calendar year contains ten Phases whose lengths vary slightly to create a more natural rhythm.

## Times of Day

| Period | Description |
| --- | --- |
| Firstlight | Dawn |
| Brightrise | Morning |
| Highsun | Midday |
| Lightwane | Afternoon |
| Duskbloom | Evening |
| Dreamfall | Early Night |
| Starveil | Midnight |
| Twilitide | Late Night |

These periods are used culturally and socially throughout the world.

Most creatures think in Bells and named periods rather than precise numerical time.

## Phases

The ten annual Phases in order are:

| **Phase** | **Season** |
| --- | --- |
| Brigide | Voidgleam |
| Imbolka | Seedwake |
| Floralis | Seedwake |
| Lithara | Sunreach |
| Heliax | Sunreach |
| Aestium | Sunreach |
| Mabonel | Amberwane |
| Ceresio | Amberwane |
| Yulith | Voidgleam |
| Hibernis | Voidgleam |

## Seasons

The world experiences four primary seasons.

## Seedwake

**Phases**: Imbolka, Floralis

The season of renewal.

Snow retreats, rains return, and new growth begins.

Associated with beginnings, fertility, and opportunity.

## Sunreach

**Phases**: Lithara, Heliax, Aestium

The season of abundance.

Long days, warm weather, and rapid growth.

Associated with prosperity, energy, and achievement.

## Amberwane

**Phases**: Mabonel, Ceresio

The season of harvest.

Growth slows and resources are gathered for the colder months.

Associated with preparation, gratitude, and reflection.

## Voidgleam

**Phases**: Brigide, Yulith, Hibernis

The season of long nights.

Cold settles across the land while stars and moonlight dominate the sky.

Associated with mystery, dreams, memory, and the unseen.

The Span begins during Brigide.

## Celestial Bodies

## Selene

The Greater Moon.

Domains

- Dreams
- Memory
- Reflection
- Community

Characteristics

- Large
- Pale
- Slow-moving

Orbital Cycle

29 Turns

## Karael

The Lesser Moon.

Domains

- Change
- Instinct
- Omens
- Transformation

Characteristics

- Small
- Silver-blue
- Swift-moving

Orbital Cycle

17 Turns

Its shorter orbit causes constantly shifting alignments with Selene.

These alignments form the foundation of Aetherbourne astrology.

## Moon Phases

Both moons pass through eight visible phases.

1. New
2. Waxing Crescent
3. First Quarter
4. Waxing Gibbous
5. Full
6. Waning Gibbous
7. Last Quarter
8. Waning Crescent

Because Selene and Karael move at different speeds, their relative positions are constantly changing.

Rare alignments may occur only once every several Spans.

### Rare Celestial Events

#### Convergence

Both moons are Full.

Associated with destiny, leadership, and major societal change.

#### Veilnight

Both moons are New.

Associated with mystery, prophecy, dreams, and spiritual significance.

#### Split Alignment

One moon is Full while the other is New.

Associated with contradiction, innovation, upheaval, and transformation.

## Date Format

Dates are commonly written as:

«Third Turn of Heliax, 214th Span»

or

«Heliax, Third Turn, 214th Span»

Informally, most creatures simply refer to the current Phase and Turn.

---

## Implementation / Notes

## Simulation Time

1 Tick = 1 Moment
60 Ticks = 1 Bell
24 Bells = 1 Turn

## Event Scheduling

Examples:

- Daily routines
- Seasonal crop growth
- Creature aging
- Festival triggers
- Moon phase transitions
- Weather updates

Example Event Hooks

OnTurnStarted
OnTurnEnded

OnPhaseStarted
OnPhaseEnded

OnSeasonStarted
OnSeasonEnded

OnMoonPhaseChanged

OnSpanStarted
OnSpanEnded

## Clock API

The time system should expose:

- Current Moment
- Current Bell
- Current Turn
- Current Cycle
- Current Phase
- Current Season
- Current Span
- Current Selene Phase
- Current Karael Phase

These values should be accessible by AI, simulation systems, event schedulers, world generation systems, and gameplay systems.
