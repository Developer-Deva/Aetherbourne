# Creature Behavior System
**Description:** Behavioral patterns, decision-making frameworks, and emergent creature behaviors in Aetherbourne
**Last Updated:** 2026-06-21
---
## Overview
The behavior system describes how creatures make decisions, execute plans, and interact with their environment.
Creature behavior emerges from the interaction of needs, goals, memories, personality traits, and environmental factors.
## Content Coming Soon
This documentation is currently in development. Please check back for updates.
---
## Design Philosophy
High-level goals and motivations behind the behavior design.
## Core Concepts
- Decision pipelines
- Goal arbitration
- Action selection and execution
---
## Implementation / Notes
* Implementation notes, data formats, and planner integration details go here.
# Memory System
**Description:** Memory formation, decay, and influence on personality for Aetherbourne
**Last Updated:** 2026-06-21
---
## Overview
Memories are the stored records of significant emotional experiences. They are the primary driver of **Personality Drift**.
## Content Coming Soon
This documentation is currently in development. Please check back for updates.
---
## Memory Formation
A memory is formed when the **Emotional Intensity** of an event exceeds the creature's storage threshold.
```text
MemoryStrength = EmotionalIntensity × DriveWeight
```
* **DriveWeight:** If the event category matches the creature's **Aethersign Drive**, the memory is 25% stronger.
---
## Memory Taxonomy
* **Episodic:** Records of specific events (e.g., "The time I found the cave").
* **Semantic:** Generalized knowledge derived from events (e.g., "Caves are dangerous").
* **Procedural:** Skills and habits learned through repetition (e.g., "How to forge iron").
---
## Memory Decay & Persistence
All memories decay over time, but at different rates.
```text
CurrentStrength = InitialStrength × e^(-DecayRate × Time)
```
* **Minor Events:** High DecayRate (fades in days).
* **Traumatic/Significant Events:** Low DecayRate (may last a lifetime).
---
## Memory Retrieval & Association
Memories are not static; they are retrieved when the creature encounters similar stimuli.
* **Association:** Encountering a "Snake" may trigger a memory of a "Snake Bite," spiking current *Fear* levels.
* **Recall:** High *Cognition* traits increase the accuracy and speed of memory retrieval.
---
## Influence on Personality
Memories provide "drift" values that accumulate over time.
`DriftContribution = CurrentStrength × AxisModifier`
---
## Design Philosophy
* **Selective Retention:** The simulation only keeps what matters.
* **Dynamic History:** As memories decay, their influence on future decisions weakens, but their effect on the *past* personality drift is permanent.
# Emotion System
**Description:** Emotional state, processing, and influence systems for Aetherbourne
**Last Updated:** 2026-06-21
---
## Overview
Emotions are the subjective bridge between objective events and lasting memories. They determine how a creature perceives and reacts to the world.
## Content Coming Soon
This documentation is currently in development. Please check back for updates.
---
## The Emotional Pipeline
`Need → Goal → Action → Event → Interpretation → Emotion → Memory`
---
## Emotional Intensity
```text
EI = EventSeverity × PersonalRelevance × PersonalityAmplifier
```
* **EventSeverity:** Objective impact (0-100).
* **PersonalRelevance:** Impact on the creature's current state.
* **PersonalityAmplifier:** Modified by *Sensitivity* and *Emotional Reactivity*.
---
## Emotional Taxonomy
Emotions are categorized by their influence on behavioral AI.
---
## Subjective Interpretation
The same event produces different emotions based on the creature's perspective.
### Example
* **Victor:** Pride / Joy.
* **Loser:** Shame / Anger.
* **Witness:** Admiration / Fear (influenced by *Empathy* trait).
---
## Emotion → Memory Transition
Not every emotion becomes a memory. Only those that exceed a certain threshold are stored.
```text
MemoryStrength = EI × DurationFactor
```
If `MemoryStrength > MemoryThreshold`, a new memory is created.
---
## Design Philosophy
* **Subjectivity:** Events are facts; emotions are interpretations.
* **Volatility:** Emotions are short-lived but drive long-term character change via memories.

This is a strong foundation, and your docs already line up well with a behavior pipeline where needs create goals, goals select actions, actions produce events, and emotions/memories feed back into future decisions. I’d recommend formalizing it as a utility-based arbiter with emotional appraisal and memory-driven drift layered on top of your personality axes [1][2][3].

## Behavior pipeline

Use this sequence:

1. Need state updates.
2. Goal candidates are generated.
3. Goals are weighted by urgency, personality, memory, and environment.
4. The arbiter selects or blends actions.
5. The action produces an event.
6. The creature interprets the event emotionally.
7. Emotional intensity may create or strengthen memory.
8. Memory contributes drift to personality axes over time.

This matches both your current docs and established emotion/appraisal models, where events are evaluated against needs, goals, and values, then converted into action tendencies before behavior execution [2][3]. It also fits behavior arbitration research that treats action selection as a utility or priority combination problem rather than a single hard-coded choice [1][4][5].

## Decision model

I’d give each creature a short candidate set each tick rather than a huge search space. For each candidate action, compute:

- Need satisfaction value.
- Risk/cost.
- Social impact.
- Memory resonance.
- Personality fit.
- Environmental feasibility.
- Aethersign bias.

Then choose the action with the highest final utility, with some controlled randomness so creatures remain organic rather than perfectly optimized. Utility fusion or priority arbitration both work here; utility is better if you want subtle personality differences, while priority is better if you want clearer “override” behaviors under stress [4][6].

## Personality effects on behavior

