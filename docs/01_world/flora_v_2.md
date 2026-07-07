# Flora and Botanical Systems (Legacy / Not Canonical)

***

> Split into modular docs under `docs/01_world/flora/`.
> This file is kept as a legacy reference.

## 1. Overview

This system manages all plant species, vegetation, herbs, crops, and botanical materials that form the foundation of alchemy, medicine, sustenance, and magical systems in the game world. Flora integrates with the global macro drivers to procedurally generate contextual plants tailored to environmental conditions across 15 distinct biomes. Custom 2D rendering properties enable pixel-perfect sprite composition using a modular morphology matrix.

***

## 2. Generation Rules

This layer defines how flora is produced by the simulation. It contains logic, world-state inputs, lifecycle behavior, growth math, spread behavior, and mutation handling.

### 2.1 Macro Global Drivers

All flora generation references normalized environmental parameters ranging from 0.0 to 1.0:

- **Latitude:** 0.0 = Equator/Hot → 1.0 = Poles/Cold. Drives thermal and biome selection.
- **Altitude:** 0.0 = Sea Level → 1.0 = Mountain Peaks. Dictates atmospheric pressure and growth constraints.
- **Humidity:** 0.0 = Arid → 1.0 = Saturated. Determines water dependency and plant form.
- **Distance From Water:** 0.0 = Shoreline → 1.0 = Landlocked. Drives aquatic vs. xerophytic traits.
- **Depth Layer:** 0 = Surface, 1 = Subterranean, 2 = Mantle. Determines light level and biome type.
- **System Flags:** `IsMagicalAnomaly` and `IsContaminated` trigger special mystical or toxic mutations.

### 2.2 Growth Model

Plant development is an ongoing cycle driven by resource matching. Instead of running expensive timers for every single plant, growth cycles are calculated using a deterministic delta tick scaled by matching environmental attributes.

The growth rate formula is:

$$
G_{\text{Delta}} = G_{\text{Base}} \times H_{\text{Soil}} \times W_{\text{Availability}} \times L_{\text{Match}}
$$

Where:

- **GBase:** The static growth baseline defined by the species taxonomy GrowthRate.
- **HSoil:** Soil match efficiency computed by matching the plant’s SoilPreference with the local tile Fertility.
- **WAvailability:** Local hydrology saturation level, scaled by the species-specific WaterDependency profile.
- **LMatch:** Lighting modifier matrix based on current light level and the plant’s LightRequirements.

### 2.3 Lifecycle Behavior

The Botanical System structures flora as dynamic, living entities rather than decorative, static objects. Plants grow, propagate, mutate, and decay by continuously evaluating the macro factors provided by the local PlanetaryContext.

Lifecycle behavior includes:

- Seasonal and perennial activity.
- Ephemeral, annual, biennial, ancient, and decaying states.
- Regeneration and harvest timing.
- Spread and invasion logic.
- Dormancy and decay handling.
- Mutation handling under magical anomaly or contamination.

### 2.4 Mutation Loop

If a chunk features `IsMagicalAnomaly = true` or `IsContaminated = true`, the generation pass rolls a mutation check during the plant’s lifecycle step. A successful roll forces a permanent drift in the plant’s phenotypic attributes, shifting its standard values toward high-tier ElementalAffinity expressions or lethal ToxicityLevel tracking.

### 2.5 Color Generation

Flower color belongs in generation logic first, then presentation second. The simulation should compute the plant’s color state from its identity and environment, and presentation should render that result.

Recommended color inputs:

- Base species palette.
- Biome tint.
- Bloom season tint.
- Elemental affinity.
- Mana saturation.
- Toxicity level.
- Color vibrancy.
- Magical anomaly / contamination flags.

Recommended color outputs:

- `HueFamily`
- `Saturation`
- `Brightness`
- `AccentColor`
- `GlowIntensity`
- `PatternType`

Suggested behavior:

- Base hue comes from species or family identity.
- Biome and season shift the hue family gently.
- Mana and elemental affinity push the plant toward unnatural or arcane tones.
- Toxicity pushes color toward sickly, corrosive, or warning-like palettes.
- Color vibrancy controls intensity and saturation.
- Magical anomaly can add prismatic, luminous, or impossible gradients.

