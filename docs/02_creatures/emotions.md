# Emotion System

**Description:** Defines how creatures internally appraise events, generate affective states, regulate emotion, and turn emotionally significant moments into memory in Aetherbourne.
**Last Updated:** 2026-06-21
---

# Overview

The emotion system is the internal affective architecture for creatures in Aetherbourne. It interprets events, updates emotional state, influences decision pressure, and decides whether an experience is strong enough to affect memory.

Emotion is not a single value and not a replacement for behavior. It is a modular system made of smaller internal subsystems that together produce subjective response, emotional decay, regulation, and memory gating
---

# Design Philosophy

* Emotion should be internally modular, not a single flat mood value.
* Emotion should be based on appraisal of events and internal context.
* The same event should produce different emotional results in different creatures.
* Emotion should influence behavior without directly choosing actions.
* Emotion should feed memory selectively, not automatically.
* Emotion should decay, stabilize, or intensify depending on context.
* The system should support both rapid reaction and longer emotional carryover.

---

# Core Concepts

## Emotion Modules

The emotion system is composed of smaller internal modules. Each module can be understood, tuned, and tested independently.

### Event Appraiser

The event appraiser examines an event and determines its emotional significance.

It should consider:

* Event severity.
* Personal relevance.
* Social context.
* Relationship context.
* Threat level.
* Reward value.
* Loss value.
* Novelty.
* Goal alignment.

Its output is an appraisal profile.

### Relevance Evaluator

The relevance evaluator determines how much the event matters to the creature right now.

It should consider:

* Active needs.
* Active goals.
* Recent memories.
* Current commitments.
* Personality bias.
* Current emotional state.

Its output is a relevance weight used by later modules.

### Emotion Composer

The emotion composer converts appraisal results into active emotional state.

It should update values such as:

* Valence.
* Arousal.
* Fear.
* Joy.
* Anger.
* Shame.
* Sadness.
* Relief.
* Curiosity.
* Attachment.

Its output is the creature’s current affective state.

### Personality Amplifier

The personality amplifier modifies emotion strength based on stable personality traits.

It should consider:

* Sensitivity.
* Reactivity.
* Regulation.
* Elasticity.
* Empathy.
* Willpower.
* Other relevant hidden tendencies.

Its output is a multiplier or damping factor applied to emotional intensity.

### Regulation Manager

The regulation manager reduces or reshapes emotion based on the creature’s ability to manage itself.

It should consider:

* Willpower.
* Current fatigue.
* Current stress.
* Prior emotional load.
* Environment safety.
* Supportive social context.

Its output is the adjusted emotional state after regulation.

### Decay and Recovery Handler

The decay and recovery handler determines how emotional states fade or persist over time.

It should consider:

* Time since trigger.
* Intensity of the emotion.
* Whether the emotion is being refreshed.
* Whether the creature is in a safe or unsafe context.
* Whether supporting events are happening.

Its output is reduced, sustained, or refreshed emotion.

### Memory Gate

The memory gate determines whether an emotional event should become a stored memory.

It should consider:

* Emotional intensity.
* Emotional duration.
* Event significance.
* Repetition.
* Personality sensitivity.
* Relevance to identity, safety, or relationships.

Its output is store, reinforce, ignore, or partially store.

### Expression / Output Layer

The output layer translates emotion into behavior-facing signals.

It should produce:

* Current mood modifiers.
* Action bias hints.
* Social expression cues.
* Attention shifts.
* Memory tags.

Its output is a compact emotional signal usable by behavior and memory.

## Emotional Pipeline

Emotion should follow a modular processing path rather than a single update step.

```text
Event Appraiser
→ Relevance Evaluator
→ Emotion Composer
→ Personality Amplifier
→ Regulation Manager
→ Decay and Recovery Handler
→ Memory Gate
→ Output Layer
```

This pipeline allows each emotional step to be independently tuned.

## Inputs

Emotion should consume a small but expressive set of inputs.

### External Inputs

* Event type.

* Event severity.
* Event source.
* Target of the event.
* Social context.
* Environmental context.

### Internal Inputs

* Current needs.

* Current goals.
* Personality axes.
* Memory traces.
* Current emotional state.
* Fatigue.
* Stress.
* Relationships.
* Hidden stats.

## Emotional State Model

Emotion should be represented as a structured state rather than a single number.

