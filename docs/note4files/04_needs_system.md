# Needs System — Motivation Pressure from Fulfillment (100 = Satisfied)

**Last Updated:** 2026-06-27 (includes later Gemini update)

## Overview
Needs are persistent internal states representing **fulfillment / deprivation / psychological pressure**.

- Needs generate **Decision Pressure**.
- The Need System does **not** choose actions.
- Pressure values are consumed by downstream systems:
  - Emotion System
  - Behavior System
  - Memory System

## Simulation Role
Answers: **“What does this creature currently want?”**

## Processing Order (Per update)
1. Update Need Values
2. Calculate Need States
3. Calculate Need Pressures
4. Publish Need Outputs

## Need Data Model
Each creature maintains one instance per need.

```csharp
public class Need
{
    public NeedType Type;

    // 100 = Fully Satisfied, 0 = Critically Deprived
    public float Value;

    public float BasePriority;
    public float PersonalityWeight;

    public float Pressure;
    public NeedState State;
}
```

## Need Value Range & Interpretation
All needs use the same scale:

- **Min:** 0
- **Max:** 100

Meaning:

- **100** = Fully Satisfied
- **0** = Critically Unsatisfied / empty

Always clamp:

- `Value = Clamp(Value, 0, 100)`

## Need States (Derived from Value)
| Value Range | Need State | Description |
|---|---|---|
| **81 – 100** | Satiated | Perfectly content. Zero to minimal tension. |
| **51 – 80** | Stable | Comfortable, but starting to slowly drain. |
| **21 – 50** | Pressing | Noticeably empty; seeking solutions. |
| **0 – 20** | Critical | Running on empty; high threat to survival/stability. |

Logic:

- if `Value >= 81` → Satiated
- else if `Value >= 51` → Stable
- else if `Value >= 21` → Pressing
- else → Critical

## Pressure Calculation (Deprivation-based)
Pressure is computed from **deprivation**:

- **Deprivation = 100 - Value**

### Base Pressure
- `BasePressure = (Deprivation × BasePriority) × PersonalityWeight`

### Critical Emergency Multiplier
If in **Critical** (0–20), apply:

- `FinalPressure = BasePressure × 1.5`

Otherwise:

- `FinalPressure = BasePressure`

This is intended to prevent dithering and ensure survival distress “hijacks” behavior when necessary.

## Need Categories & Base Priorities
### Survival Needs
- **Health**
  - BasePriority: **5.0**
  - Decrease (deprivation): Damage, Disease, Poison, environmental hazards
  - Increase (fulfillment): Healing, Medicine, Recovery

- **Thirst**
  - BasePriority: **4.0**
  - Decrease: Time, Heat, Labor
  - Increase: Drinking

- **Hunger**
  - BasePriority: **3.5**
  - Decrease: Time, Physical activity
  - Increase: Eating

- **Energy**
  - BasePriority: **3.0**
  - Decrease: Wakefulness, Labor, Combat
  - Increase: Sleep, Rest

- **Safety**
  - BasePriority: **2.5**
  - Decrease: Nearby threats, Injury, Isolation, unsafe environments
  - Increase: Shelter, Protection, trusted allies

### Social Needs
- **Belonging**
  - BasePriority: **1.8**
  - Decrease: Isolation, social rejection
  - Increase: social interaction, group participation

- **Affection**
  - BasePriority: **1.7**
  - Decrease: loneliness, relationship loss
  - Increase: friendship, family interaction, romantic interaction

- **Status**
  - BasePriority: **1.4**
  - Decrease: social defeat, low prestige, stagnation
  - Increase: praise, promotion, achievement

### Self Determination Needs
- **Autonomy**
  - BasePriority: **1.3**
  - Decrease: coercion, restriction, dependency
  - Increase: independent success, personal control

- **Achievement**
  - BasePriority: **1.2**
  - Decrease: stagnation, failure, lack of progress
  - Increase: skill growth, goal completion

- **Purpose**
  - BasePriority: **1.0**
  - Decrease: lack of goals, role confusion
  - Increase: goal progress, long-term projects, legacy building

### Exploratory Needs
- **Curiosity**
  - BasePriority: **1.2**
  - Decrease: repetition, boredom, lack of stimulation
  - Increase: discovery, exploration, learning

## Personality Modifiers (Need weighting)
Needs are amplified/reduced by personality traits.

| Need | Personality source |
|---|---|
| Belonging | Affiliation |
| Affection | Affiliation, Empathy |
| Status | Assertiveness, Contention |
| Curiosity | Curiosity |
| Purpose | Drive, Direction |
| Achievement | Drive |
| Safety | Reactivity |
| Autonomy | Differentiation |

### Scaling Formula
\[
\text{PersonalityWeight} = 1 + \left(\frac{\text{TraitValue}}{200}\right)
\]

TraitValue range: -100 to +100 → produces 0.5× to 1.5× multiplier.

## Need Decay Rates (Hourly update)
Needs update once per in-game hour.

Instead of increasing deprivation, time **decreases fulfillment value**.

| Need | Hourly Value Change | Type |
|---|---:|---|
| Hunger | -1.0 | Passive decay |
| Thirst | -1.5 | Passive decay |
| Energy | -1.2 while awake | Passive decay |
| Curiosity | -0.3 | Passive decay |
| Belonging | -0.2 | Passive decay |
| Affection | -0.2 | Passive decay |
| Achievement | -0.1 | Passive decay |
| Purpose | -0.05 | Passive decay |
| Status | Contextual / event | Dynamic drift |
| Autonomy | Contextual / event | Dynamic drift |
| Safety | Context / environmental | Context-driven |
| Health | External / biological | Event-driven |

Expose as tuning constants.

## Need Outputs
Published each update:

```csharp
public struct NeedOutput
{
    public NeedType Type;
    public float Value;
    public NeedState State;
    public float Pressure;
}
```

## Consuming Systems
### Emotion System
- Uses: Need Values, Need Pressure
- Purpose: determine emotional relevance

### Behavior System
- Uses: Need Pressure
- Purpose: strategy selection

### Memory System
- Uses: Need satisfaction + deprivation
- Purpose: determine memory significance

## Example (Critical Trigger)
Hunger Value = 15 (deprivation = 85)

- BasePriority = 3.5
- PersonalityWeight = 1.2
- NeedState = Critical (value ≤ 20)

Base pressure:

- `357 = (85 × 3.5) × 1.2`

Critical multiplier applied:

- FinalPressure = `357 × 1.5 = 535.5`

Result: behavior sharply prioritizes foraging/eating.

