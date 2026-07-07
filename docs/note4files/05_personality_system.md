# Personality System — Long-Term Drift with Developmental Domains

**Last Updated:** 2026-06-27

## Overview
The Personality System represents stable psychological tendencies.

Personality changes slowly through:

- genetics
- aethersigns
- life experiences
- relationships
- memories
- aging

It is intended to be significantly more stable than needs, emotions, or behaviors.

## Simulation Role
Answers: **“Who is this creature?”**

Personality does not directly select actions.

Instead, it modifies:

- need weighting
- emotional intensity
- emotional regulation
- strategy utility
- memory formation
- relationship development
- personality drift

## Processing Order (Slow cadence)
Recommended update frequency: **once per in-game day**.

Processing:

- Memory Review
- Relationship Influence
- Personality Drift
- Domain Unlock Checks
- Publish Personality Outputs

## Data Model (Axis Storage)
Each axis stores:

```csharp
public class PersonalityAxis
{
    public float Value;
    public float Resistance;
}
```

- Value range: -100 to +100
  - -100 extremely low
  - 0 neutral
  - +100 extremely high
- Resistance range: 0.0 to 2.0
  - 0.0 changes easily
  - 2.0 extremely resistant

## Personality Structure (20 axes)
```csharp
public class Personality
{
    // Infant
    public PersonalityAxis Reactivity;
    public PersonalityAxis Elasticity;

    // Toddler
    public PersonalityAxis Affiliation;
    public PersonalityAxis Assertiveness;

    // Child
    public PersonalityAxis Curiosity;
    public PersonalityAxis Structure;
    public PersonalityAxis Sensitivity;
    public PersonalityAxis Regulation;

    // Teen
    public PersonalityAxis Continuity;
    public PersonalityAxis Differentiation;
    public PersonalityAxis Cooperation;
    public PersonalityAxis Contention;

    // Young Adult
    public PersonalityAxis Drive;
    public PersonalityAxis Direction;
    public PersonalityAxis Empathy;
    public PersonalityAxis Principle;

    // Adult
    public PersonalityAxis Breadth;
    public PersonalityAxis Depth;

    // Elder
    public PersonalityAxis Generativity;
    public PersonalityAxis Endurance;
}
```

## Developmental Domains (Unlock by Age)
Only unlocked domains may drift.

- **Infant:** Reactivity, Elasticity (Birth)
- **Toddler:** Affiliation, Assertiveness (Toddler stage)
- **Child:** Curiosity, Structure, Sensitivity, Regulation (Child stage)
- **Teen:** Continuity, Differentiation, Cooperation, Contention (Teen stage)
- **Young Adult:** Drive, Direction, Empathy, Principle (Young adult stage)
- **Adult:** Breadth, Depth (Adult stage)
- **Elder:** Generativity, Endurance (Elder stage)

## Aethersign Effects
### State → Domain affinity
- Matching domains: **-10% Personality Resistance**

### Modality → baseline resistance scaling
- Catalyst resistance: × 0.8
- Anchor resistance: × 1.2
- Current: ±15% based on environmental stability

### Drive → memory weighting
- matching memories: × 1.25 drift weight

## Personality Drift (Memory-driven)
Personality changes through emotionally significant experiences stored in memory.

### Drift Inputs
- Memory intensity
- Memory repetition
- Relationship influence
- Aethersign modifiers
- Existing resistance

### Drift Formula
\[
\text{Drift} = \text{MemoryWeight} \times \text{EmotionalIntensity} \times \text{Repetition} \times \text{AethersignModifier}
\]

\[
\text{FinalDrift} = \frac{\text{Drift}}{\text{Resistance}}
\]

## Personality Resistance
Resistance reduces the magnitude of change:

\[
\text{Resistance} = \text{BaseResistance} \times \text{ModalityModifier} \times \text{AxisResistance}
\]

Recommended default BaseResistance = 1.0

## Personality Outputs
Published continuously:

```csharp
public struct PersonalityOutput
{
    public Dictionary<string, float> AxisValues;
}
```

## Integration Examples
### Need System
- Affiliation → Belonging weight
- Drive → Achievement weight
- Direction → Purpose weight
- Differentiation → Autonomy weight

### Emotion System
- Reactivity → emotional intensity baseline
- Sensitivity → emotional gain/spike size
- Regulation → rate of control/suppression
- Elasticity → recovery/cooldown speed
- Empathy → social emotional amplification

### Behavior System
- Cooperation → social strategy utility
- Contention → conflict strategy utility
- Curiosity → exploration utility
- Drive → work strategy utility

### Memory System
- Sensitivity → memory formation probability
- Continuity → identity memory weight
- Empathy → social/relationship memory weight

### Relationship System
- Affiliation → bond formation rate
- Empathy → trust growth scaling
- Contention → rivalry growth scaling
- Generativity → parenting/community investment scaling

## Emergent Personality Expressions (Derived Labels)
Not stored values; derived from axis overlaps.

- Friendly: high Affiliation + high Cooperation
- Aggressive: high Contention + high Reactivity
- Loyal: high Affiliation + high Continuity
- Curious: high Curiosity
- Honorable: high Principle + high Empathy
- Greedy: low Empathy + high Achievement + high Status (from needs)

## Design Goals
- long-term stability
- slow personality drift
- strong developmental progression
- emergent social behavior
- memory-driven growth
- aethersign influence without determinism
- integration clarity across systems

