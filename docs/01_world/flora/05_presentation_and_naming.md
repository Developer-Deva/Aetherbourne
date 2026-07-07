# Flora Presentation and Naming

## Presentation Responsibilities

Presentation determines how the plant appears to the player:

- name
- visual style
- final palette
- descriptive identity
- sprite composition choices (silhouette/foliage/collision implications)

Color should be rendered from the computed state produced by generation:

- `HueFamily` → main color family
- `Saturation` → intensity
- `Brightness` → visibility
- `AccentColor` → petals/veins/edges
- `GlowIntensity` → magical emission strength
- `PatternType` → gradients/speckles/striping/iridescence

## Procedural Naming Pattern

**Naming Pattern:**

`Rarity + Value + Biome/Season Prefix + Property Adjective + Base Species + Of the Suffix`

## Naming Logic

1. Read base **Rarity** and **Value**.
2. Add a biome or season prefix when available.
3. Use the strongest extreme trait as the main adjective.
4. Use the second strongest extreme trait as the suffix noun.
5. Keep base species as the anchor.

## Trait-to-Word Mapping (Examples)

- Benign → Wholesome / Healing
- Corrosive → Acidic / Erosion
- Antitoxin → Purifying / Antidotes
- Void → Umbral / Darkness
- Saturated → Arcane / Sorcery
- Luminous → Radiant / Light
- Obscure → Hidden / Shadows
- Prismatic → Iridescent / Spectrum
- Mycorrhizal → Connected / Symbiosis
- Parasitic → Consuming / Predation

## Naming Generator (C# Reference)
>
> Note: v2’s sample code contained a second-trait indexing bug. The corrected implementation below is intended as the reference.

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
        { "Parasitic", ("Consuming", "Predation") }

        // TODO: extend mapping to cover all 35 traits and output/resource keys.
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

        string rarityWord = RarityTitles.TryGetValue(rarity, out var r) ? r : "";
        string valueWord = ValueTitles.TryGetValue(value, out var v) ? v : "";

        string biomeWord = "";
        if (BiomePrefixes.TryGetValue(bloomSeason, out var b1)) biomeWord = b1;
        else if (BiomePrefixes.TryGetValue(biome, out var b2)) biomeWord = b2;

        var extremeTraits = new List<(string trait, double score)>();
        foreach (var prop in properties)
        {
            if (PropertyWords.ContainsKey(prop.Key) && prop.Value is double score && score >= 0.75)
                extremeTraits.Add((prop.Key, score));
        }

        extremeTraits = extremeTraits.OrderByDescending(x => x.score).ToList();

        string adjWord = "";
        string nounSuffix = "";

        if (extremeTraits.Count >= 1)
        {
            string primaryTrait = extremeTraits[0].trait;
            adjWord = PropertyWords[primaryTrait].adj;
        }

        if (extremeTraits.Count >= 2)
        {
            string secondaryTrait = extremeTraits[1].trait; // corrected indexing
            nounSuffix = $"of {PropertyWords[secondaryTrait].noun}";
        }

        var prefixChain = new List<string> { rarityWord, valueWord, biomeWord, adjWord };
        var cleaned = prefixChain.Where(p => !string.IsNullOrEmpty(p)).ToList();

        string finalName = string.Join(" ", cleaned) + $" {baseSpecies}";
        if (!string.IsNullOrEmpty(nounSuffix)) finalName += $" {nounSuffix}";

        return System.Text.RegularExpressions.Regex.Replace(finalName, @"\s+", " ").Trim();
    }
}
```