***

## 3. Data Tables

This layer holds the reference values used by the simulation and presentation systems. It should remain a lookup library rather than a logic layer.

### 3.1 Core Biological Tracks

1. **Rarity:** Common, Uncommon, Rare, Epic, Legendary, Mythic.
2. **Toxicity Level:** Benign, Irritating, Mildly Toxic, Highly Toxic, Corrosive, Inert.
3. **Elemental Affinity:** Void, Cryo, Neutral, Thermal, Electrical.
4. **Mana Saturation:** Depleted, Neutral, Latent, Infused, Saturated.
5. **Hardiness:** Fragile, Delicate, Sturdy, Hardy, Indestructible.
6. **Aesthetic Value:** Ugly, Plain, Normal, Beautiful, Stunning.
7. **Color Vibrancy:** Drab, Muted, Normal, Vibrant, Prismatic.
8. **Regeneration:** None, Slow, Moderate, Fast, Speedy.
9. **Spread Rate:** Stationary, Rooted, Seeding, Viral, Parasitic.
10. **Light Requirements:** Nocturnal, Shade, Partial, Sunlight, Intense.
11. **Water Dependency:** Xerophytic, Low, Moderate, High, Aquatic.
12. **Soil Preference:** Acidic, Neutral, Alkaline, Volcanic, Magical.
13. **Pollination Type:** Self-Pollinating, Wind-Pollinated, Insect-Pollinated, Magical, Sterile.
14. **Root System:** Shallow, Fibrous, Taproot, Massive, Aerial.
15. **Lifespan Classification:** Ephemeral, Annual, Biennial, Perennial, Ancient.
16. **Fragrance Intensity:** Odorless, Subtle, Aromatic, Potent, Fetid.
17. **Symbiotic Relationships:** Solitary, Compatible, Synergistic, Parasitic, Mycorrhizal.
18. **Growth Rate:** Stagnant, Slow, Moderate, Fast, Explosive (Invasive).
19. **Yield Abundance:** Sparse (1-2), Modest (3-5), Generous (6-10), Abundant (11-20), Massive (20+).
20. **Bloom Season:** Spring, Summer, Autumn, Winter, Eternal, Nocturnal, Cyclical.
21. **Medicinal Potency:** Inert, Mild, Potent, Powerful, Legendary, Antitoxin.

### 3.2 Core Morphology Matrix

1. **Growth Form (Silhouette/Habit):** Thalloid, Rosette, Caulescent, Clambering, Arborescent.
2. **Organ Destination (Anatomy Focus):** Subterranean, Culm-Stalk, Foliar, Inflorescent, Fructiferous.
3. **Stem Structure (Material Integrity):** Herbaceous, Fleshy-Succulent, Hollow-Cane, Suffruticose, Ligneous.
4. **Canopy Architecture (Foliage Density):** Naked, Tufted, Spreading, Dense-Canopy, Plume.

### 3.3 Secondary Botanical Life Tracks

1. **Surface Armor (Outer Layer Protection):** Fleshy, Fibrous, Barked, Thorny, Chitinous.
2. **Foliage Type (Leaf Morphology):** Leafless, Bladed, Broadleaf, Needled, Spored.
3. **Growth Cycle (Seasonal Activity):** Ephemeral, Seasonal, Perennial, Decaying.
4. **Reproduction Style (Spread Mechanism):** Rooting, Seeding, Spreading, Sporing, Parasitic.

### 3.4 Functional Categorization Tracks

1. **Growth Habit:** Herbaceous, Woody, Climbing, Creeping, Aquatic, Epiphytic, Subterranean, Fungal.
2. **Structural Type:** Single-Stem, Multi-Stem, Rosette, Vining, Canopy, Bulbous, Mat-Forming, Spore Cluster.
3. **Harvest Output:** Leaves, Flowers, Fruit, Seeds, Bark, Wood, Resin, Sap, Roots/Tubers, Spores, Nectar, Fiber.
4. **Resource Role:** Culinary, Medicinal, Alchemical, Construction, Textile, Fuel, Trade, Ritual, Environmental, Utility.

### 3.5 Stat and Mechanical Matrix

This table is the source of truth for gameplay effects tied to flora traits.

