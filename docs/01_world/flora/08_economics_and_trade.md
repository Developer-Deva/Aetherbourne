# Flora Economics and Trade

## 1) Harvest Value Calculation (Reference)

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

        return qualityAdjustedValue * quantity * rarityBonus *
               quantityDiscount * demandModifier * freshnessModifier;
    }

    private static double CalculateDemandFactor(Flora flora, MarketConditions conditions)
    {
        double modifier = 1.0;

        if (flora.MedicinalPotency > 0.7) modifier *= 1.2;
        if (flora.AlchemyValue > 0.5) modifier *= 1.15;

        if (conditions.CurrentSeason == flora.BloomSeason) modifier *= 0.85;
        else if (flora.BloomSeason != "Eternal") modifier *= 1.3;

        if (conditions.GlobalSupply < 0.2) modifier *= 1.5;
        else if (conditions.GlobalSupply > 0.9) modifier *= 0.7;

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

## 2) Trade Networks

- Herbalist Guilds
- Alchemist Circles
- Farmer Cooperatives
- Merchant Routes
- Black Market Botanicals

## 3) Resource Management

- Crop rotation
- Sustainable harvesting
- Seed banking
- Cross-breeding
- Magical cultivation