Here is a practical mapping from your axes to behavior selection:

| Axis | High end tends to do | Low end tends to do |
|---|---|---|
| Reactivity | React quickly to threats, needs, surprises. | Stay calm, miss or delay response. |
| Elasticity | Recover quickly from stress. | Stay stuck in distress or agitation. |
| Affiliation | Seek company, support, shared work. | Prefer solitude or low-contact routines. |
| Assertiveness | Initiate, negotiate, push needs outward. | Wait, yield, avoid direct conflict. |
| Curiosity | Explore, inspect, test, wander. | Stick to known routes and familiar tasks. |
| Structure | Prefer routine, planning, repeatable patterns. | Act more improvisationally. |
| Sensitivity | Feel events deeply, form strong memories. | Be emotionally muted or hard to impress. |
| Regulation | Pause, reframe, recover before acting. | Act while emotionally flooded. |
| Continuity | Preserve self-consistency and habits. | Change self-image more readily. |
| Differentiation | Experiment, resist conformity, seek distinctiveness. | Conform, blend in, accept roles. |
| Cooperation | Share, compromise, coordinate. | Compete, resist, dominate. |
| Contention | Challenge, test, confront. | Avoid friction, smooth over tension. |
| Drive | Act often, pursue goals energetically. | Delay, conserve, under-initiate. |
| Direction | Commit to long-term objectives. | Switch goals frequently or drift. |
| Empathy | Respond to others’ suffering and needs. | Be more detached or self-centered. |
| Principle | Follow rules, duties, fairness norms. | Be situational, flexible, or opportunistic. |
| Breadth | Consider multiple viewpoints and context. | Narrowly focus on a single frame. |
| Depth | Think long-term and systemically. | Stay present-oriented and concrete. |
| Generativity | Mentor, build, preserve future welfare. | Focus on self or immediate peers. |
| Endurance | Maintain legacy, traditions, long commitments. | Let structures and meanings fade. |

## Emergent behavior loops

The most important part is making the loops compound over time.

### Need loop
A need rises, the creature acts, the action succeeds or fails, the result becomes emotional, and the emotional result reinforces future need priorities. Repeated hunger near a food source can make a creature more structured, more opportunistic, or more territorial depending on personality and outcomes [2][3].

### Social loop
Affiliation, assertiveness, cooperation, and contention shape how often a creature interacts, which determines how many social memories it gets. Positive interactions increase trust and cohesion; negative interactions increase guardedness, rivalry, or differentiation. This makes social style self-reinforcing over time.

### Emotional loop
Emotion intensity depends on event severity, relevance, and personality amplification, which your docs already define. High-intensity emotions are more likely to become memories, and those memories then shift personality drift, which changes future emotional amplification. That creates a stable but slowly changing emotional identity [7][8][3].

### Competence loop
Success at a task increases the likelihood of reusing the same strategy, which strengthens procedural memory and boosts structure or direction. Failure can either increase curiosity and adaptation or harden avoidance, depending on sensitivity, regulation, and prior memory context.

### Trauma loop
Strong negative memories do not just reduce comfort; they change interpretation. A snake bite may later trigger fear on sight of snakes, which then biases avoidance, which reduces exposure, which prevents corrective learning. That is exactly the kind of selective retention and dynamic history your memory system is aiming for [8][3].

## Memory to personality drift

Your current formula is a good start:

`DriftContribution = CurrentStrength × AxisModifier`

I’d expand it conceptually like this:

- **CurrentStrength** determines how much the memory still matters.
- **AxisModifier** determines which personality dimensions the memory pushes.
- **Emotion type** determines direction.
- **Repetition** increases confidence and reduces volatility.
- **Recency** controls whether the drift is still actively changing.

For example:
- Repeated safe caregiving could raise Affiliation, Elasticity, Empathy, and Generativity.
- Repeated humiliation could lower Continuity or Affiliation, and raise Differentiation or Contention.
- Repeated successful planning could raise Structure, Direction, and Depth.

## Age-linked behavior changes

Each domain should bias the decision system differently as the creature ages.

- **Infants:** Temperament mostly alters response thresholds and comfort-seeking.
- **Toddlers:** Socialization biases who they approach, imitate, or resist.
- **Children:** Cognition changes exploration and learning strategy.
- **Teens:** Identity and Interaction shape conflict, conformity, and experimentation.
- **Young adults:** Purpose and Morals become major goal filters.
- **Adults:** Perspective changes how they weigh tradeoffs and social context.
- **Elders:** Legacy changes how much they prioritize teaching, preservation, and future impact.

This gives you a clean developmental ladder where each new layer does not replace earlier ones, but reorganizes them.

## Implementation shape

A practical per-tick flow could look like this:

1. Update needs.
2. Generate possible goals from needs and long-term drives.
3. Score goals using personality, memories, relationships, and environment.
4. Convert top goals into candidate actions.
5. Score actions with feasibility, risk, and emotional state.
6. Execute the highest utility action or a blended plan.
7. Produce an event.
8. Appraise event into emotion.
9. Store or decay memory.
10. Apply slow personality drift.

That keeps your system readable and extensible while still allowing complex emergent behavior.

## Recommended design choice

If you want the system to feel alive, I’d avoid hard personality “modes” and instead let the same axes interact multiplicatively with memory and emotion. That way a creature is not “a coward” or “a hero”; it is a creature whose current choices are the result of a lifetime of pressures, habits, and lived experience. That is much closer to the emergent storytelling goal of Aetherbourne [9][10].

Would you like me to turn this into a concrete **JSON schema and formula set** next?

