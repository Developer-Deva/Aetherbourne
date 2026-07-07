# Flora Simulation Engine

This file documents runtime simulation concerns: growth math, lifecycle evaluation, and how data architecture connects.

## 1) Growth Rate (Reference Model)

Plants compute growth progress as a function of:

- base growth speed (from species taxonomy)
- light modifier
- water modifier
- temperature modifier
- soil modifier
- seasonal modifier

A more explicit reference implementation (from v1) follows.

```csharp
using System;

public class PlantGrowthCalculator
{
    public static double CalculateGrowthProgress(
        Flora plant,
        double elapsedDays,
        EnvironmentalConditions conditions)
    {
        double baseGrowthRate = plant.GrowthRateModifier;

        double lightModifier = CalculateLightModifier(plant.LightRequirements, conditions.LightLevel);
        double waterModifier = CalculateWaterModifier(plant.WaterDependency, conditions.Moisture);
        double temperatureModifier = CalculateTemperatureModifier(plant.PreferredTemperature, conditions.CurrentTemperature);
        double soilModifier = CalculateSoilModifier(plant.SoilPreference, conditions.SoilComposition);

        double seasonalModifier = GetSeasonalModifier(plant.BloomSeason, conditions.CurrentSeason);

        double totalGrowthRate = baseGrowthRate * lightModifier * waterModifier *
                                    temperatureModifier * soilModifier * seasonalModifier;

        return Math.Min(1.0, (elapsedDays * totalGrowthRate) / plant.MaturityDays);
    }

    private static double CalculateLightModifier(string requirement, double lightLevel)
    {
        return requirement switch
        {
            "Nocturnal" => 1.0 - (lightLevel * 0.5),
            "Shade" => Math.Max(0.2, 1.0 - (lightLevel * 0.3)),
            "Partial" => 1.0,
            "Sunlight" => Math.Min(1.2, lightLevel),
            "Intense" => Math.Min(1.5, lightLevel * 1.3),
            _ => 1.0
        };
    }

    private static double CalculateWaterModifier(string dependency, double moisture)
    {
        return dependency switch
        {
            "Xerophytic" => 1.0 - (moisture * 0.4),
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
        if (difference < 5) return 1.0;
        if (difference < 15) return 0.8;
        if (difference < 25) return 0.5;
        return 0.1;
    }

    private static double CalculateSoilModifier(string preference, string soilType)
    {
        if (preference == soilType) return 1.0;

        return soilType switch
        {
            "Neutral" => 0.9,
            _ => 0.6
        };
    }

    private static double GetSeasonalModifier(string bloomSeason, string currentSeason)
    {
        if (bloomSeason == currentSeason) return 1.2;
        if (bloomSeason == "Eternal") return 1.0;
        return 0.7;
    }
}
```

## 2) Core Data Architecture

To manage the 35 distinct attributes without bloating memory arrays, flora configs are described as modular structs.

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