- **Rarity:** Base modifier multiplier for all rolled secondary stats.
- **Value:** Price multiplier for merchants and trade value.
- **Slow:** +15% potion brewing time for precision control, -5% ingredient cost.
- **Explosive:** Uncontrolled spread yields massive free resources but can overrun plots.
- **Sparse:** +10% purity in crafting, less waste material produced but lower yields.
- **Massive:** +30% total yield, ideal for anchoring consistent supply lines.
- **Eternal:** Always harvestable, never enters seasonal dormancy states.
- **Nocturnal:** +25% potency at night, harvesting under moonlight adds buff duration.
- **Benign:** +10% health recovery, entirely safe for untrained herbalists to process.
- **Corrosive:** +20% armor degradation, inflicts chemical burns without protective gloves.
- **Antitoxin:** Instantly purges 1 active poison status effect upon consumption.
- **Inert:** Immune to status effects, base matrix cannot be enhanced via alchemy.
- **Thermal:** +15% fire damage, weapons ignite targets and potions grant frost immunity.
- **Cryo:** +15% frost damage, attacks apply slow and potions chill attackers.
- **Nature:** +20% healing effectiveness, gradually restores mana over time.
- **Void:** +15% shadow damage, inflicts decay effects on target life matrices.
- **Saturated:** +25% spell potency, amplifies raw output of active magical casts.
- **Depleted:** -20% mana cost for defensive spells, used to construct anti-magic fields.
- **Luminous:** Radiates local structural light vectors, extends dynamic vision maps.
- **Obscure:** +15% stealth rating, shrinks hostile aggro tracking radius.
- **Indestructible:** Infinite harvesting parameters, plant entity node never expires.
- **Fragile:** Drastically reduced structural durability, failure yields 50% waste scrap.
- **Instant:** Continuous cell regeneration, restores 5 HP per tick automatically.
- **None:** Single-use extraction parameters, node completely clears upon harvest.
- **Viral:** Spreads rapidly via environmental vectors, highly aggressive invasive behavior.
- **Stationary:** +5% base harvest yield, reliable parameter tracking for structural farming.
- **Intense:** Requires specialized high-tier light arrays, +30% yield in optimal setups.
- **Aquatic:** Must be cultivated directly inside liquid blocks, unlocks deep water routes.
- **Xerophytic:** Native to hyper-arid conditions, completely bypasses moisture requirements.
- **Magical:** Requires pure mana-infused soil matrices, grants +50% baseline stat scale.
- **Volcanic:** Thrives inside magma parameters, automatically extracts geothermal enhancements.
- **Sterile:** Bypasses natural cross-pollination spreads, highly valuable seed constraints.
- **Self-Pollinating:** Requires zero active management, autonomously populates empty sub-plots.
- **Aerial:** Bypasses soil vectors entirely, grows suspended in open air or cloud layers.
- **Massive:** Deep-rooted architecture anchors the node, immune to wind storm dislodge events.
- **Ancient:** Gains permanent stat scales and exponential value based on runtime age.
- **Ephemeral:** High-velocity daily lifecycles, yields rotate out inside short windows.
- **Stunning:** +15% global sell valuation, merchants pay premium rates for luxury appearance.
- **Ugly:** -15% trade value penalty, chemically identical but rejected by luxury buyers.
- **Potent:** Scent footprint provides a passive +5% attribute buff to nearby players.
- **Fetid:** Emits a repulsive stench trace, low-level hostile creatures avoid the tile.
- **Prismatic:** +20% magical catalyst effectiveness, potions glow and attract wilderness events.
- **Drab:** Subdued visual profile, harder to detect by passing entities or thieves.
- **Mycorrhizal:** Hooks into subterranean networks, +50% yield to all contiguous crops.
- **Parasitic:** Siphons life, deals 30% structural damage to adjacent plant matrices.
- **Thalloid:** Rendered flat to terrain, bypasses collision checks and has zero layout height.
- **Rosette:** Radial sprite layering, compact circular collision footprint.
- **Caulescent:** Upright vertical column rendering, columnar collision profiling.
- **Clambering:** Dynamic vine overlay asset layers, spreads across vertical structures.
- **Arborescent:** Overhead tree silhouette composition, casts wide shadow vectors.
- **Subterranean:** Yields tubers/bulbs, requires excavation and is invisible from the standard surface.
- **Culm-Stalk:** Yields cane structures, high integrity rigid stalk segments.
- **Foliar:** Yields soft leafy products, high recovery rates and lightning-fast harvest loops.
- **Inflorescent:** Yields flower/seed heads, subject to volatile seasonal bloom triggers.
- **Fructiferous:** Yields fruits/berries, branch-anchored harvest loops.
- **Herbaceous:** Low-density structural integrity, snaps easily and is harvestable by hand.
- **Fleshy-Succulent:** Hyper-dense water retention matrices, high frost resilience but vulnerable to fire.
- **Hollow-Cane:** Segmented tube structures, yields high-strength structural cylinders.
- **Suffruticose:** Semi-woody core base, balanced seasonal resilience attributes.
- **Ligneous:** Heavy timber core wood, hard tool check required (Axes/Saws).
- **Fleshy:** High-vulnerability tissue layers, easy extraction footprint.
- **Fibrous:** High tensile string networks, standard harvesting difficulty thresholds.
- **Barked:** Rigid protective structural wrap, requires sharp tools to slice cleanly.
- **Thorny:** Armed barbed defenses, inflicts flat bleeding damage to unprotected hands.
- **Chitinous:** Exoskeletal defense shielding, requires reinforced tools to puncture.
- **Leafless:** Stripped bare sprite layers, zero foliage geometry drawn.
- **Bladed:** Grass/grain ribbon morphology, displays flowing wind animation states.
- **Broadleaf:** Expansive flat foliage planes, renders dense leaf shadows.
- **Needled:** Tight cluster needles, native aesthetic handling for freezing biomes.
- **Spored:** Mushroom cap arrays, triggers continuous spore release particle hooks.
- **Ephemeral Cycle:** Triggers flash growth bursts, tight micro-windows of harvest opportunity.
- **Seasonal Cycle:** Growth loops bind tightly to specific active biome weather states.
- **Perennial Cycle:** Year-round active status parameters, continual production capability.
- **Decaying Cycle:** Dead rotting status track, yields specialized compost or lethal toxins.
- **Thorny (Weapon):** Applied to arms, inflicts +15% armor piercing and bleed on contact.
- **Medicinal (App):** Applied to health matrices, boosts baseline recovery speed by 20%.
- **Toxic (Weapon):** Applied to payloads, inflicts deep poison status logic over time.
- **Magickal (App):** Applied to focus matrices, amplifies spell duration profiles by 25%.

