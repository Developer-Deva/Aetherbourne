# Behavior & Action System Specification

**Description:** Defines how stateful high-level Behaviors string together, manage, and execute primitive atomic actions from the shared catalog.
**Last Updated:** 2026-07-06

---

# 1. System Overview

A **Behavior** is a stateful orchestration layer (a micro-script, state machine, or sub-tree) that, once activated by the Decision Engine, owns the creature's execution loop. It contains the logic for *how* to achieve a macro-goal by selecting, sequencing, and validating primitive **Actions**.

```text
┌────────────────────────────────────────┐
│        Active Behavior Script          │
└───────────────────┬────────────────────┘
                    │ Orchestrates
                    ▼
     [Action 1] ──> [Action 2] ──> [Action 3]
    (Primitive)    (Primitive)    (Primitive)

```

---

# 2. Behaviors vs. Primitive Actions

To maintain scalability, a strict separation of concerns is enforced between behaviors and actions:

| Attribute | High-Level Behavior | Primitive Action (Catalog) |
| --- | --- | --- |
| **State** | **Stateful:** Keeps track of steps, progress, and local memory. | **Stateless/Atomic:** Handles its own immediate execution phase. |
| **Responsibility** | Knows *how* to solve a goal over time. | Knows *how* to execute a single physical verb. |
| **Examples** | `Forage`, `Sleep`, `Patrol`, `Socialize` | `MoveTo`, `PlayAnimation`, `Interact`, `Equip` |
| **Interruption** | Can be cleanly stopped or paused by the decision layer. | Must finish its current loop or be abruptly aborted. |

---

# 3. Macro-Behavior Architecture

Behaviors are structured like lightweight state machines or sequential plans. They query the world, store temporary data targets, and push instructions down to the action processor.

### Anatomy of an Orchestration Macro (Pseudo-Logic)

```text
Behavior: ForagingBehavior
  Preconditions: 
    - Internal inventory has free slot.

  OnActivation:
    - Set local_state = SEARCHING
    - Clear local_targets

  OnTick:
    IF local_state == SEARCHING:
      target_food = SensoryQuery.FindNearestFood()
      IF target_food exists:
        local_state = APPROACHING
        ExecuteAction(ActionCatalog.MoveTo(target_food))
      ELSE:
        ExecuteAction(ActionCatalog.Wander())

    IF local_state == APPROACHING:
      IF ActionStatus == SUCCESS:
        local_state = GATHERING
        ExecuteAction(ActionCatalog.Interact(target_food, duration=3s))
      IF ActionStatus == FAILED:
        local_state = SEARCHING // Recalculate if target lost/blocked

    IF local_state == GATHERING AND ActionStatus == SUCCESS:
      local_state = CONSUMING
      ExecuteAction(ActionCatalog.UseItem(Inventory.GetFoodItem()))

    IF local_state == CONSUMING AND ActionStatus == SUCCESS:
      SignalCompletion() // Hands control back to Decision Engine

```

---

# 4. Composite Planning & Sequences

Behaviors use predictable structural patterns to string actions together:

* **Linear Sequences:** Actions are executed one after another (`MoveTo` ➔ `Interact` ➔ `Deliver`). A single failure drops the whole sequence.
* **Fallback Loops:** If a primary choice action fails, the behavior switches to a fallback action before giving up (e.g., If `OpenDoor` fails, execute `KickDoor`).
* **Reactive Interruptions:** Behaviors monitor immediate action feedback. If an action returns a critical failure (e.g., path blocked, target died), the behavior handles the error internally before letting the core decision layer know.

---

# 5. Core Behavior Catalog

The core simulation relies on a standard suite of base behaviors:

* **Sustenance:** Handles seeking, harvesting, and consuming food and water.
* **Rest:** Handles locating safe terrain, beds, or nests, and sleeping until fatigue is cleared.
* **Security:** Handles threat assessment, choosing flight paths, or moving toward high-ground/cover.
* **Socialization:** Handles pairing up with compatible creatures, adjusting position, and executing communicative/emotive actions.
* **Exploration:** Handles exploring unknown map tiles or tracking down unvisited points of interest when needs are stable.

---

# 6. Implementation Guidelines

