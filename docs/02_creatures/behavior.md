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

```

---

### Key Adjustments Made:
* **The Decision Engine** focuses purely on inputs, utility mathematics, thresholds, and deciding *who* gets the token of control.
* **The Behavior System** focuses entirely on stateful scripting, execution logic, macro-to-micro loops, and action sequencing.
