# Event System

**Description:** Modular event generation, memory formation, and personality development systems for Aetherbourne

**Last Updated:** 2026-06-15

---

# Overview

The Event System serves as the primary bridge between simulation activity and emergent storytelling.

Events are generated whenever actors perform actions under specific conditions and for specific reasons. Events may affect individuals, groups, settlements, regions, or the entire world.

Events do not directly modify personality.

Instead:

Event
→ Emotional Response
→ Memory
→ Personality Drift
→ Behavioral Change
→ Future Events

This creates a feedback loop where creatures are shaped by their experiences throughout their lives.

---

# Event Philosophy

Events are not handcrafted narrative content.

Events emerge naturally from simulation systems.

Just as biomes emerge from environmental variables, events emerge from:

* Actors
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

Cause
+
Conditions
==========

Action

Actor
+
Action
+
Target
======

Event

Event
+
Severity
+
Scale
=====

Outcomes

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

## Biological

Life-cycle and ecological events.

Examples:

* Birth
* Death
* Predation
* Migration
* Disease
* Mutation

## Social

Relationship-driven events.

Examples:

* Friendship
* Mentorship
* Marriage
* Adoption
* Betrayal
* Reconciliation

## Conflict

Competitive interactions.

Examples:

* Arguments
* Fights
* Territory Disputes
* Raids
* Wars

## Discovery

Knowledge and exploration events.

Examples:

* Resource Discovery
* New Territory Found
* Ancient Ruin Discovered

## Economic

Resource exchange events.

Examples:

* Trade
* Theft
* Resource Shortage
* Resource Surplus

## Cultural

Shared group events.

Examples:

* Rituals
* Festivals
* Ceremonies
* Religious Gatherings

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

# Event Severity

Severity measures event impact.

Range:

0.0 - 100.0

| Severity | Classification |
| -------- | -------------- |
| 0-20     | Minor          |
| 21-40    | Moderate       |
| 41-60    | Major          |
| 61-80    | Severe         |
| 81-100   | Catastrophic   |

Severity influences:

* Memory formation
* Memory longevity
* Personality drift magnitude
* Story significance

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

Multiple actors may participate.

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

An event may have a valid cause but fail if conditions are not met.

---

# Outcomes

Outcomes represent state changes.

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

# Memory Formation

Not all events become memories.

Memory creation depends on:

* Event Severity
* Personal Relevance
* Emotional Response

Formula:

MemoryStrength =
Severity
× PersonalRelevance
× EmotionalResponse

Low-strength memories may never be stored.

High-strength memories may persist for years or an entire lifetime.

---

# Memory Decay

Memories decay over time.

```csharp
public struct Memory
{
    public EventData SourceEvent;

    public float Strength;

    public float EmotionalWeight;

    public float DecayRate;
}
```

Minor events fade quickly.

Major life events decay slowly.

Examples:

Shared Food

Strength = 10

DecayRate = High

Lost Parent

Strength = 95

DecayRate = Very Low

---

# Personality Development

Events never directly modify personality.

Instead:

Event
→ Memory
→ Personality Drift

This allows creatures to gradually evolve through lived experiences.

---

# Personality Drift

Each memory contains personality influence values.

Example:

Betrayal Memory

Trusting = -5

Hopeful = -3

Empathetic = -2

Mentorship Memory

Trusting = +3

Cooperative = +4

Merciful = +2

These influences accumulate over time.

---

# Personality Drift Formula

PersonalityChange =
(
MemoryStrength
× EmotionalWeight
× AxisModifier
)
/
PersonalityResistance

Repeated experiences create larger changes than isolated incidents.

---

# Personality Persistence

Memories may fade.

Personality changes may remain.

Example:

Repeated Childhood Betrayal

Memory eventually decays.

Trusting → Guarded shift remains.

This allows experiences to permanently shape creatures.

---

# Event → Story Pipeline

Simulation Layer

Events

↓

Memory Layer

Personal Memories

↓

Personality Layer

Personality Development

↓

Behavior Layer

Decision Making

↓

Narrative Layer

Emergent Stories

Stories are not authored.

Stories emerge naturally from the accumulation of events, memories, relationships, and personality development.
