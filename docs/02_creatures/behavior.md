# Behavior System
**Description:** Defines how creatures evaluate needs, goals, memories, emotions, personality, stats, skills, and actions to choose behavior.
**Last Updated:** 2026-06-21
---
# Overview
The behavior system is the decision-making layer of Aetherbourne. It determines how creatures choose actions, how they respond to the world, and how internal state translates into outward behavior.

Behavior does not define what actions exist. It consumes the action catalog, evaluates options, and selects what the creature attempts next. It sits at the center of the creature simulation loop and connects needs, personality, emotion, memory, skills, stats, and environmental context into a single decision pipeline.
---
# Design Philosophy
* Behavior should emerge from modular scoring, not hardcoded scripts.
* The system should favor reusable decision rules over one-off exceptions.
* Creatures should not always make optimal choices.
* Emotion, memory, and personality should influence action selection without fully replacing it.
* Behavior should be explainable, debuggable, and data-driven.
* Strong urgency should override normal preference when necessary.
* Similar creatures should still diverge because of memory, personality, and hidden state.
---
# Core Concepts
## Decision Pipeline
Creature behavior follows a layered decision process.

```text
Need → Goal → Action Candidate → Scoring → Arbitration → Execution → Event → Emotion → Memory → Drift
```

### Step 1: Need Update
The creature updates current needs such as hunger, thirst, rest, safety, belonging, purpose, and other active pressures.

### Step 2: Goal Generation
Needs, memories, emotions, personality, and current world conditions generate candidate goals.

### Step 3: Action Retrieval
The behavior system queries the action catalog for actions that could satisfy one or more goals.

### Step 4: Action Scoring
Each candidate action receives a utility score based on current context.

### Step 5: Arbitration
The system selects the highest-value action or a weighted subset of actions if a composite plan is appropriate.

### Step 6: Execution
The creature attempts the selected action, subject to interruption, failure, or partial success.

### Step 7: Feedback
The resulting event is passed to emotion and memory systems.

## Goal Arbitration
Goals compete based on urgency, relevance, and likelihood of success.

Common goal drivers include:
- Biological need pressure.
- Social pressure.
- Safety pressure.
- Curiosity or exploration pressure.
- Identity pressure.
- Long-term purpose pressure.
- Legacy pressure.

Goals are not identical to actions. A goal describes what the creature wants. An action describes what the creature can do to pursue it.

### Goal Ranking Inputs
- Need intensity.
- Current emotional state.
- Personality axes.
- Relevant memories.
- Environmental opportunity.
- Available action options.
- Risk tolerance.
- Social context.

## Action Scoring
Every candidate action is scored before selection.

### Core Score Factors
- **Need Satisfaction Value**: How much the action helps current needs.
- **Risk Cost**: How dangerous or costly the action is.
- **Feasibility**: Whether the action can realistically succeed now.
- **Personality Fit**: How well the action matches long-term tendencies.
- **Memory Resonance**: Whether similar past experiences encourage or discourage it.
- **Emotional Bias**: Whether current emotions push toward or away from it.
- **Stat and Skill Fit**: Whether the creature is capable enough to attempt it.
- **Environmental Match**: Whether the local situation supports it.

### Example Utility Shape
```text
Utility = NeedValue + PersonalityFit + MemoryBias + EmotionBias + SkillFit + EnvironmentFit - RiskCost - OpportunityCost
```

This formula does not need to be exact in implementation, but it captures the intended structure.

## Arbitration Rules
The behavior system should not always choose the absolute maximum score.

Recommended arbitration rules:
- The creature may choose from the top few actions instead of only the top one.
- Randomness should be small but present.
- Repeated habits should bias familiar choices.
- Strong emergencies should override normal preference.
- Low-confidence decisions may produce hesitation, delays, or fallback actions.

### Arbitration Modes
#### Direct Selection
Used when one action clearly dominates.

#### Weighted Choice
Used when several actions are similarly attractive.

#### Composite Plan
Used when one goal requires multiple steps.

#### Emergency Override
Used when survival, threat, or immediate social crisis requires fast response.

## Behavior Inputs
Behavior should consume a narrow but expressive state set.

### Internal Inputs
- Needs.
- Emotions.
- Personality axes.
- Memory traces.
- Hidden stats.
- Current skills.
- Current fatigue and resource state.

### External Inputs
- Nearby entities.
- Nearby items.
- Terrain.
- Hazards.
- Resources.
- Social context.
- Time of day.
- Weather and environment.

## Behavior Outputs
Behavior produces a selected action or action sequence.

### Output Types
- Single action.
- Chained action plan.
- Delayed action.
- Fallback action.
- No action / wait.

### Output Metadata
- Target.
- Priority.
- Expected outcome.
- Confidence.
- Reason for choice.
- Possible interruption states.

