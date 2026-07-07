# Decision System — Utility-Based Executive Layer

**Last Updated:** 2026-06-26

## Overview
The Decision System is the creature’s executive layer.

It determines:

- what the creature wants
- which behavior should be active
- which action should be performed next
- when to change plans
- when to continue plans

It does not directly affect the world; it selects behaviors/actions that will.

## Simulation Role (Pipeline Position)
Needs ↓ Motivations ↓ Personality ↓ Relationships ↓ Emotions ↓ Memory ↓ Decision System ↓ Behavior ↓ Action ↓ World

Answers: **“What should I do next?”**

## Design Philosophy
- **Utility-based**: candidates compete based on utility; best wins.
- **Contextual**: choice depends on needs, emotions, relationships, opportunities, environment, recent memories.
- **Imperfect**: personality/emotion/stress/fatigue/incomplete information/memory bias influence choices.
- **Continuous reevaluation with inertia**: reevaluation should not instantly switch behaviors.

## Core Responsibilities
1. Need Evaluation
2. Goal Selection
3. Behavior Selection
4. Action Selection
5. Reassessment

## Decision Pipeline
World State + Needs + Motivations + Personality + Relationships + Emotions + Memory

→ Generate Candidate Behaviors

→ Score Behaviors

→ Select Behavior

→ Generate Candidate Actions

→ Score Actions

→ Execute Action

→ Monitor Outcome

→ Reassess

## Decision Layers
### Layer 1: Need Evaluation
Compute need pressures (Need System).

Example:
- Health=20, Thirst=80, Hunger=40, Belonging=55, Purpose=30

Need pressure:
- `Pressure = Urgency × BasePriority × PersonalityWeight`

Output: Need Pressures.

### Layer 2: Motivation Generation
Needs become motivations.

Examples:
- Thirst → Acquire Water
- Belonging → Seek Companionship
- Purpose → Advance long-term goal

Motivations represent desired outcomes; not methods.

### Layer 3: Candidate Behavior Generation
Identify behaviors capable of satisfying motivations.

Example:
- Acquire Food → Foraging / Hunting / Trading / Stealing / Farming

### Layer 4: Behavior Utility Scoring
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

### Layer 5: Behavior Selection
Highest utility wins.

Example:
- Foraging=320, Trading=180, Exploring=90 → Foraging selected.

## Commitment System (Inertia)
Prevents endless switching.

Commitment value range: 0.0–1.0

Switching rule:

- `NewUtility > CurrentUtility × 1.25`

Meaning: 25% better required before switching.

## Action Selection
Behavior → action selection.

Example behavior: Foraging
- actions: Move, Search, Extract, Obtain, Eat

Actions have utility based on:
- goal progress
- risk
- cost
- distance
- success probability

## Planning Horizon
Creatures operate at different planning depths:

- Reactive focus (immediate survival): animals/infants/panicked creatures
- Short-term: minutes to hours
- Long-term: days to years

## Memory Integration
- Positive reinforcement: successful outcomes increase future utility
- Negative reinforcement: failures reduce utility
- Familiarity: known options are safer than unknown

## Emotional Influence (Bias)
Emotion biases decisions but does not control them.

Examples:
- Fear increases: retreat/hide/flee, decreases explore/challenge
- Anger increases: threaten/challenge/attack
- Joy increases: socialize/explore/play
- Attachment increases: bond/protect/follow partner
- Curiosity increases: observe/inspect/search/explore

## Relationship Influence
Examples:
- Trust → trade/cooperate/follow advice
- Affection → bond/help/give
- Attraction → courtship/partnership
- Rivalry → challenge/compete
- Fear → avoidance/submission

## Personality Influence
Examples:
- high curiosity bias → exploration/learning
- high structure bias → routine planning
- high cooperation bias → helping/sharing
- high contention bias → competition/conflict
- high drive bias → work/achievement
- high empathy bias → caregiving/helping

## Interruption Rules
Some situations override current behavior.

Emergency overrides examples:
- critical health
- immediate predator threat
- fire
- drowning

These may force:
- flee, defend, heal regardless of current plans

## Decision Frequency
- Major decision: every 5–30 seconds
- Action decision: every action completion
- Emergency reassessment: immediate

## Decision Outputs
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

## Consuming Systems
- **Behavior System** consumes selected behavior to execute strategy
- **Action System** consumes selected action to interact with world
- **Memory System** consumes decision context to store why choices were made
- **Emotion System** consumes decision outcomes to generate emotional responses

## Design Goals
- utility-driven decisions
- influences from major psychological systems
- supports reactive and long-term behavior
- avoid deterministic scripting
- believable emergent behavior
- scalable population handling
- separation between decision-making and action execution

## Implementation Note
Decision System should never hardcode direct mappings like:

- “If hungry then forage”

Instead:

- generate options → score → select best