### 3.6 Color Tables

Add the following palette references to the data layer:

- **Base hue families:** red, yellow, green, blue, violet, white, black, gold, silver.
- **Biome tints:** forest green, swamp olive, alpine blue, desert amber, aquatic teal, subterranean gray.
- **Season shifts:** spring pastel, summer saturated, autumn warm, winter pale.
- **Magic tones:** arcane violet, luminous cyan, prismatic rainbow, void black.
- **Toxic tones:** sickly yellow, bruised purple, corrosive green, ash gray.
- **Vibrancy bands:** drab, muted, normal, vibrant, prismatic.

***

## 4. Presentation and Naming

This layer determines how the plant appears to the player: its name, visual style, final palette, and descriptive identity.

### 4.1 Naming Pattern

The procedural naming blueprint is:

Rarity + Value + Biome/Season Prefix + Property Adjective + Base Species + Of the Suffix

### 4.2 Naming Logic

The engine gathers rolled statistics across all 35 tracking categories, parses out the two highest statistical anomalies scoring above a 0.75 threshold, maps them to grammatical word definitions, and outputs a structured title.

Naming rules:

1. Read base rarity and value.
2. Add a biome or season prefix when available.
3. Use the strongest extreme trait as the main adjective.
4. Use the second strongest extreme trait as the suffix noun.
5. Keep the base species as the anchor of identity.

### 4.3 Trait-to-Word Mapping

Example mappings already used in the file include:

