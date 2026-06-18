# Event System

**Description:** Modular event generation, emotional response, memory formation, and emergent storytelling systems for Aetherbourne

**Last Updated:** 2026-06-17

---

# Overview

The Event System serves as the primary bridge between simulation activity and emergent storytelling.

Events are generated whenever actors perform actions under specific conditions and for specific reasons. Events may affect individuals, groups, settlements, regions, or the entire world.

Events do not directly modify personality.

Instead:

```text
Event
↓
Emotional Response
↓
Memory
↓
Personality Drift
↓
Behavioral Change
↓
Future Events
```

This creates a feedback loop where creatures are shaped by their experiences throughout their lives.

---

# Event Philosophy

Events are not handcrafted narrative content.

Events emerge naturally from simulation systems.

Just as biomes emerge from environmental variables, events emerge from:

* Actors
* Witnesses
* Actions
* Targets
* Causes
* Conditions
* Outcomes

Events are simulation facts.

Narratives emerge later from collections of related events.

---

# Event Structure

```csharp
public struct EventData
{
    public EventCategory Category;

    public EventScale Scale;

    public float Severity;

    public EventActor[] Actors;

    public EventWitness[] Witnesses;

    public EventAction Action;

    public EventTarget[] Targets;

    public EventCause Cause;

    public EventCondition[] Conditions;

    public EventOutcome[] Outcomes;

    public long Timestamp;
}
```

---

# Event Formula

```text
Cause + Conditions = Action

Actor + Action + Target = Event

Event + Severity + Scale = Outcomes
```

---

# Event Lifecycle

Every event follows a common lifecycle.

```text
Cause
↓
Conditions Checked
↓
Action Performed
↓
Event Generated
↓
Witness Processing
↓
Emotional Responses
↓
Outcomes Applied
↓
Memory Evaluation
↓
Historical Recording
```

This ensures every system interacts with events consistently.

---

# Event Generation

Events are not created manually.

They emerge from actions performed by actors under valid conditions.

```text
Need
↓
Goal
↓
Action
↓
Event
```

Example:

```text
Hunger
↓
Need Food
↓
Hunt Deer
↓
Successful Hunt Event
```

An action may fail to generate an event if conditions are not satisfied.

---

# Event Categories

Events are grouped into broad simulation domains.

## Environmental

World-driven events.

Examples:

* Storms
* Floods
* Droughts
* Earthquakes
* Volcanic Eruptions
* Cave-ins

---

## Biological

Life-cycle and ecological events.

Examples:

* Birth
* Death
* Predation
* Migration
* Disease
* Mutation

---

## Social

Relationship-driven events.

Examples:

* Friendship
* Mentorship
* Marriage
* Adoption
* Betrayal
* Reconciliation

---

## Conflict

Competitive interactions.

Examples:

* Arguments
* Fights
* Territory Disputes
* Raids
* Wars

---

## Discovery

Knowledge and exploration events.

Examples:

* Resource Discovery
* New Territory Found
* Ancient Ruin Discovered

---

## Economic

Resource exchange events.

Examples:

* Trade
* Theft
* Resource Shortage
* Resource Surplus

---

## Cultural

Shared group events.

Examples:

* Rituals
* Festivals
* Ceremonies
* Religious Gatherings

---

## Personal

Individual milestones.

Examples:

* Coming of Age
* Skill Mastery
* First Hunt
* Leadership Appointment

---

# Event Scale

Scale determines event reach.

## Individual

Affects a single creature.

## Family

Affects related creatures.

## Group

Affects a social group.

## Settlement

Affects an entire settlement.

## Regional

Affects a biome or large territory.

## Global

Affects the entire world.

---

# Event Visibility

Not every creature is aware of every event.

Events possess a visibility level which determines potential witnesses.

```csharp
public enum EventVisibility
{
    Personal,
    Local,
    Settlement,
    Regional,
    Global
}
```

Examples:

| Event         | Visibility |
| ------------- | ---------- |
| Eat Berry     | Personal   |
| Fight         | Local      |
| Festival      | Settlement |
| Flood         | Regional   |
| Meteor Impact | Global     |

Visibility determines which creatures may perceive an event.

---

# Event Severity

Severity measures immediate event impact.

Range:

```text
0.0 - 100.0
```

