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

---

## Canonical Consolidation Notes

Material from the previous staged decision planning note was merged here, making this file the canonical home for the system. During implementation, prefer the contracts and terminology in this file over deleted staging notes.

## Merged Legacy Planning Content

## Decision System — Utility-Based Executive Layer

**Last Updated:** 2026-06-26

### Overview
The Decision System is the creature’s executive layer.

It determines:

- what the creature wants
- which behavior should be active
- which action should be performed next
- when to change plans
- when to continue plans

It does not directly affect the world; it selects behaviors/actions that will.

### Simulation Role (Pipeline Position)
Needs ↓ Motivations ↓ Personality ↓ Relationships ↓ Emotions ↓ Memory ↓ Decision System ↓ Behavior ↓ Action ↓ World

Answers: **“What should I do next?”**

### Design Philosophy
- **Utility-based**: candidates compete based on utility; best wins.
- **Contextual**: choice depends on needs, emotions, relationships, opportunities, environment, recent memories.
- **Imperfect**: personality/emotion/stress/fatigue/incomplete information/memory bias influence choices.
- **Continuous reevaluation with inertia**: reevaluation should not instantly switch behaviors.

### Core Responsibilities
1. Need Evaluation
2. Goal Selection
3. Behavior Selection
4. Action Selection
5. Reassessment

### Decision Pipeline
World State + Needs + Motivations + Personality + Relationships + Emotions + Memory

→ Generate Candidate Behaviors

→ Score Behaviors

→ Select Behavior

→ Generate Candidate Actions

→ Score Actions

→ Execute Action

→ Monitor Outcome

→ Reassess

### Decision Layers
#### Layer 1: Need Evaluation
Compute need pressures (Need System).

Example:
- Health=20, Thirst=80, Hunger=40, Belonging=55, Purpose=30

Need pressure:
- `Pressure = Urgency × BasePriority × PersonalityWeight`

Output: Need Pressures.

#### Layer 2: Motivation Generation
Needs become motivations.

Examples:
- Thirst → Acquire Water
- Belonging → Seek Companionship
- Purpose → Advance long-term goal

Motivations represent desired outcomes; not methods.

#### Layer 3: Candidate Behavior Generation
Identify behaviors capable of satisfying motivations.

Example:
- Acquire Food → Foraging / Hunting / Trading / Stealing / Farming

#### Layer 4: Behavior Utility Scoring
General formula:

\[
\text{BehaviorUtility} = \text{NeedScore} \times \text{PersonalityModifier} \times \text{EmotionModifier} \times \text{RelationshipModifier} \times \text{MemoryModifier} \times \text{OpportunityModifier}
\]

Examples:
- Foraging = +100 Hunger satisfaction
- High Curiosity → exploration +50%
- Fear → fleeing +75%
- Trust → trade/cooperate +…
- Memory: successful trade → trade +20%
- Opportunity: no food nearby → foraging reduced

#### Layer 5: Behavior Selection
Highest utility wins.

Example:
- Foraging=320, Trading=180, Exploring=90 → Foraging selected.

### Commitment System (Inertia)
Prevents endless switching.

Commitment value range: 0.0–1.0

Switching rule:

- `NewUtility > CurrentUtility × 1.25`

Meaning: 25% better required before switching.

### Action Selection
Behavior → action selection.

Example behavior: Foraging
- actions: Move, Search, Extract, Obtain, Eat

Actions have utility based on:
- goal progress
- risk
- cost
- distance
- success probability

### Planning Horizon
Creatures operate at different planning depths:

- Reactive focus (immediate survival): animals/infants/panicked creatures
- Short-term: minutes to hours
- Long-term: days to years

### Memory Integration
- Positive reinforcement: successful outcomes increase future utility
- Negative reinforcement: failures reduce utility
- Familiarity: known options are safer than unknown

### Emotional Influence (Bias)
Emotion biases decisions but does not control them.

Examples:
- Fear increases: retreat/hide/flee, decreases explore/challenge
- Anger increases: threaten/challenge/attack
- Joy increases: socialize/explore/play
- Attachment increases: bond/protect/follow partner
- Curiosity increases: observe/inspect/search/explore

### Relationship Influence
Examples:
- Trust → trade/cooperate/follow advice
- Affection → bond/help/give
- Attraction → courtship/partnership
- Rivalry → challenge/compete
- Fear → avoidance/submission

### Personality Influence
Examples:
- high curiosity bias → exploration/learning
- high structure bias → routine planning
- high cooperation bias → helping/sharing
- high contention bias → competition/conflict
- high drive bias → work/achievement
- high empathy bias → caregiving/helping

### Interruption Rules
Some situations override current behavior.

Emergency overrides examples:
- critical health
- immediate predator threat
- fire
- drowning

These may force:
- flee, defend, heal regardless of current plans

### Decision Frequency
- Major decision: every 5–30 seconds
- Action decision: every action completion
- Emergency reassessment: immediate

### Decision Outputs
Published continuously:

```csharp
public class DecisionOutput
{
    public Motivation CurrentMotivation;
    public BehaviorType CurrentBehavior;
    public ActionType CurrentAction;
    public float UtilityScore;
    public float Confidence;
}
```

### Consuming Systems
- **Behavior System** consumes selected behavior to execute strategy
- **Action System** consumes selected action to interact with world
- **Memory System** consumes decision context to store why choices were made
- **Emotion System** consumes decision outcomes to generate emotional responses

### Design Goals
- utility-driven decisions
- influences from major psychological systems
- supports reactive and long-term behavior
- avoid deterministic scripting
- believable emergent behavior
- scalable population handling
- separation between decision-making and action execution

### Implementation Note
Decision System should never hardcode direct mappings like:

- “If hungry then forage”

Instead:

- generate options → score → select best