- **Benign → Wholesome / Healing**
- **Corrosive → Acidic / Erosion**
- **Antitoxin → Purifying / Antidotes**
- **Void → Umbral / Darkness**
- **Saturated → Arcane / Sorcery**
- **Luminous → Radiant / Light**
- **Obscure → Hidden / Shadows**
- **Prismatic → Iridescent / Spectrum**
- **Mycorrhizal → Connected / Symbiosis**
- **Parasitic → Consuming / Predation**.

### 4.4 Visual Output

Presentation should map the plant to:

- Sprite composition
- Silhouette choice
- Foliage layout
- Collision size
- Surface texture
- Bloom appearance
- Color output

Color should be rendered from the computed state:

- `HueFamily` controls the main color family
- `Saturation` controls intensity
- `Brightness` controls visibility
- `AccentColor` controls petals, veins, and edges
- `GlowIntensity` handles magical emission
- `PatternType` handles gradients, speckles, striping, or iridescence

***

## 5. Procedural Naming System

### 5.1 C# Implementation

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class FloraNameGenerator
{
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

    private static readonly Dictionary<string, (string adj, string noun)> PropertyWords = new()
    {
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
        { "Structural", ("Structural", "Building") },
        { "Textile-Role", ("Woven", "Fabric") },
        { "Fuel-Role", ("Combustible", "Energy") },
        { "Trade-Role", ("Valuable", "Commerce") },
        { "Ritual-Role", ("Sacred", "Ceremony") },
        { "Environmental-Role", ("Ecological", "Balance") },
        { "Utility-Role", ("Practical", "Tools") },
        { "Culinary-Role", ("Edible", "Sustenance") },
        { "Medicinal-Role", ("Healing", "Wellness") },
        { "Alchemical-Role", ("Arcane", "Reagents") },
        { "Construction-Role", ("Built", "Tools") }
    };

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

    public static string GenerateProceduralName(string baseSpecies, Dictionary<string, object> properties)
    {
        string rarity = properties.ContainsKey("Rarity") ? (string)properties["Rarity"] : "Common";
        string value = properties.ContainsKey("Value") ? (string)properties["Value"] : "Standard";
        string bloomSeason = properties.ContainsKey("Bloom Season") ? (string)properties["Bloom Season"] : "Eternal";
        string biome = properties.ContainsKey("Biome") ? (string)properties["Biome"] : "Forest";

        string rarityWord = RarityTitles.ContainsKey(rarity) ? RarityTitles[rarity] : "";
        string valueWord = ValueTitles.ContainsKey(value) ? ValueTitles[value] : "";
        string biomeWord = "";
        string adjWord = "";
        string nounSuffix = "";

        string baseName = baseSpecies;

        if (BiomePrefixes.ContainsKey(bloomSeason))
        {
            biomeWord = BiomePrefixes[bloomSeason];
        }
        else if (BiomePrefixes.ContainsKey(biome))
        {
            biomeWord = BiomePrefixes[biome];
        }

        var extremeTraits = new List<(string trait, double score)>();
        foreach (var prop in properties)
        {
            if (PropertyWords.ContainsKey(prop.Key) && prop.Value is double score && score >= 0.75)
            {
                extremeTraits.Add((prop.Key, score));
            }
        }

        extremeTraits = extremeTraits.OrderByDescending(x => x.score).ToList();

        if (extremeTraits.Count >= 1)
        {
            string primaryTrait = extremeTraits[0].trait;
            adjWord = PropertyWords[primaryTrait].adj;
        }

        if (extremeTraits.Count >= 2)
        {
            string secondaryTrait = extremeTraits.trait;
            nounSuffix = $"of {PropertyWords[secondaryTrait].noun}";
        }

        var prefixChain = new List<string> { rarityWord, valueWord, biomeWord, adjWord };
        var cleanedPrefixes = prefixChain.Where(p => !string.IsNullOrEmpty(p)).ToList();

        string finalName = string.Join(" ", cleanedPrefixes) + $" {baseName}";
        if (!string.IsNullOrEmpty(nounSuffix))
        {
            finalName += $" {nounSuffix}";
        }

        return System.Text.RegularExpressions.Regex.Replace(finalName, @"\s+", " ").Trim();
    }
}
```

### 5.2 Usage Examples

**Example A:** Rare spring flower with antitoxin properties.

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

**Example B:** Mythic void-aligned parasitic plant.

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

**Example C:** Common humble herb with medicinal properties.

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

**Example D:** Epic climbing woody plant with high-value timber output for construction.

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Ironvine", new()
{
    { "Rarity", "Epic" },
    { "Value", "Precious" },
    { "Bloom Season", "Eternal" },
    { "Biome", "Forest" },
    { "Growth Habit", "Climbing-Habit", 0.88 },
    { "Structural Type", "Canopy-Struct", 0.85 },
    { "Harvest Output", "Wood-Output", 0.92 },
    { "Resource Role", "Construction-Role", 0.89 }
});
// Output: Arcane Eternal Ascending Ironvine of Building
```

