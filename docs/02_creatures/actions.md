# Actions System

**Description:** Defines modular creature actions, their requirements, costs, effects, and tags for behavior and simulation.

**Last Updated:** 2026-06-21

---

## Overview

The actions system defines the verbs creatures can attempt in Aetherbourne. Actions are modular units of behavior that interact with stats, skills, personality, needs, emotions, memory, inventory, and the world state.

Actions do not decide when they are chosen. They define what can be done, what must be true to do it, and what changes when it succeeds or fails. The behavior system evaluates actions and selects among them.

---

## Design Philosophy

* Actions are data-driven and reusable.
* Actions should be small, composable, and context-aware.
* High-level plans belong in behavior, not inside action definitions.
* Actions should expose clear preconditions, costs, effects, and tags.
* Specialized behavior families like social conflict, courtship, combat, and reproduction remain part of the action model through subtypes and tags rather than separate hardcoded systems.
* Equipment actions are first-class state transitions that change loadout and capability.

---

## Core Concepts

### Action Model

Each action is a defined verb or state transition that can be evaluated by the behavior system.

An action should describe:

* What it does.
* What it requires.
* What it costs.
* What it changes.
* What it trains.
* What it tends to make creatures feel or remember.

### Standard Action Schema

```text
Action {
  id
  name
  category
  subtype
  tags[]
  description
  parameters[]
  preconditions[]
  costs[]
  duration
  risk
  effects[]
  failure_outcomes[]
  stat_scaling[]
  skill_scaling[]
  behavior_bias[]
  emotion_hooks[]
  memory_hooks[]
  training_hooks[]
}
```

## Categories

Actions are grouped into broad categories to keep the system modular and readable.

### Survival

Actions that keep a creature alive.

* Eat
* Drink
* Sleep
* Rest
* Hide
* Recover (physiological healing tick)

### Movement

Actions that relocate a creature or change positional state.

* Move
* Travel
* Navigate
* Flee
* Chase
* Patrol
* Sneak

### Exploration

Actions that gather information about the world.

* Inspect.
* Investigate.
* Observe.
* Map.
* Track.
* Search.

### Resource

Actions that obtain, carry, or store materials.

* Gather.
* Mine.
* Harvest.
* Carry.
* Store.
* Deliver.

### Crafting

Actions that transform resources into tools, items, or structures.

* Craft.
* Build.
* Repair.
* Refine.
* Assemble.
* Improve.

### Social

Actions that manage interaction between creatures.

* Greet.
* Speak.
* Share.
* Help.
* Comfort.
* Negotiate.
* Argue.
* Threaten.
* Bond.
* Reject.

### Conflict

Social actions that produce opposition, pressure, or violence.

* Challenge.
* Intimidate.
* Grapple.
* Strike.
* Defend.
* Submit.
* Retreat.
* Surrender.

### Courtship

Social actions that support mate selection and reproductive bonding.

* Flirt.
* Court.
* Impress.
* Mate.
* Accept.
* Refuse.
* Bond.

### Equipment

Actions that change the creature’s loadout or readiness state.

* Equip.
* Unequip.
* Swap.
* Sheath.
* Draw.
* Wear.
* Remove.

### Cognitive

Actions that process information or strengthen learning.

* Learn.
* Remember.
* Rehearse.
* Plan.
* Compare.
* Solve.

### Identity

Actions that express or test self-concept.

* Conform.
* Resist.
* Experiment.
* Assert.
* Perform.

### Legacy

Actions that preserve, transmit, or extend meaning across generations.

* Teach.
* Mentor.
* Record.
* Preserve.
* Pass down.
* Inherit.

## Properties

Every action should expose properties that other systems can read.

### Preconditions

Preconditions define what must be true before the action can begin.

* Creature state.
* World state.
* Target state.
* Item state.
* Relationship state.
* Skill threshold.
* Stat threshold.

### Costs

Costs define what the action consumes.

* Time.
* Stamina.
* Focus.
* Resources.
* Exposure.
* Social risk.
* Emotional cost.

### Effects

Effects define what changes if the action succeeds.

* World state changes.
* Creature state changes.
* Relationship changes.
* Item state changes.
* Skill progress.
* Memory formation.
* Emotional response.

### Failure Outcomes

Failure outcomes define what happens if the action is interrupted, blocked, or unsuccessful.

* No change.
* Partial change.
* Wasted time.
* Increased stress.
* Lost resources.
* Relationship damage.
* Injury.

### Stat Scaling

Actions can be modified by core stats and derived competency layers.

* Strength.
* Stamina.
* Dexterity.
* Perception.
* Willpower.
* Derived stats where appropriate.

### Skill Scaling

Actions can be modified by relevant skills.

* Higher skill improves success chance.
* Higher skill improves speed.
* Higher skill improves quality.
* Repeated use can train the skill.

### Behavior Bias

Actions can be more or less attractive depending on personality, emotion, and memory.

* Personality traits can raise or lower action weight.
* Current emotions can amplify or suppress action choice.
* Relevant memories can encourage or discourage the action.

### Emotion Hooks

Actions can produce emotions when they succeed, fail, or are observed.

* Joy.
* Relief.
* Pride.
* Fear.
* Shame.
* Anger.
* Attachment.
* Curiosity.

### Memory Hooks

Important actions can form or reinforce memories.

* Episodic memory.
* Semantic memory.
* Procedural memory.
* Relational memory.

### Training Hooks

Actions can increase skills or hidden tendencies through repetition.

* Successful action use trains relevant skills.
* Repeated action patterns can reinforce hidden stats.
* Repeated emotional outcomes can influence personality drift indirectly.

## Action Selection Interface

The action system does not choose actions directly. It provides a catalog of possible verbs and their data so behavior can score them.

Typical behavior inputs include:

* Current needs.
* Current emotions.
* Relevant memories.
* Personality axes.
* Stats.
* Skills.
* World state.
* Nearby entities.
* Available items.

## Examples

### Example: Eat

```text
Action: Eat
Category: Survival
Preconditions: Food available, creature can consume it.
Costs: Time, stamina.
Effects: Reduces hunger, may create satisfaction or relief.
```

### Example: Equip Item

```text
Action: Equip
Category: Equipment
Preconditions: Item present, slot available, item usable.
Costs: Time, attention.
Effects: Item becomes active loadout, stats may change.
```

### Example: Court

```text
Action: Court
Category: Courtship
Preconditions: Target is receptive or approachable.
Costs: Time, social risk.
Effects: Relationship may deepen, attraction may change, memories may form.
```

### Example: Fight

```text
Action: Strike
Category: Conflict
Preconditions: Target reachable, creature willing to engage.
Costs: Stamina, risk, exposure.
Effects: Damage, fear, retaliation, memory formation.
```

---

# Implementation / Notes

* Keep actions as reusable definitions rather than hardcoded behavior trees.
* Prefer tags over special-case logic whenever possible.
* Group related actions into subtypes instead of adding one-off systems.
* Let behavior score actions using stats, skills, needs, personality, and memory.
* Keep equipment, courtship, and conflict modular inside the action taxonomy.
* Use consistent naming for action ids and categories across the project.
