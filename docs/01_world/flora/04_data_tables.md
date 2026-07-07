# Flora Data Tables (Lookup Library)

This layer holds **reference values** used by simulation and presentation. It should be treated as a lookup library rather than a logic layer.

## 1) Core Biological Tracks (35 Axes - 1..21)

1. **Rarity**: Common, Uncommon, Rare, Epic, Legendary, Mythic
2. **Toxicity Level**: Benign, Irritating, Mildly Toxic, Highly Toxic, Corrosive, Inert
3. **Elemental Affinity**: Void, Cryo, Neutral, Thermal, Electrical
4. **Mana Saturation**: Depleted, Neutral, Latent, Infused, Saturated
5. **Hardiness**: Fragile, Delicate, Sturdy, Hardy, Indestructible
6. **Aesthetic Value**: Ugly, Plain, Normal, Beautiful, Stunning
7. **Color Vibrancy**: Drab, Muted, Normal, Vibrant, Prismatic
8. **Regeneration**: None, Slow, Moderate, Fast, Speedy
9. **Spread Rate**: Stationary, Rooted, Seeding, Viral, Parasitic
10. **Light Requirements**: Nocturnal, Shade, Partial, Sunlight, Intense
11. **Water Dependency**: Xerophytic, Low, Moderate, High, Aquatic
12. **Soil Preference**: Acidic, Neutral, Alkaline, Volcanic, Magical
13. **Pollination Type**: Self-Pollinating, Wind-Pollinated, Insect-Pollinated, Magical, Sterile
14. **Root System**: Shallow, Fibrous, Taproot, Massive, Aerial
15. **Lifespan Classification**: Ephemeral, Annual, Biennial, Perennial, Ancient
16. **Fragrance Intensity**: Odorless, Subtle, Aromatic, Potent, Fetid
17. **Symbiotic Relationships**: Solitary, Compatible, Synergistic, Parasitic, Mycorrhizal
18. **Growth Rate**: Stagnant, Slow, Moderate, Fast, Explosive (Invasive)
19. **Yield Abundance**: Sparse (1-2), Modest (3-5), Generous (6-10), Abundant (11-20), Massive (20+)
20. **Bloom Season**: Spring, Summer, Autumn, Winter, Eternal, Nocturnal, Cyclical
21. **Medicinal Potency**: Inert, Mild, Potent, Powerful, Legendary, Antitoxin

## 2) Core Morphology Matrix (24..27)

1. **Growth Form (Silhouette/Habit)**: Thalloid, Rosette, Caulescent, Clambering, Arborescent
2. **Organ Destination (Anatomy Focus)**: Subterranean, Culm-Stalk, Foliar, Inflorescent, Fructiferous
3. **Stem Structure (Material Integrity)**: Herbaceous, Fleshy-Succulent, Hollow-Cane, Suffruticose, Ligneous
4. **Canopy Architecture (Foliage Density)**: Naked, Tufted, Spreading, Dense-Canopy, Plume

## 3) Secondary Botanical Life Tracks

1. **Surface Armor**: Fleshy, Fibrous, Barked, Thorny, Chitinous
2. **Foliage Type**: Leafless, Bladed, Broadleaf, Needled, Spored
3. **Growth Cycle**: Ephemeral, Seasonal, Perennial, Decaying
4. **Reproduction Style**: Rooting, Seeding, Spreading, Sporing, Parasitic

## 4) Functional Categorization Tracks

1. **Growth Habit**: Herbaceous, Woody, Climbing, Creeping, Aquatic, Epiphytic, Subterranean, Fungal
2. **Structural Type**: Single-Stem, Multi-Stem, Rosette, Vining, Canopy, Bulbous, Mat-Forming, Spore Cluster
3. **Harvest Output**: Leaves, Flowers, Fruit, Seeds, Bark, Wood, Resin, Sap, Roots/Tubers, Spores, Nectar, Fiber
4. **Resource Role**: Culinary, Medicinal, Alchemical, Construction, Textile, Fuel, Trade, Ritual, Environmental, Utility

