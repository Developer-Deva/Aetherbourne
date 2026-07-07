# Action System — Atomic World Operations

**Last Updated:** 2026-06-26 (plus later Gemini formatting)

## Overview
The Action System is the execution layer of creature behavior.

- Actions are the smallest meaningful units of intentional activity.
- Actions directly affect the world.
- Actions do not decide what the creature wants or what strategy it follows.

They only execute the strategy selected by the Behavior System.

## Simulation Role
Answers: **“What is the creature doing right now?”**

Examples:
- Move
- Speak
- Attack
- Eat
- Craft
- Give

## Hierarchy
Needs → Motivations → Personality → Relationships → Emotions → Behaviors → Actions → World Events

## Core Design Principles
- **Atomic:** represent a single meaningful operation
- **Reusable:** the same action can be used by many behaviors
- **Context-free:** actions contain no intrinsic intent; intent is supplied by the behavior
- **Events produced:** actions modify the world by generating events consumed by Emotion, Relationship, Memory, and World simulation

## Action Lifecycle
Select Action → Validate Requirements → Begin Action → Progress Action (Tick loop) → Complete or Fail → Generate Events

## Data Model
```csharp
public class Action
{
    public ActionType Type;

    public Entity Actor;
    public Entity Target;

    public float Progress;
    public float Duration;

    public bool IsComplete;
    public bool HasFailed;
}
```

## Action States
- Queued: waiting
- Active: executing
- Completed: successful
- Failed: could not complete due to constraints
- Interrupted: stopped mid-execution

## Action Properties
Each action defines:

- Duration (s/hours)
- Requirements (prerequisites)
- Costs (resources consumed)
- Failure conditions (environment invalidation)
- Outputs (what events get published)

## Action Categories (As described)
### Survival
- Eat
- Drink
- Sleep
- Heal

### Movement
- Move
- Follow
- Flee
- Carry

### Exploration & Resource
- Observe
- Inspect
- Search
- Extract
- Obtain
- Discard / Store / Retrieve

### Crafting
- Craft
- Repair
- Refine
- Disassemble

### Economic
- Buy
- Sell
- Trade

### Social
- Speak
- Request
- Give
- Help
- Negotiate
- Praise
- Apologize
- Teach
- Bond
- Partner / Mate

### Conflict
- Challenge
- Threaten
- Attack
- Defend
- Grapple
- Guard
- Retreat

### Equipment & Response
- Equip
- Unequip
- Use
- Accept / Reject / Ignore

## Action Selection Rule
Actions are chosen by the active behavior.

Behaviors never select themselves.

## Action Outputs
Actions publish results:

```csharp
public class ActionResult
{
    public ActionType Type;
    public bool Success;

    // derived from actor stats
    public float Quality;
    public float Duration;

    public List<Event> EventsGenerated;
}
```

## Consuming Systems
- Emotion System: uses action results → generate emotional responses
- Relationship System: uses social actions → update social bonds
- Memory System: uses action outcomes → create episodic memories
- Behavior System: uses action success/failure → continue or change strategy

## Design Goals
- ultimate reusability
- context isolation
- massive scalability
- keep actions algorithmic and atomic
- remain easy to extend with new content

