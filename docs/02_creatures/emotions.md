# Emotion System

**Description:** Emotional state, emotional processing, and emotional influence systems for Aetherbourne

**Last Updated:** 2026-06-17

---

# Overview

Emotions are the bridge between events and memories.

Needs drive behavior.

Events create experiences.

Emotions determine how those experiences are perceived.

The relationship between systems is:

```text
Need
↓
Goal
↓
Action
↓
Event
↓
Emotion
↓
Memory
↓
Personality
↓
Future Behavior
```

Events do not directly create memories.

Events first generate emotional responses.

Those emotional responses determine whether an experience is remembered, forgotten, or becomes life-changing.

---

# Design Philosophy

Emotions are not personality.

Emotions are temporary internal states.

Personality represents long-term behavioral tendencies.

Two creatures may experience the same event but produce different emotional responses because of:

* Genetics
* Personality
* Memories
* Relationships
* Current Needs
* Current Emotional State

This allows creatures to experience the world differently despite sharing similar circumstances.

---

# Emotional Model

Aetherbourne uses a modified version of Plutchik's emotional model.

Rather than storing individual emotions directly, creatures store a small number of emotional axes.

Complex emotions emerge from combinations of these axes.

This keeps the system compact, expressive, and computationally efficient.

---

# Primary Emotional Axes

The emotion system contains three global bipolar axes.

Each axis ranges from:

```text
-100 to +100
```

Negative values represent one emotional extreme.

Positive values represent the opposing emotional extreme.

---

## Valence

```text
Sadness (-100) ↔ Joy (+100)
```

Represents emotional positivity or negativity.

Examples:

```text
-100 = Grief
 -50 = Sadness
   0 = Neutral
 +50 = Happiness
+100 = Ecstasy
```

Influences:

* Mood
* Social behavior
* Motivation
* Memory formation

---

## Threat Response

```text
Fear (-100) ↔ Anger (+100)
```

Represents how creatures respond to threats and adversity.

Examples:

```text
-100 = Terror
 -50 = Fear
   0 = Neutral
 +50 = Anger
+100 = Rage
```

Influences:

* Fight-or-flight behavior
* Aggression
* Risk tolerance
* Conflict decisions

---

## Expectation

```text
Surprise (-100) ↔ Anticipation (+100)
```

Represents certainty about future events.

Examples:

```text
-100 = Amazement
 -50 = Surprise
   0 = Neutral
 +50 = Anticipation
+100 = Vigilance
```

Influences:

* Exploration
* Planning
* Learning
* Decision making

---

# Arousal

Arousal is stored separately from emotional axes.

Range:

```text
0 to 100
```

Represents overall emotional activation.

Examples:

```text
0   = Calm
25  = Relaxed
50  = Alert
75  = Excited
100 = Frenzied
```

Arousal does not determine emotional direction.

Instead it determines emotional intensity.

Example:

```text
Valence = +60
Arousal = 20
```

Produces:

```text
Contentment
```

While:

```text
Valence = +60
Arousal = 90
```

Produces:

```text
Ecstatic Joy
```

---

# Relationship Trust

Trust is not a global emotion.

Trust exists between entities.

Each relationship stores its own trust value.

Range:

```text
-100 to +100
```

```text
Disgust (-100) ↔ Trust (+100)
```

Examples:

```text
Wolf A trusts Wolf B.

Trust = +80
```

```text
Wolf A hates Wolf C.

Trust = -75
```

Trust influences:

* Cooperation
* Friendship
* Romance
* Leadership
* Group behavior

Because trust is relationship-specific, it is stored within the relationship system rather than the emotion system.

---

# Emotional State

Each creature stores:

```cpp
struct EmotionalState
{
    float Valence;
    float ThreatResponse;
    float Expectation;

    float Arousal;
}
```

These values continuously change over time.

---

# Emotional Baselines

Creatures possess inherited emotional tendencies.

These values are influenced by genetics.

Example:

```cpp
struct EmotionalTraits
{
    float ValenceBaseline;

    float ThreatBaseline;

    float ExpectationBaseline;

    float ArousalBaseline;
}
```

Baselines represent the emotional state a creature gradually returns toward.

---

## Optimistic Creature

```text
ValenceBaseline = +20
```

Naturally trends toward positive emotions.

---

## Pessimistic Creature

```text
ValenceBaseline = -20
```

Naturally trends toward negative emotions.

---

## Timid Creature

```text
ThreatBaseline = -25
```

More likely to respond with fear.

---

## Aggressive Creature

```text
ThreatBaseline = +25
```

More likely to respond with anger.

---

# Emotional Sensitivity

Creatures also inherit emotional responsiveness.

```cpp
struct EmotionalTraits
{
    float ValenceSensitivity;

    float ThreatSensitivity;

    float ExpectationSensitivity;

    float ArousalSensitivity;

    float EmotionalDecayRate;
}
```

Sensitivity determines how strongly events affect emotions.

---

## Low Sensitivity

```text
Insult Event

Valence Change = -10
```

---

## High Sensitivity

```text
Insult Event

Valence Change = -40
```

---

# Emotional Decay

Emotions naturally fade over time.

Creatures gradually return toward their inherited baselines.

Example:

```text
Current Valence = -80

Baseline Valence = +10
```

Over time:

```text
-80
↓
-50
↓
-20
↓
+10
```

Decay rates vary between individuals.

---

# Complex Emotions

Complex emotions are never stored directly.

They are derived from combinations of emotional axes.

---

## Love

```text
Joy
+
Relationship Trust
```

Example:

```text
Valence = +70
Trust = +80
```

Produces:

```text
Love
```

---

## Hope

```text
Joy
+
Anticipation
```

Example:

```text
Valence = +60
Expectation = +50
```

Produces:

```text
Hope
```

---

## Anxiety

```text
Fear
+
Anticipation
```

Example:

```text
Threat = -70
Expectation = +60
```

Produces:

```text
Anxiety
```

---

## Awe

```text
Fear
+
Surprise
```

Example:

```text
Threat = -50
Expectation = -60
```

Produces:

```text
Awe
```

---

## Curiosity

```text
Trust
+
Surprise
```

Example:

```text
Trust = +50
Expectation = -40
```

Produces:

```text
Curiosity
```

---

Complex emotions emerge naturally from combinations rather than requiring separate storage.

---

# Event Response

Events generate emotional changes.

Example:

```text
Attacked by Predator
```

May produce:

```text
ThreatResponse -60

Arousal +50
```

Result:

```text
Fear
```

---

Example:

```text
Won Competition
```

May produce:

```text
Valence +50

Arousal +25
```

Result:

```text
Joy
```

---

Example:

```text
Unexpected Discovery
```

May produce:

```text
Expectation -50

Valence +20
```

Result:

```text
Surprise
+
Excitement
```

---

# Emotional Influence on Memory

Emotion determines memory strength.

Highly emotional experiences are remembered longer.

Formula:

```text
MemoryStrength =
EventSeverity
× EmotionalIntensity
× PersonalRelevance
```

Examples:

```text
Finding a Berry

Low Emotion
↓
Weak Memory
```

```text
Losing a Parent

High Emotion
↓
Powerful Memory
```

---

# Emotional Influence on Personality

Emotions do not directly change personality.

Repeated emotional experiences create memories.

Memories gradually influence personality over time.

Example:

```text
Repeated Fear
↓
Fearful Memories
↓
Reduced Confidence
↓
Personality Drift
```

Or:

```text
Repeated Success
↓
Positive Memories
↓
Increased Confidence
↓
Personality Drift
```

---

# Emotion → Memory → Personality Pipeline

```text
Event
↓
Emotion
↓
Memory Formation
↓
Memory Accumulation
↓
Personality Drift
↓
Behavioral Change
```

Emotions are temporary.

Memories are persistent.

Personality is enduring.

This separation allows creatures to be shaped by their experiences while remaining consistent individuals throughout their lives.