**Example E:** Legendary fungal subterranean plant with spore cluster anatomy and alchemical utility.

```csharp
var result = FloraNameGenerator.GenerateProceduralName("Luminagaric", new()
{
    { "Rarity", "Legendary" },
    { "Value", "Relic" },
    { "Bloom Season", "Eternal" },
    { "Biome", "Caverns" },
    { "Luminous", 0.95 },
    { "Mana Saturation", "Saturated", 0.91 },
    { "Growth Habit", "Fungal-Habit", 0.99 },
    { "Structural Type", "Spore-Cluster", 0.97 },
    { "Harvest Output", "Spores-Output", 0.94 },
    { "Resource Role", "Alchemical-Role", 0.96 }
});
// Output: Eternal Venerated Arcane Luminagaric of Reagents
```

***

## 6. Simulation Growth Engine

Plant development is an ongoing cycle driven by resource matching. The Botanical System structures flora as dynamic, living entities rather than decorative, static objects. Plants grow, propagate, mutate, and decay by continuously evaluating the macro factors provided by the local PlanetaryContext.

***

## 7. Core Data Architecture

To manage the 35 distinct attributes cleanly without bloating memory arrays, flora configurations are broken down into isolated, highly optimized modular structs.

```csharp
public struct BotanicalProfile
{
    public FloraIdentity Identity;
    public GrowthProfile Growth;
    public PhenotypicExpression Phenotype;
    public BiochemicalProfile Chemistry;
}

public struct FloraIdentity
{
    public Rarity Classification;
    public Value FinancialTier;
    public ResourceRole PrimaryUtility;
    public HarvestOutput HarvestType;
}

public struct GrowthProfile
{
    public GrowthRate BaseSpeed;
    public LifespanClass Lifespan;
    public BloomSeason Cycle;
    public LightRequirements LightNeed;
    public WaterDependency WaterNeed;
    public SoilPreference SoilNeed;
    public PollinationType Pollination;
    public SpreadRate ExpansionSpeed;
}

public struct PhenotypicExpression
{
    public GrowthForm Silhouette;
    public GrowthHabit HabitType;
    public StructuralType Architecture;
    public StemStructure StemMaterial;
    public CanopyArchitecture Density;
    public FoliageType LeafShape;
    public SurfaceArmor ExternalArmor;
    public RootSystem RootType;
    public ColorVibrancy Palette;
    public Visibility ScreenPresence;
    public FragranceIntensity Odor;
    public AestheticValue BeautyIndex;
}

public struct BiochemicalProfile
{
    public ToxicityLevel VenomTier;
    public MedicinalPotency CureTier;
    public ElementalAffinity Element;
    public ManaSaturation ArcaneCharge;
    public Hardiness Durability;
    public float RegenerationRate;
}
```

***

## 8. Gameplay Mechanics Matrix

The extreme poles of these botanical traits introduce significant mechanical adjustments to crafting, environmental hazard creation, and entity interaction logic.