| Severity | Classification |
| -------- | -------------- |
| 0-20     | Minor          |
| 21-40    | Moderate       |
| 41-60    | Major          |
| 61-80    | Severe         |
| 81-100   | Catastrophic   |

Severity influences:

* Emotional intensity
* Memory formation
* Memory longevity
* Story significance

---

# Historical Significance

Significance measures long-term narrative importance.

Significance is separate from severity.

Examples:

```text
Birth of Future Leader

Severity = 10
Significance = 95
```

```text
Broken Leg

Severity = 70
Significance = 15
```

Severity measures immediate impact.

Significance measures lasting influence on individuals, communities, societies, and history.

---

# Event Importance

Overall importance may be estimated through:

```text
Importance =
Severity
× Scale
× Witness Count
× Historical Influence
```

High-importance events are more likely to:

* Become lasting memories
* Influence culture
* Shape communities
* Appear in generated stories

---

# Actors

Actors initiate events.

Examples:

* Creature
* Family
* Group
* Settlement
* Species
* Volcano
* Storm
* Region

Multiple actors may participate in a single event.

---

# Witnesses

Witnesses perceive events but are not necessarily participants.

Witnesses may:

* Fully observe an event
* Partially observe an event
* Learn about an event indirectly

Witness perception influences emotional responses and memory formation.

---

# Event Interpretation

Events are objective.

Interpretations are subjective.

```text
Event
↓
Perception
↓
Interpretation
↓
Emotion
↓
Memory
```

The same event may generate different memories for different creatures.

Example:

```text
Won Duel

Victor:
Pride

Loser:
Shame

Observer:
Admiration
```

---

# Actions

Actions describe what occurred.

Examples:

* Hunt
* Attack
* Trade
* Share
* Betray
* Defend
* Explore
* Discover
* Erupt
* Flood

Actions are reusable and independent of category.

---

# Targets

Targets receive event effects.

Examples:

* Creature
* Group
* Resource
* Settlement
* Region

Events may affect multiple targets.

---

# Causes

Causes explain why an action occurred.

Examples:

* Hunger
* Fear
* Loyalty
* Curiosity
* Ambition
* Resource Scarcity
* Territorial Pressure
* Tectonic Pressure

Causes represent motivation.

---

# Conditions

Conditions determine whether an event can occur.

Examples:

* Food Nearby
* Prey Visible
* Relationship > 50
* Territory Overlap
* Humidity > 0.8
* Tectonic Activity = Volcanic

Conditions represent possibility.

A cause may exist without an event occurring if conditions are not satisfied.

---

# Outcomes

Outcomes represent immediate state changes.

Outcomes should be modular.

Examples:

* Health -10
* Trust +5
* Relationship +10
* Food +3
* Territory Expanded
* Creature Dead
* Resource Created

Events may generate multiple outcomes.

---

# Event Chains

Events may generate additional events.

```text
Parent Event
↓
Child Events
```

Example:

```text
Drought
↓
Crop Failure
↓
Food Shortage
↓
Migration
↓
Territory Conflict
↓
War
```

Event chains are one of the primary sources of emergent narratives.

---

# Event Persistence

Events are permanent historical facts.

Even when memories fade, the event itself remains part of simulation history.

```text
Events = Objective History

Memories = Subjective Experience
```

This distinction allows history to exist independently from individual recollection.

---

# Event Tags

Events may contain modular tags.

```csharp
public enum EventTag
{
    Combat,
    Family,
    Trade,
    Leadership,
    Discovery,
    Survival,
    Crime,
    Culture
}
```

Tags allow systems to react to broad event types without requiring specific event definitions.

Examples:

```text
All Combat Events

All Family Events

All Leadership Events
```

---

# Event Consequences

Events create both immediate and long-term consequences.

## Immediate Consequences

Applied directly through outcomes.

```text
Health -10
Food +3
Relationship +5
```

## Long-Term Consequences

Handled by later systems.

```text
Event
↓
Emotional Response
↓
Memory
↓
Personality Drift
↓
Behavioral Change
```

Events never directly modify personality.

---

# Event → Story Pipeline

```text
Simulation Layer
↓
Events
↓
Emotions
↓
Memories
↓
Relationships
↓
Personality
↓
Decision Making
↓
Behavior
↓
Future Events
↓
Emergent Narrative
```

Stories are not authored.

Stories emerge naturally from interconnected events experienced by individuals, groups, communities, and societies over time.
