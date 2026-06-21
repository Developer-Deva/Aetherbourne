# Needs System

**Description:** Motivation and behavioral drive system for creatures in Aetherbourne

**Last Updated:** 2026-06-21

---

# Overview

Needs are the primary source of creature motivation.

Needs create pressure that drives goal selection and behavior.

Needs do not directly determine actions. Instead they influence decision making through urgency and priority.

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
Future Decisions
```

Needs create motivation.

Personality determines how creatures respond to that motivation.

---

# Design Philosophy

Needs represent conditions that creatures actively attempt to satisfy or maintain.

A need should:

* Generate goals
* Influence behavior
* Produce emotional responses when unmet
* Affect long-term personality development through experiences

Needs are not emotions.

Needs are not memories.

Needs are not personality traits.

They are motivational forces that drive behavior.

---

# Need Categories

Needs are divided into two behavioral groups.

## Drive Needs

Drive Needs increase over time.

They represent urges that build until satisfied.

Drive Needs are critical at:

```text
100
```

Examples:

* Hunger
* Thirst
* Bladder
* Curiosity
* Mating

---

## Maintenance Needs

Maintenance Needs decrease over time.

They represent states that must be maintained.

Maintenance Needs are critical at:

```text
0
```

Examples:

* Health
* Energy
* Belonging
* Purpose
* Fulfillment

---

# Universal Need Scale

All needs produce a normalized urgency value.

```cpp
Urgency = 0 - 100
```

The AI uses urgency rather than raw values.

Examples:

| Need   | Value | Urgency |
| ------ | ----- | ------- |
| Hunger | 90    | 90      |
| Thirst | 30    | 30      |
| Health | 20    | 80      |
| Energy | 10    | 90      |

This allows all needs to compete within a shared decision-making framework.

---

# Need States

All needs use the same urgency thresholds.

| Range  | State     |
| ------ | --------- |
| 0-25   | Satisfied |
| 26-50  | Aware     |
| 51-75  | Concerned |
| 76-100 | Urgent    |

Creatures become increasingly likely to prioritize needs as urgency rises.

---

# Need Weight

Need importance varies between creatures.

Each need has a weight modifier.

```cpp
NeedWeight
```

Weight may be influenced by:

* Genetics
* Species
* Age
* Personality
* Memories
* Relationships

Example:

```text
Curious Explorer

Curiosity Weight = 1.5
Belonging Weight = 0.7
```

Weights modify how strongly a creature responds to a need.

---

# Need Arbitration

Needs are not democratic.

Creatures do not average needs together.

Higher-priority needs override lower-priority needs when urgency becomes critical.

General priority order:

```text
Health
↓
Thirst
↓
Hunger
↓
Energy
↓
Bladder
↓
Belonging
↓
Purpose
↓
Fulfillment
↓
Mating
↓
Curiosity
```

Urgency and weight still influence decisions.

Example:

```text
Hunger = 90
Curiosity = 95

Result:
Creature eats first.
```

Example:

```text
Hunger = 40
Curiosity = 95

Result:
Creature may continue exploring.
```

This creates believable survival behavior while still allowing individual personality differences.

---

# Biological Needs

These needs originate from physical survival and reproduction.

---

## Health

**Type:** Maintenance

Represents physical condition and survivability.

Maintained by:

* Rest
* Healing
* Medicine
* Avoiding injury

Reduced by:

* Injury
* Disease
* Starvation
* Dehydration
* Environmental hazards

Low Health may override nearly all other needs.

---

## Hunger

**Type:** Drive

Represents the biological need for food.

Satisfied by:

* Eating food

Consequences of neglect:

* Reduced Energy
* Reduced recovery
* Health loss
* Death

---

## Thirst

**Type:** Drive

Represents the biological need for water.

Satisfied by:

* Drinking water

Consequences of neglect:

* Reduced performance
* Health loss
* Death

Thirst generally rises faster than Hunger.

---

## Energy

**Type:** Maintenance

Represents physical and mental stamina.

Maintained by:

* Rest
* Sleep

Reduced by:

* Movement
* Labor
* Combat
* Mental effort

Low Energy reduces overall effectiveness.

---

## Bladder

**Type:** Drive

Represents the need to relieve bodily waste.

Satisfied by:

* Urination

Consequences of neglect:

* Discomfort
* Reduced Focus
* Behavioral disruption

Severity depends on species.

---

## Mating

**Type:** Drive

Represents reproductive instinct.

Satisfied by:

* Successful mating

Influences:

* Courtship behavior
* Mate seeking
* Pair formation

Relationships and family systems are handled separately.

---

# Psychological Needs

These needs originate from cognition, social behavior, and long-term wellbeing.

---

## Belonging

**Type:** Maintenance

Represents social connectedness.

Maintained by:

* Friendships
* Family bonds
* Community membership
* Positive interactions

Reduced by:

* Isolation
* Rejection
* Loss
* Betrayal

Low Belonging may contribute to loneliness and reduced Fulfillment.

---

## Curiosity

**Type:** Drive

Represents a desire for discovery and learning.

Satisfied by:

* Exploration
* Discoveries
* New experiences
* Learning skills
* Acquiring knowledge

High Curiosity drives exploration and experimentation.

---

## Purpose

**Type:** Maintenance

Represents a sense of direction and meaning.

Maintained by:

* Pursuing goals
* Making progress
* Contributing to a community
* Achieving meaningful milestones

Reduced by:

* Stagnation
* Repeated failure
* Lack of goals

Purpose answers:

```text
"What am I working toward?"
```

---

## Fulfillment

**Type:** Maintenance

Represents overall life satisfaction.

Maintained by:

* Positive relationships
* Accomplishments
* Purpose
* Personal growth

Reduced by:

* Isolation
* Failure
* Unmet goals
* Chronic hardship

Fulfillment answers:

```text
"Am I satisfied with my life?"
```

Purpose and Fulfillment are related but distinct.

A creature may possess:

```text
High Purpose
Low Fulfillment
```

or

```text
Low Purpose
High Fulfillment
```

depending on circumstances.

---

# Need Interactions

Needs influence one another.

Examples:

```text
Low Energy
↓
Curiosity growth slows
```

```text
Low Belonging
↓
Fulfillment decays faster
```

```text
Low Purpose
↓
Fulfillment decays faster
```

```text
Low Health
↓
Energy recovery slows
```

```text
Curiosity satisfied
↓
Purpose increases
```

These interactions create long-term behavioral feedback loops.

---

# Species Variation

All creatures possess the same needs.

Species differ through modifiers rather than unique need systems.

Species may modify:

```cpp
NeedWeight
NeedDecayRate
NeedRecoveryRate
```

Example:

```text
Wolf

Belonging Weight = High
```

```text
Bear

Belonging Weight = Low
```

```text
Fox

Curiosity Weight = High
```

This allows diverse behaviors while maintaining a unified simulation framework.

---

# Need → Story Pipeline

Needs are the foundation of emergent behavior.

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
Behavior
↓
Story
```

Stories emerge from creatures attempting to satisfy their needs within a changing world.

---

## Design Philosophy

Needs should create clear motivational pressure while allowing personality and context to shape final decisions.

## Core Concepts

- Drive vs maintenance needs
- Shared urgency scale
- Weight modifiers for species and personality

## Implementation / Notes

* Use normalized urgency values so different needs can compete consistently in decision-making.