## Emotional Influence
Emotion should change what behavior considers urgent or attractive.

### Common Emotional Effects
- Fear increases avoidance, caution, and retreat.
- Joy increases repetition and approach behavior.
- Shame increases hiding, withdrawal, or repair behavior.
- Anger increases confrontation, challenge, or impulsive action.
- Relief reduces urgency and may lower immediate task pressure.
- Attachment increases proximity-seeking and protective choices.

Emotion should be influential but not absolute. A fearful creature may still fight if the need pressure is high enough.

## Memory Influence
Memory affects behavior by changing expectation and bias.

### Memory Effects on Behavior
- Successful memories increase action confidence.
- Painful memories increase avoidance.
- Repeated rewards increase habit formation.
- Social memories alter trust, affiliation, and threat perception.
- Procedural memories increase efficiency and reduce hesitation.
- Semantic memories influence decision quality and prediction.

Behavior should read memories as weighted context, not as direct commands.

## Personality Influence
Personality changes action preference, but does not force action by itself.

### Examples
- High Curiosity favors exploration and novel actions.
- High Structure favors routine and familiar choices.
- High Cooperation favors helping and compromise.
- High Contention favors challenge and resistance.
- High Drive favors goal pursuit.
- High Regulation stabilizes choice under stress.

Personality should bias the score of actions, goals, and fallback choices.

## Stats and Skills Influence
Behavior should consider whether the creature is actually capable of doing the action well enough.

### Stats
Core and derived stats influence:
- Success likelihood.
- Duration.
- Risk.
- Recovery cost.
- Quality of outcome.

### Skills
Skills influence:
- Action competence.
- Speed.
- Accuracy.
- Reliability.
- Energy efficiency.

Behavior should avoid unrealistically selecting actions the creature is far too weak or untrained to perform unless desperation or special circumstances justify it.

## Composite Planning
Not every behavior should be a single action.

A creature may chain actions into simple plans such as:
- Search → move → gather → return → eat.
- Approach → greet → share → bond.
- Observe → compare → plan → act.
- Threaten → defend → retreat.
- Equip → ready → engage.

Composite plans should still be built from the same action primitives.

## Persistence and Switching
Behavior should model persistence in ongoing tasks.

### Persistent Behavior
- Continue eating until satisfied.
- Continue traveling until destination or interruption.
- Continue crafting until the object is finished.
- Continue fleeing until safe.

### Switching Behavior
- Change goal when need pressure shifts.
- Change action when environment changes.
- Change plan when a higher priority threat appears.
- Change direction when memory or emotion strongly biases a new option.

## Habit and Novelty
Creatures should not behave the same way every time.

### Habit
Repeated successful actions become easier to select.
- Lower planning cost.
- Higher confidence.
- Faster execution.
- Stronger memory reinforcement.

### Novelty
Creatures with curiosity, creativity, or low structure should explore less familiar actions.
- Higher variety.
- More experimentation.
- Greater chance of discovery.
- More distinctive personality drift.

## Emergent Behavior Loops
The behavior system creates several self-reinforcing loops.

### Need Loop
Need pressure rises, behavior responds, outcome occurs, emotion forms, memory stores, and future behavior changes.

### Skill Loop
Repeated actions build skill, skill improves success, success makes the action more likely, and the creature becomes more specialized.

### Social Loop
Social actions alter relationships, relationships alter action selection, and repeated interaction patterns become social identity.

### Risk Loop
Unsafe choices create fear or caution if they fail, which can make future behavior more conservative.

### Confidence Loop
Repeated success increases confidence, which makes similar actions easier to select again.

### Identity Loop
Repeated behavior shapes self-concept, and self-concept later biases what kinds of action feel authentic.

## Example Scoring Pass
```text
Action: Eat
NeedValue: high
RiskCost: low
Feasibility: high
PersonalityFit: moderate
MemoryBias: positive
EmotionBias: positive
SkillFit: high
EnvironmentFit: high
Utility: very high
```

```text
Action: Attack
NeedValue: medium
RiskCost: high
Feasibility: moderate
PersonalityFit: high for contention, low for caution
MemoryBias: negative if past injury exists
EmotionBias: high if angry
SkillFit: moderate
EnvironmentFit: mixed
Utility: situational
```

## Implementation / Notes
* Keep the decision system modular and data-driven.
* Separate goal generation from action selection.
* Use tags and scoring modifiers instead of hardcoded behavior trees when possible.
* Allow emergency overrides, but keep them rare and understandable.
* Treat emotion and memory as biasing layers rather than replacement logic.
* Keep composite plans built from the same action primitives.
* Use debugging output that explains why an action was chosen.
* Design for emergent outcomes, not perfect optimization.