### Recommended Dimensions

* **Valence**: Positive or negative tone.

* **Arousal**: Activation or intensity level.
* **Fear**: Threat response.
* **Joy**: Positive reward response.
* **Anger**: Opposition or frustration response.
* **Shame**: Self-evaluative social pain.
* **Sadness**: Loss response.
* **Relief**: Threat reduction or burden release.
* **Curiosity**: Novelty-seeking response.
* **Attachment**: Bond-oriented response.

The exact implementation can vary, but the emotional state should be rich enough to support behavior bias and memory gating.

## Appraisal Logic

Emotion should be based on interpreted meaning, not just raw event data.

### Appraisal Factors

* **Severity**: How strong the event is objectively.

* **Relevance**: How much it matters to the creature.
* **Congruence**: Whether it supports or blocks current goals.
* **Agency**: Whether the creature caused the event or merely experienced it.
* **Social Meaning**: Whether the event affects relationships or status.
* **Novelty**: Whether the event is unexpected.
* **Loss / Gain**: Whether the creature lost or gained something meaningful.

### Example

A creature losing food:

* Low relevance may produce mild frustration.
* High relevance may produce fear, anger, or panic.
* A well-regulated creature may feel the same event with less emotional spike.
* A highly sensitive creature may form a stronger lasting memory.

## Emotional Intensity

Emotional intensity should determine how strongly an event changes the creature.

### General Formula

```text
EI = EventSeverity × PersonalRelevance × PersonalityAmplifier
```

Where:

* **EventSeverity** is the objective impact.
* **PersonalRelevance** is how much the event matters.
* **PersonalityAmplifier** is affected by personality, hidden stats, and current state.

### Notes

* Strong emotion should be harder to ignore.

* Low-intensity emotion should fade quickly.
* Intensity should help determine whether memory is formed.
* Repeated moderate events can matter as much as one large event.

## Regulation

Regulation is the internal control layer that prevents emotion from fully taking over.

### Regulation Effects

* Reduce emotional spikes.

* Delay immediate reaction.
* Allow reappraisal.
* Prevent panic loops.
* Stabilize decision-making under stress.

### Factors That Improve Regulation

* High willpower.

* Low fatigue.
* Safe environment.
* Supportive relationships.
* Repeated successful emotional recovery.

## Decay and Recovery

Emotion should not remain static.

### Decay

* Minor emotion fades quickly.

* Strong emotion fades slowly.
* Refreshed emotion persists longer.
* Repeated triggers can prolong the state.

### Recovery

* Rest.

* Safety.
* Comfort.
* Positive social support.
* Successful goal completion.
* Time without triggering events.

## Memory Gate

Emotion should not always become memory.

### Storage Conditions

A memory is more likely to form when:

* Intensity is high.
* Duration is long.
* The event is personally relevant.
* The event is socially meaningful.
* The event is identity-shaping.
* The event is repeated.

### Output to Memory

The gate should output:

* Store as episodic memory.
* Reinforce existing memory.
* Store as semantic knowledge.
* Store as relational memory.
* Ignore as insignificant.

## Output to Behavior

Emotion should feed behavior as a bias layer.

### Behavior Inputs from Emotion

* Current emotional state.

* Emotional intensity.
* Emotional direction.
* Emotional duration.
* Emotional tags.

### Common Behavior Effects

* Fear biases toward retreat and caution.

* Anger biases toward confrontation.
* Joy biases toward exploration and repetition.
* Shame biases toward withdrawal or repair.
* Curiosity biases toward investigation.
* Attachment biases toward proximity and protection.

Emotion should make certain actions more attractive, but not make them inevitable.

## Output to Memory

Emotion should also help annotate stored experience.

### Memory Tags

* Fear.

* Joy.
* Anger.
* Shame.
* Grief.
* Relief.
* Admiration.
* Trust.
* Betrayal.
* Attachment.

These tags help future retrieval and emotional association.

## Personality and Stat Interaction

Emotion should be shaped by stable creature traits.

### Personality Effects

* Sensitivity increases emotional response.

* Reactivity increases emotional speed and amplitude.
* Regulation reduces volatility.
* Elasticity improves recovery.
* Empathy intensifies social suffering or concern.
* Principle may amplify guilt or moral discomfort.
* Continuity may intensify self-consistent emotional narratives.

