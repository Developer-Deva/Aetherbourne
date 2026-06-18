These are not traditional RPG stats where they directly modify combat calculations. Instead, they are **layers of abstraction** that help drive behavior, skill growth, personality development, and emergent outcomes.

The hierarchy itself is interesting:

```
Core Stats (Inherited + Trainable)
├─ Strength
├─ Stamina
├─ Dexterity
├─ Perception
└─ Willpower

Advanced Stats (Derived)
├─ Endurance
├─ Prowess
├─ Finesse
├─ Conviction
└─ Vitality

Hidden Stats (Second-order Derived)
├─ Focus
├─ Insight
├─ Creativity
├─ Fortitude
└─ Momentum
```

---

## Core Stats

These should be the only stats that actually exist on the creature.

### Strength

Represents force production.

Affects:

* Carrying capacity
* Melee damage
* Mining
* Woodcutting
* Construction
* Grappling
* Throwing

### Stamina

Represents physical endurance.

Affects:

* Energy consumption
* Fatigue resistance
* Travel distance
* Work duration
* Recovery speed

### Dexterity

Represents coordination and precision.

Affects:

* Crafting quality
* Accuracy
* Dodging
* Tool use
* Harvesting efficiency

### Perception

Represents awareness.

Affects:

* Detection radius
* Resource spotting
* Threat recognition
* Tracking
* Memory acquisition

### Willpower

Represents mental persistence.

Affects:

* Goal commitment
* Fear resistance
* Pain tolerance
* Emotional stability
* Long-term planning

---

# Advanced Stats

Don't store them.

Compute dynamically:

```cpp
Endurance = (Strength + Stamina) / 2
Prowess   = (Strength + Dexterity) / 2
Finesse   = (Dexterity + Perception) / 2
Conviction= (Willpower + Perception) / 2
Vitality  = (Stamina + Willpower) / 2
```

These become useful because they represent broad competencies.

---

## Endurance

How long a creature can physically perform.

Used by:

* Hunting
* Long travel
* Combat duration
* Labor

---

## Prowess

Physical effectiveness.

Used by:

* Fighting
* Athletics
* Physical skill learning

---

## Finesse

Precision and awareness combined.

Used by:

* Crafting
* Gathering
* Tracking
* Tool mastery

---

## Conviction

Mental clarity and awareness.

Used by:

* Decision making
* Leadership
* Social influence
* Maintaining goals

---

## Vitality

Overall resilience.

Used by:

* Recovery
* Disease resistance
* Survival

---

# Hidden Stats

These are where things become really interesting.

These shouldn't be visible to players.

Instead they should influence emergent behavior.

---

## Focus

```cpp
Focus = (Endurance + Finesse) / 2
```

Represents sustained attention.

Affects:

* Learning speed
* Task completion rate
* Skill gain

Creatures with high Focus:

* Finish what they start
* Learn faster
* Switch tasks less often

---

## Insight

```cpp
Insight = (Prowess + Conviction) / 2
```

Represents understanding.

Affects:

* Decision quality
* Pattern recognition
* Tactical choices

High Insight creatures:

* Make smarter choices
* Predict danger better
* Select better actions

---

## Creativity

```cpp
Creativity = (Finesse + Vitality) / 2
```

Represents adaptability.

Affects:

* Discovering solutions
* Inventing behaviors
* Exploration

High Creativity creatures:

* Try unusual actions
* Explore more
* Develop unique strategies

---

## Fortitude

```cpp
Fortitude = (Endurance + Conviction) / 2
```

Represents perseverance.

Affects:

* Surviving hardship
* Emotional resilience
* Persistence

High Fortitude creatures:

* Don't quit easily
* Survive disasters
* Continue goals despite setbacks

---

## Momentum

```cpp
Momentum = (Vitality + Prowess) / 2
```

Represents action tendency.

Affects:

* Initiative
* Activity level
* Goal pursuit

High Momentum creatures:

* Act quickly
* Explore aggressively
* Accomplish more during their lifetime

---

# The interesting part

**Personality emerges partly from these hidden stats.**

Not through genetics directly.

Instead:

```cpp
Personality =
(
Genetics
+
Memories
+
Experiences
+
Hidden Stats
)
```

Example:

Two creatures can have identical personalities at birth.

One grows into:

* High Focus
* High Fortitude

because it trained constantly.

The other develops:

* High Creativity
* High Momentum

because it spent its life exploring.

Now they begin making different decisions and slowly diverge into different personalities despite sharing similar genetics.

This aligns with the philosophy:

> Genetics determine inherited capabilities.
>
> Personality emerges from experience.

The hidden stats become the bridge between raw capabilities and the emergent personalities that develop over a creature's lifetime.

