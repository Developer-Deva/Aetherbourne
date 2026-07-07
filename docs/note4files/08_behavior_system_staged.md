# Behavior System — Staged Strategies (Conditional Stage Architecture)

**Last Updated:** 2026-06-27

## Overview
The Behavior System is the creature’s strategy layer.

- Behaviors represent ongoing plans.
- Behaviors select and coordinate Actions.
- Behaviors do **not** directly modify the world.

**Key architectural update (from Gemini):**

Behaviors are **local state machines** executed through **conditional stages** based on:

- environment context
- behavior Progress value

Instead of pushing pre-filled action queues, the behavior yields **one atomic action at a time**, re-validating context at each step.

## Simulation Role
Answers: **“What strategy should I pursue right now, and what execution stage am I in?”**

Pipeline:

Decision System → selects BehaviorType (e.g., Foraging)

Behavior System → stage evaluation via context & Progress, yields the next atomic action

Action System → executes that single action frame-by-frame

## Processing Order
Recommended frequency: every 1–10 seconds.

- Evaluate inputs & local context
- Check active behavior stage via Progress
- Yield next atomic action
- Monitor action outcome
- Update Progress or handle stage failure

## Core Design Principles
- Behaviors are strategies (not personality traits)
- Behaviors are temporary and staged
- Behaviors compete (utility selection)
- Behaviors generate action requests (execution remains in Action System)

## Data Model
```csharp
public class Behavior
{
    public BehaviorType Type;
    public float Utility;
    public float Commitment;
    public float Progress; // 0..100 stage completion
    public float Cooldown;
    public bool IsActive;
}
```

## Behavior Utility Formula
\[
\text{Utility} = \text{NeedScore} \times \text{PersonalityModifier} \times \text{EmotionalModifier} \times \text{RelationshipModifier} \times \text{OpportunityModifier}
\]

- NeedScore derived from Need Pressure.
- PersonalityModifier scales strategy types.
- EmotionalModifier biases behavior.
- RelationshipModifier supports social strategy selection.
- OpportunityModifier sanity-checks feasibility (drop utility if requirements aren’t present).

## Selection & Inertia
- Highest Utility wins.
- Switching uses commitment threshold.

Example:
- switching if `NewUtility > CurrentUtility × CommitmentThreshold` (recommended 1.25)

## Cooldowns & Progress Tracking
- Cooldowns prevent oscillation and spam.
- Progress maintains staged completion (0..100).

## Staged Architecture (Conditional Stages)
### Stage 1: Preparation & Travel (0% - 25%)
- Goal: identify a valid world target and navigate into interaction range
- Logic: scan environment; if target found → yield Move action

### Stage 2: Interaction & Extraction (26% - 75%)
- Goal: act upon the localized context
- Logic:
  - once travel completes, shift stage
  - yield continuous interaction action (e.g., Search / Extract / Craft)
  - progress increments as physical/interaction progress accrues

### Stage 3: Consumption & Satisfaction (76% - 100%)
- Goal: finalize behavior and apply internal rewards
- Logic:
  - yield consumption/closure actions (e.g., Eat / Store / Bond)
  - upon execution inject need satisfaction into Need System
  - set Progress=100 and terminate

## Failure & Interruption Handling
Because actions are yielded stage-by-stage:

- environmental interruptions fail validation quickly
- emergency overrides can cleanly stop current stage yielding

Examples:

- Foraging target destroyed during interaction stage → context validation fails → behavior marks failed and yields control
- high-priority threat enters threat radius → Decision layer forces Fleeing → current behavior stops yielding next extraction actions safely

Failure consequences may include:
- generate negative emotions
- mint negative episodic memories
- apply cooldowns
- trigger new behaviors

## Behavior Categories (As listed in the file)
- Survival:
  - Eating
  - Drinking
  - Resting
  - Recovering
- Exploration:
  - Exploring
  - Investigating
- Resource:
  - Foraging
  - Gathering
- Economic:
  - Trading
  - Acquiring Wealth
- Social:
  - Socializing
  - Bonding
  - Courtship
  - Partnership
  - Parenting
  - Teaching
- Leadership:
  - Leading
  - Following
- Conflict:
  - Challenging
  - Fighting
  - Defending
  - Fleeing
- Work:
  - Crafting
  - Building
  - Working

## Behavior Outputs
```csharp
public struct BehaviorOutput
{
    public BehaviorType CurrentBehavior;
    public float Utility;
    public float Commitment;
    public float Progress; // 0..100 stage milestone
}
```

## Design Goals
- Behaviors are operational strategies.
- Execute via conditional stages (atomic action execution).
- Cooldowns prevent oscillations.
- Decoupled design keeps actions modular and reusable.
- Scales by separating utility thinking from frame-by-frame action execution.