### Stat Effects

* Willpower improves regulation.

* Perception improves recognition of emotional events.
* Stamina improves recovery from stress.
* Focus supports emotional control during sustained activity.

## Emergent Emotion Loops

Emotion should create self-reinforcing patterns over time.

### Stress Loop

Repeated threat increases fear, which increases caution, which reduces exposure, which changes future emotional history.

### Attachment Loop

Repeated comfort increases attachment, which increases proximity seeking, which creates more attachment opportunities.

### Anger Loop

Repeated blocked goals increase frustration and anger, which increases confrontational responses, which can create more conflict.

### Recovery Loop

Successful regulation increases future resilience, which makes later emotional recovery easier.

### Memory Loop

Strong emotional events form memories, memories bias future appraisal, and future appraisal changes emotional response.

## Examples

### Example: Food Loss

```text
Event: Food is stolen.
Appraisal: High severity, high relevance, negative goal congruence.
Emotion: Fear + anger + frustration.
Memory Gate: Store if intensity is high enough.
Behavior Bias: Flee, defend, search, retaliate.
```

### Example: Social Praise

```text
Event: Another creature praises the subject.
Appraisal: Moderate severity, high social relevance, positive gain.
Emotion: Joy + attachment + relief.
Memory Gate: Store if the creature values social approval.
Behavior Bias: Approach, repeat, bond.
```

### Example: Injury

```text
Event: Creature is wounded.
Appraisal: High severity, high relevance, negative loss.
Emotion: Fear + pain-linked distress.
Memory Gate: Likely store strongly.
Behavior Bias: Retreat, recover, avoid similar danger.
```

## Implementation / Notes

* Keep emotion internally modular and event-driven.
* Use appraisal as the bridge between facts and feelings.
* Separate emotional generation from emotional regulation.
* Let memory be gated by emotional significance, not by event type alone.
* Keep the emotional state rich enough for behavior but compact enough to debug.
* Allow the same event to generate different emotions in different creatures.
* Use emotion as a biasing and storage layer, not as a direct action selector.

---

## Canonical Consolidation Notes

Material from the previous staged emotion planning note was merged here, making this file the canonical home for the system. During implementation, prefer the contracts and terminology in this file over deleted staging notes.

## Merged Legacy Planning Content

## Emotion System — Event Appraisal → Discrete Emotions + Memory Gating

**Last Updated:** 2026-06-26

### Overview
The Emotion System converts events into **temporary affective states**.

Emotions are:

- temporary
- dynamic
- context-sensitive
- influenced by personality
- influential but not deterministic

It does not select actions.

Instead, it modifies:

- strategy utility
- attention
- memory formation
- relationship updates

### Simulation Role
Answers: **“How does the creature currently feel about what is happening?”**

Inputs:

- events
- needs
- personality
- memories
- relationships

Outputs:

- emotional state
- emotional intensity
- behavior biases
- memory significance

### Processing Order (On significant event)
Event → Appraisal → Relevance Evaluation → Emotion Generation → Personality Amplification → Regulation → State Update → Memory Gate → Behavior Output

### Emotional State Data Model
```csharp
public class EmotionalState
{
    public float Valence;
    public float Arousal;

    public float Fear;
    public float Joy;
    public float Anger;
    public float Shame;
    public float Sadness;
    public float Relief;
    public float Curiosity;
    public float Attachment;
}
```

### Emotional Range
- emotions clamp to [0, 100]
- Meaning: 0 absent, 100 extremely intense

Valence is a conceptual dimension:
- Valence range: -100 to +100 (not necessarily constrained to [0,100] in the discrete values list)

Arousal range: 0 to 100.

### Primary Emotions & Their Sources
#### Fear
Generated by:
- threat, danger, injury, vulnerability

Biases:
- fleeing, guarding, caution

#### Joy
Generated by:
- success, reward, affection, safety

Biases:
- socializing, exploring, repetition

#### Anger
Generated by:
- obstruction, injustice, harm, betrayal

Biases:
- fighting, challenging, retaliation

#### Shame
Generated by:
- social failure, embarrassment, moral violation

Biases:
- withdrawal, apology, repair

#### Sadness
Generated by:
- loss, separation, failure

Biases:
- recovery, reflection, reduced activity

#### Relief
Generated by:
- threat reduction, problem resolution