## 5) Stat & Mechanical Matrix (Trait → Gameplay Effects)

This is the source of truth for gameplay effects tied to flora traits.

> Note: values below reflect the stat/mechanics multipliers described across the source docs.

- **Rarity**: Base modifier multiplier for rolled secondary stats.
- **Value**: Price multiplier for merchants and trade value.
- **Slow**: +15% potion brewing time, -5% ingredient cost.
- **Explosive**: massive uncontrolled spread/overrun risk.
- **Sparse**: +10% purity, less waste, lower yields.
- **Massive**: +30% total yield.
- **Eternal**: always harvestable; no seasonal dormancy.
- **Nocturnal**: +25% potency at night; moonlight harvesting buff duration.
- **Benign**: +10% health recovery; safe for untrained processing.
- **Corrosive**: +20% armor degradation; chemical burns without gloves.
- **Antitoxin**: purges 1 active poison status effect upon consumption.
- **Inert**: immune to status effects; base matrix cannot be enhanced via alchemy.
- **Thermal**: +15% fire damage; weapons ignite targets; potions grant frost immunity.
- **Cryo**: +15% frost damage; attacks apply slow; potions chill.
- **Nature**: +20% healing effectiveness; gradually restores mana.
- **Void**: +15% shadow damage; inflicts decay.
- **Saturated**: +25% spell potency; amplifies active magical casts.
- **Depleted**: -20% mana cost for defensive spells; anti-magic fields.
- **Luminous**: emits light; expands dynamic vision maps.
- **Obscure**: +15% stealth rating; shrinks hostile aggro radius.
- **Indestructible**: infinite harvesting; node never expires.
- **Fragile**: reduced durability; 50% waste scrap on failure.
- **Instant**: continuous regeneration; restores 5 HP per tick.
- **None**: single-use extraction; node clears on harvest.
- **Viral**: rapid invasive spread.
- **Stationary**: +5% base harvest yield; reliable tracking.
- **Intense**: requires specialized high-tier light arrays; +30% yield.
- **Aquatic**: must grow in liquid blocks.
- **Xerophytic**: bypasses moisture requirements.
- **Magical**: requires mana-infused soil; +50% baseline stat scale.
- **Volcanic**: magma parameters auto-enhance.
- **Sterile**: seed constraint/high value.
- **Self-Pollinating**: zero active management.
- **Aerial**: grows suspended in open air/cloud layers.
- **Ancient**: permanent stat scales and exponential value by runtime age.
- **Ephemeral**: short daily harvest windows.
- **Stunning**: +15% global sell valuation.
- **Ugly**: -15% trade value penalty.
- **Potent**: passive +5% attribute buff nearby.
- **Fetid**: repels wild/fragile entities.
- **Prismatic**: +20% magical catalyst effectiveness; attracts events.
- **Drab**: harder to detect.
- **Mycorrhizal**: +50% yield to contiguous crops.
- **Parasitic**: siphons life; deals 30% structural damage to adjacent plant matrices.
- **Thalloid / Rosette / Caulescent / Clambering / Arborescent**: rendering and collision implications.
- **Subterranean / Culm-Stalk / Foliar / Inflorescent / Fructiferous**: harvest implications.
- **Herbaceous / Fleshy-Succulent / Hollow-Cane / Suffruticose / Ligneous**: tool/difficulty & durability implications.

(Full verbatim mechanical lists were consolidated from v1 and v2 into this section. If you want the exact v1 table replicated line-by-line into this file, it can be added.)

## 6) Color Tables (Palette References)

- **Base hue families**: red, yellow, green, blue, violet, white, black, gold, silver
- **Biome tints**: forest green, swamp olive, alpine blue, desert amber, aquatic teal, subterranean gray
- **Season shifts**: spring pastel, summer saturated, autumn warm, winter pale
- **Magic tones**: arcane violet, luminous cyan, prismatic rainbow, void black
- **Toxic tones**: sickly yellow, bruised purple, corrosive green, ash gray
- **Vibrancy bands**: drab, muted, normal, vibrant, prismatic