- **Growth: Explosive:** Uncontrolled spread patterns. Seeds autonomously invade adjacent tiles, crowding out and killing neighboring flora types.
- **Cycle: Nocturnal:** Provides a +25% bonus to potion potency calculations if harvested between 20:00 and 04:00.
- **Venom: Corrosive:** Applies a continuous -20% armor degradation penalty across exposed clothing. Harvesting requires protective gloves.
- **Cure: Antitoxin:** Consuming the raw item or distilled derivative purges active negative status debuffs and grants brief poison immunity.
- **Element: Thermal:** Modifies alchemy outcomes to apply Warmth status protections or injects +15% Fire Damage vectors into weaponry coatings.
- **Arcane: Saturated:** Amplifies spell potency variables by +25% when held or processed into local focus components.
- **Presence: Luminous:** Emits physical pixel lighting data onto the map, expanding nearby entity visibility rings by +3 coordinates.
- **Odor: Fetid:** Radiates local atmospheric vectors that repel wild animals and fragile entities out of the immediate coordinate vicinity.
- **Silhouette: Thalloid:** Renders flat ground-plane blankets. Collision footprint size is evaluated as 0, allowing items to be safely walked over.
- **Silhouette: Arborescent:** Triggers full tree canopy rendering matrices. Shadows block light paths below, and paths require an axe tool to pass.
- **Anatomy: Subterranean:** Yields hidden root items. Harvesting requires executing a Dig action loop, leaving behind displaced ground tiles.

***

## 9. Botanical Classification

### 9.1 Plant Family Types

- Herbs: Small plants used for medicine, cooking, and alchemy.
- Flowers: Ornamental and functional plants with blossoms.
- Crops: Cultivated plants for food and sustenance.
- Trees: Large woody plants providing timber and fruits.
- Shrubs: Medium-sized woody plants with multiple stems.
- Vines: Climbing or trailing plants that spread along surfaces.
- Fungi: Non-photosynthetic organisms including mushrooms and molds.
- Algae: Aquatic plant-like organisms for water-based harvesting.

### 9.2 Harvesting Methods

- Hand-Picking: Manual collection of fruits, flowers, or leaves.
- Cutting: Slicing stems and branches with tools.
- Digging: Excavating root systems and bulbs.
- Scraping: Collecting bark, lichen, or fungal growths.
- Milking: Extracting plant fluids and saps.
- Threshing: Separating seeds from plant matter.
- Spore Collection: Gathering reproductive spores from fungi.
- Pressing: Extracting oils and essences from plants.

***

## 10. Processing and Refinement

### Herbalism and Preparation

- Drying: Removing moisture to preserve herbs for later use.
- Infusion: Steeping plants in liquid to extract properties.
- Decoction: Boiling plant matter to concentrate active compounds.
- Tincture Creation: Extracting plant essence in alcohol solution.
- Powdering: Grinding dried plants into fine powder.

### Alchemy and Potion Crafting

- Ingredient Combination: Mixing flora with minerals for synergistic effects.
- Fermentation: Using flora to create alcoholic beverages with special properties.
- Extract Production: Concentrating plant essences into potent extracts.
- Oil Infusion: Creating oils imbued with plant properties.
- Essence Distillation: Separating pure magical essence from plant matter.

### Cultivation and Gardening

- Soil Preparation: Creating optimal growing conditions.
- Seed Starting: Germinating seeds in controlled environments.
- Transplanting: Moving seedlings to permanent growing locations.
- Companion Planting: Growing compatible plants together for enhanced yields.
- Pest Management: Protecting plants from disease and harmful creatures.

***

## 11. Economic Flora Systems

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

    public static double CalculateFloraValue(
        Flora flora,
        string quality,
        int quantity,
        MarketConditions marketConditions)
    {
        double baseValue = flora.BaseMarketValue;

        if (!QualityMultipliers.TryGetValue(quality, out double qualityValue))
            qualityValue = 1.0;

        double qualityAdjustedValue = baseValue * qualityValue;
        double rarityBonus = 1.0 + (flora.RarityScore * 0.15);
        double quantityDiscount = Math.Min(1.0, Math.Pow(0.95, quantity / 50.0));
        double demandModifier = CalculateDemandFactor(flora, marketConditions);
        double freshnessModifier = Math.Max(0.4, 1.0 - (marketConditions.DaysSinceHarvest * 0.1));

        double totalValue = qualityAdjustedValue * quantity * rarityBonus *
                            quantityDiscount * demandModifier * freshnessModifier;

        return totalValue;
    }

    private static double CalculateDemandFactor(Flora flora, MarketConditions conditions)
    {
        double modifier = 1.0;

        if (flora.MedicinalPotency > 0.7)
            modifier *= 1.2;

        if (flora.AlchemyValue > 0.5)
            modifier *= 1.15;

        if (conditions.CurrentSeason == flora.BloomSeason)
            modifier *= 0.85;
        else if (flora.BloomSeason != "Eternal")
            modifier *= 1.3;

        if (conditions.GlobalSupply < 0.2)
            modifier *= 1.5;
        else if (conditions.GlobalSupply > 0.9)
            modifier *= 0.7;

        return modifier;
    }
}