Biases:
- recovery, resting

#### Curiosity
Generated by:
- novelty, uncertainty, discovery opportunities

Biases:
- exploring, investigating

#### Attachment
Generated by:
- positive social interaction, repeated comfort, trust

Biases:
- bonding, parenting, courting, proximity seeking

### Event Appraisal
Appraisal converts events into factors:

```csharp
public class Appraisal
{
    public float Severity;
    public float Relevance;
    public float Congruence;
    public float Novelty;
    public float Threat;
    public float Reward;
    public float Loss;
    public float SocialImpact;
}
```

Appraisal range: 0–100.

### Relevance Evaluation
\[
\text{Relevance} = \text{NeedImportance} \times \text{GoalImportance} \times \text{RelationshipImportance} \times \text{MemoryImportance}
\]

Output range: 0.0 – 2.0

### Emotional Intensity
\[
\text{Intensity} = \frac{\text{Severity} \times \text{Relevance}}{100}
\]

Output: 0–100.

### Personality Amplification
\[
\text{Amplifier} = 1 + \frac{\text{TraitValue}}{200}
\]

TraitValue: -100 to +100 → produces 0.5× to 1.5×.

FinalIntensity:
- `FinalIntensity = BaseIntensity × Amplifier`

### Emotion Generation (Example Mapping)
Appraisal factors contribute to discrete emotions.

Example:

- Threat=80 → Fear += 80 × IntensityModifier

### Regulation
Regulation reduces emotional spikes.

Inputs:
- regulation
- elasticity
- fatigue
- stress
- safety
- social support

\[
\text{RegulationStrength} = \frac{\text{Regulation} \times \text{Elasticity}}{200}
\]

Emotion reduction:
- `Emotion = Emotion × (1 - RegulationStrength)`

### Emotional Decay
Emotions decay every simulation hour.

Recommended default:
- DecayRate = 0.95 (5% loss per hour)

### Emotional Refreshing (Event interruptions)
Emotion decay may be interrupted by:
- repeated events
- memory recall
- relationship interactions
- active threats

Example:
- `Fear = CurrentFear + NewFear` (clamp 0–100)

### Mood Generation
Mood is slower than emotions.

```csharp
public class Mood
{
    public float Positive;
    public float Negative;
    public float Stability;
}
```

Recommended smoothing:
- `Mood = 90% PreviousMood + 10% CurrentEmotion`

### Memory Gate (Emotion → Memory significance)
\[
\text{MemoryScore} = \text{Intensity} \times \text{Duration} \times \text{Relevance}
\]

If `MemoryScore > Threshold`, create memory.

Recommended threshold: 50

### Emotional Tags
Memories receive emotional tags (examples):

- Fear, Joy, Anger, Shame, Sadness, Relief, Attachment, Trust, Betrayal, Admiration

Tags influence future retrieval and appraisal.

### Behavior Outputs (Utility Bias)
Emotion does not choose strategies; it biases utilities.

Example:
- Fear → fleeing +50%
- Anger → fighting +50%
- Joy → socializing +25%
- Curiosity → exploring +50%

Suggested:
- `StrategyUtility = BaseUtility × EmotionModifier`

### Relationship Outputs
Emotion can affect relationship values.

Examples:
- Attachment → affection gain
- Anger → trust loss
- Joy → affection gain
- Shame → repair attempts

### Consuming Systems
- **Behavior System** consumes emotional state/mood to modify strategy utility
- **Memory System** consumes emotional intensity and emotional tags to decide memory creation
- **Relationship System** consumes attachment/joy/anger/shame to update relationship values

### Gemini Additional Commentary Captured Here
Two important implementation cautions present in the previous raw conversation note:

1. **Valence/Arousal vs Discrete emotion sync**
   - If valence/arousal are assigned independently from discrete emotions, you can get contradictory states (e.g., high fear + high positive valence).
   - Suggested fix: derive valence/arousal from discrete emotions (fear/anger/shame/sadness push valence down; joy/relief/attachment push valence up).

2. **Multiplicative behavior bias can veto unintentionally**
   - `BaseUtility × EmotionMultiplier` can remain 0 if BaseUtility is near zero.
   - Suggested mix: additive flat bonus + multiplier, e.g. `(BaseUtility + EmotionalFlatBonus) × EmotionalMultiplier`.