* **Atomic Isolation:** Primitive actions must remain completely decoupled from behaviors. An action like `MoveTo` shouldn't care if it's being called by a foraging routine or a combat routine.
* **Local State Cleanup:** Behaviors must implement strict `OnActivation` and `OnDeactivation` hooks to clean up localized target variables, pathfinding requests, and temporary animation states when interrupted.

---

### Key Adjustments Made:
* **The Decision Engine** focuses purely on inputs, utility mathematics, thresholds, and deciding *who* gets the token of control.
* **The Behavior System** focuses entirely on stateful scripting, execution logic, macro-to-micro loops, and action sequencing.

---

## Canonical Consolidation Notes

Material from the previous staged behavior planning note was merged here, making this file the canonical home for the system. During implementation, prefer the contracts and terminology in this file over deleted staging notes.

## Merged Legacy Planning Content

## Behavior System — Staged Strategies (Conditional Stage Architecture)

**Last Updated:** 2026-06-27

### Overview
The Behavior System is the creature’s strategy layer.

- Behaviors represent ongoing plans.
- Behaviors select and coordinate Actions.
- Behaviors do **not** directly modify the world.

**Key architectural update (from Gemini):**

Behaviors are **local state machines** executed through **conditional stages** based on:

- environment context
- behavior Progress value

Instead of pushing pre-filled action queues, the behavior yields **one atomic action at a time**, re-validating context at each step.

### Simulation Role
Answers: **“What strategy should I pursue right now, and what execution stage am I in?”**

Pipeline:

Decision System → selects BehaviorType (e.g., Foraging)

Behavior System → stage evaluation via context & Progress, yields the next atomic action

Action System → executes that single action frame-by-frame

### Processing Order
Recommended frequency: every 1–10 seconds.

- Evaluate inputs & local context
- Check active behavior stage via Progress
- Yield next atomic action
- Monitor action outcome
- Update Progress or handle stage failure

### Core Design Principles
- Behaviors are strategies (not personality traits)
- Behaviors are temporary and staged
- Behaviors compete (utility selection)
- Behaviors generate action requests (execution remains in Action System)

### Data Model
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

### Behavior Utility Formula
\[
\text{Utility} = \text{NeedScore} \times \text{PersonalityModifier} \times \text{EmotionalModifier} \times \text{RelationshipModifier} \times \text{OpportunityModifier}
\]

- NeedScore derived from Need Pressure.
- PersonalityModifier scales strategy types.
- EmotionalModifier biases behavior.
- RelationshipModifier supports social strategy selection.
- OpportunityModifier sanity-checks feasibility (drop utility if requirements aren’t present).

### Selection & Inertia
- Highest Utility wins.
- Switching uses commitment threshold.

Example:
- switching if `NewUtility > CurrentUtility × CommitmentThreshold` (recommended 1.25)

### Cooldowns & Progress Tracking
- Cooldowns prevent oscillation and spam.
- Progress maintains staged completion (0..100).

### Staged Architecture (Conditional Stages)
#### Stage 1: Preparation & Travel (0% - 25%)
- Goal: identify a valid world target and navigate into interaction range
- Logic: scan environment; if target found → yield Move action

#### Stage 2: Interaction & Extraction (26% - 75%)
- Goal: act upon the localized context
- Logic:
  - once travel completes, shift stage
  - yield continuous interaction action (e.g., Search / Extract / Craft)
  - progress increments as physical/interaction progress accrues

#### Stage 3: Consumption & Satisfaction (76% - 100%)
- Goal: finalize behavior and apply internal rewards
- Logic:
  - yield consumption/closure actions (e.g., Eat / Store / Bond)
  - upon execution inject need satisfaction into Need System
  - set Progress=100 and terminate

### Failure & Interruption Handling
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

### Behavior Categories (As listed in the file)
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

### Behavior Outputs
```csharp
public struct BehaviorOutput
{
    public BehaviorType CurrentBehavior;
    public float Utility;
    public float Commitment;
    public float Progress; // 0..100 stage milestone
}
```

### Design Goals
- Behaviors are operational strategies.
- Execute via conditional stages (atomic action execution).
- Cooldowns prevent oscillations.
- Decoupled design keeps actions modular and reusable.
- Scales by separating utility thinking from frame-by-frame action execution.