public class MarketConditions
{
    public double GlobalSupply { get; set; }
    public double GlobalDemand { get; set; }
    public string CurrentSeason { get; set; }
    public int DaysSinceHarvest { get; set; }
    public bool IsPlagueActive { get; set; }
    public bool IsWarTime { get; set; }
}
```

### Trade Networks

- Herbalist Guilds: Organizations controlling herb gathering and distribution.
- Alchemist Circles: Networks of potion makers and ingredient traders.
- Farmer Cooperatives: Groups of cultivators sharing resources and knowledge.
- Merchant Routes: Trade paths for distributing flora to distant regions.
- Black Market Botanicals: Illegal trade in restricted or toxic plants.

### Resource Management

- Crop Rotation: Planting different species in sequence to maintain soil health.
- Sustainable Harvesting: Leaving portions of plants to regenerate.
- Seed Banking: Storing seeds for future planting seasons.
- Cross-Breeding: Combining traits from different flora to create hybrids.
- Magical Cultivation: Using arcane methods to enhance growth and properties.

***

## 12. Advanced Flora Features

### Magical Flora Properties

- Mana Affinity: Plants’ ability to absorb and store magical energy.
- Spell Components: Certain flora serve as catalysts for magical effects.
- Enchantment Receptiveness: Plants’ capacity to be magically enhanced.
- Aura Emission: Flora that radiate magical auras affecting nearby beings.
- Arcane Mutations: Plants altered by magical exposure with unique properties.

### Environmental Flora

- Bioluminescence: Plants that naturally emit light.
- Symbiotic Ecosystems: Flora that depend on or enhance other organisms.
- Weather Manipulation: Plants that influence local climate conditions.
- Dimensional Rifts: Flora existing partially in other planes.
- Temporal Anomalies: Plants affected by or affecting time flow.

### Specialized Cultivation

- Greenhouse Farming: Controlled environments for year-round cultivation.
- Hydroponic Gardens: Growing plants in water-based systems.
- Floating Gardens: Cultivation in mid-air using magical suspension.
- Underground Caverns: Cultivating shade and cave-dwelling plants.
- Dimensional Gardens: Growing flora in magically-enhanced pocket dimensions.

### Hybrid and Mutations

- Intentional Hybrids: Cross-bred plants with enhanced properties.
- Magical Mutations: Plants permanently altered by magical exposure.
- Radiation Variants: Flora growing near magical hotspots.
- Cursed Plants: Plants corrupted by dark magic with special effects.
- Blessed Flora: Plants infused with divine or protective magic.

***

## 13. Performance Optimization

### Flora Management

- Growth Caching: Store calculated growth states for efficient updates.
- Spatial Flora Indexing: Efficient storage of plant locations in garden systems.
- Procedural Generation: Dynamic creation of flora during exploration.
- LOD Systems: Reduce plant detail based on distance from player.
- Batch Harvesting: Process multiple plant harvests simultaneously.

### Cultivation Efficiency

- Seasonal Updates: Update all plants once per season rather than each tick.
- Dormancy Pooling: Group dormant plants to reduce processing.
- Lazy Evaluation: Only calculate stats when flora is directly interacted with.
- Garden Snapshots: Store garden states to reduce recalculation.
- Yield Prediction: Precalculate harvest values to avoid runtime computation.

***

## 14. Future Enhancements

- Flora mutation and evolution systems.
- Seed breeding mechanics for custom plant creation.
- Invasive species and ecological balance mechanics.
- Endangered flora preservation quests.
- Seasonal migration of harvestable plants.
- Flora-based building materials and construction.
- Plant-based poisons and toxicology systems.
- Cooperative garden management.
- Flora-centered NPCs and herbalist storylines.
- Cross-game seasonal event flora appearances.
