# Decision Engine Specification

**Description:** Defines the top-level selection loop that evaluates internal states and context to choose which macro-Behavior has control of the creature.
**Last Updated:** 2026-07-06

---

# 1. System Overview

The Decision Engine acts as the "brain" or brain-stem selector of the creature. It does not execute actions directly, nor does it contain the logic for *how* to achieve a goal. Its sole responsibility is to evaluate high-level inputs, score the creature's macro-needs, and select a single **Behavior** to activate.

```text
[Internal States + External Context]
                 │
                 ▼
┌────────────────────────────────────────┐
│     Decision Engine (Utility Pass)     │
└────────────────┬───────────────────────┘
                 │
                 ▼ Selects & Allocates Control
┌────────────────────────────────────────┐
│        Active Behavior Script          │
└────────────────────────────────────────┘

```

---

# 2. The Decision Loop

The engine runs a periodic evaluation pass (the **Decision Tick**, distinct from the frame-rate action loop) using a layered pipeline.

```text
Inputs Aggregate → Utility Scoring → Interruption Evaluation → Behavior Activation

```

### Step 1: Input Aggregation

Gathers variables from internal buckets (needs, emotions, personality) and spatial queries (nearby threats, interactables, social targets).

### Step 2: Utility Scoring

Runs a mathematical utility function across all available Behaviors in the system catalog to determine their current value.

### Step 3: Hysteresis & Interruption Check

Compares the highest-scoring candidate behavior against the currently running behavior, factoring in an **Interruption Cost** buffer to prevent rapid decision flipping.

### Step 4: Allocation

If a switch is approved, the engine gracefully interrupts the old behavior and passes system execution control to the new behavior.

---

# 3. Mathematical Utility Model

Behaviors are scored using an additive utility curve with environmental weighting:

```text
Utility = BaseNeedUrgency + PersonalityBias + EmotionalModifier + EnvironmentalOpportunity - InterruptionCost

```

### Core Utility Factors

* **Base Need Urgency:** The direct linear or exponential pressure of a creature's biological or systemic drives (e.g., Hunger, Sleepiness, Panic).
* **Personality Bias:** A static modifier determined by character traits. (e.g., A highly *Curious* creature adds a flat bonus to the *Exploration Behavior* utility).
* **Emotional Modifier:** Dynamic, short-term shifts driven by recent events. (e.g., High *Anger* spikes the utility of *Combat Behavior* while suppressing *Social Behavior*).
* **Environmental Opportunity:** A multiplier or modifier based on immediate capability. (e.g., If the *Hunger* need is high, but there is zero food detected in the sensory radius, the environmental opportunity drops to `0`, flattening the utility score).
* **Interruption Cost:** A dynamic penalty applied *only* to behavior candidates that are not the currently active behavior. This acts as architectural friction to ensure creatures follow through on tasks.

---

# 4. Arbitration Modes

While utility scoring is the default, the Decision Engine utilizes specific arbitration rules for handling edge cases:

* **Emergency Overrides:** Direct triggers (like taking unexpected damage) instantly bypass utility calculation to activate safety/combat behaviors.
* **Weighted Stochastic Choice:** When multiple behaviors have utility scores within a narrow margin, the system can use a weighted random selection to simulate hesitation or unpredictability.
* **Low-Confidence Fallback:** If no behavior meets a minimum utility threshold, the decision engine defaults to an *Idle/Wander* state.

---

# 5. Debugging & Explainability

To ensure the system remains debuggable, the Decision Engine must output telemetry data for every decision tick:

* **Active Behavior:** The behavior currently executing.
* **Scoring Breakdown:** A ranked list of all behaviors and their raw utility scores.
* **Winner Reason:** A clear data trace explaining why a behavior won (e.g., `Sustenance won because Hunger [85] + FoodPresent [20] > Active Behavior [Rest] + InterruptionCost [30]`).
