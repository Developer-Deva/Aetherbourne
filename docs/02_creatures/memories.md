# Memory System

**Description:** Memory formation, decay, and influence on personality development for Aetherbourne creatures
**Last Updated:** 2026-06-21

---

## Overview

Memories are the bridge between events and personality development.

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

## Memory Decay

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

## Design Philosophy

Principles for memory formation, persistence, and behavioral influence.

## Core Concepts

- Event strength and relevance
- Emotional weighting
- Memory decay and retention

## Implementation / Notes

* Notes on memory data structures, storage conditions, and retrieval rules.
