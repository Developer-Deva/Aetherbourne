# Personality System

**Description:** Personality development, aging, emotional domains, and emergent behavioral systems for Aetherbourne creatures

**Last Updated:** 2026-06-21
---

## Overview
Personality in Aetherbourne is a layered, developmental architecture. It represents a creature's long-term behavioral tendencies that emerge from a combination of celestial predispositions (**Aethersigns**), genetic inheritance, and lived experience.

---

## Core model (what personality is)
Each creature has a small set of **persistent personality axes** ranging from -100 to 100.

- These are **not** temporary moods; they are **long-term tendencies**.
- They shape how a creature perceives needs, selects goals, and responds to events.
- Personality develops in stages. Each new domain unlocks at a certain age and is shaped by earlier domains, inherited traits, and lived experience.

A good rule is:
- **Genes** define starting potentials and tendencies.
- **Aethersigns** define celestial predispositions and bias growth direction.
- **Experience** shifts the axes slowly over time.
- **Memories** reinforce repeated patterns.
- **Relationships** and social feedback can accelerate change.
- **Age** unlocks new domains and increases the influence of prior ones.

---

## Domain structure (what unlocks when)
| Age stage | Active domain | Primary purpose | Influenced by |
| :---: | :---: | :---: | :---: |
| Infant | Temperament | Baseline reactivity and recovery | Genetics, Aethersigns |
| Toddler | Socialization | Attachment and early social style | Temperament |
| Child | Cognition | Learning style and mental habits | Temperament, Socialization |
| Child | Emotional | Emotional interpretation and recovery | Temperament |
| Teen | Identity | Self-concept and individuation | Socialization, Cognition, Emotional |
| Teen | Interaction | Social behavior under pressure | Socialization, Identity |
| Young Adult | Purpose | Goal selection and ambition | Cognition, Identity |
| Young Adult | Morals | Value formation and social judgment | Socialization, Emotional, Identity |
| Adult | Perspective | Reflection, empathy across time, systems thinking | Identity, Purpose, Morals |
| Elder | Legacy | Transmission, memory, and lasting impact | Purpose, Perspective |

---

## The Aethersign layer (predispositions)
Every creature is born under an **Aethersign**, a celestial imprint that provides "discreet influence" on their psychological development.

* **State (Foundational Nature):** Defines **Domain Affinity**, providing a -10% reduction in Personality Resistance for traits within specific domains.
* **Modality (Developmental Pace):** Directly modifies the **Personality Resistance** (PR) stat (e.g., Catalyst -20% PR).
* **Drive (Memory Weighting):** Determines which categories of experiences produce the strongest **Personality Drift** (+25% weight).

### State (Foundational Nature)
Determined by the birth Phase. State defines domain affinity and subtle developmental bias.

* **Solid:** Affined to Temperament, Purpose, Legacy.
* **Liquid:** Affined to Socialization, Interaction, Morals.
* **Gas:** Affined to Cognition, Perspective.
* **Plasma:** Affined to Identity, Purpose.
* **Aether:** Affined to Emotional, Morals, Perspective.

### Modality (Developmental Pace)
Determined by Selene's phase. Modality modifies the creature's overall resistance to personality drift.

* **Catalyst:** -20% PR (Learns and changes quickly).
* **Anchor:** +20% PR (Resistant to change; high consistency).
* **Current:** PR fluctuates ±15% based on current environmental stability.

### Drive (Memory Weighting)
Determined by Karael's orbital position. Drive increases the influence of matched memory categories.

* **Growth:** +25% weight to Family and Mentorship memories.
* **Conflict:** +25% weight to Rivalry and Failure memories.
* **Discovery:** +25% weight to Exploration and Research memories.
* **Reflection:** +25% weight to Loss and Beauty memories.
* **Renewal:** +25% weight to Healing and Migration memories.

---

## Personality domains (axes and intent)
### Two-axis per domain
Each domain contains two unique axes ranging from **-100 to 100**.

### Design principles for axes
Each axis should do three jobs at once:
- Affect action choice in a clear way.
- Explain how a creature experiences the world.
- Feed naturally into the next developmental domain.

A good axis usually sits on a tension between two useful extremes, like self vs. group, caution vs. impulse, or novelty vs. routine. That gives you a clean -100 to 100 range and makes behavior logic easier to write.

Since Aetherbourne already centers on layered development and long-term personality formation, the axes should feel like **developmental building blocks** rather than isolated stats.

---

## Suggested axes by domain
| Domain | Recommended axes | What they control |
| :---: | :---: | :---: |
| Temperament | Reactivity, Elasticity | How strongly a creature responds to stimulation; how quickly it returns to baseline after stress or change. |
| Socialization | Affiliation, Assertiveness | Need for contact and bonding; tendency to initiate, lead, resist, or dominate social situations. |
| Cognition | Curiosity, Structure | Drive to explore/learn; preference for planning, categorization, and predictable patterns. |
| Emotional | Sensitivity, Regulation | Depth/intensity of emotional response; ability to modulate feelings and recover from them. |
| Identity | Continuity, Differentiation | Desire for stable self-image and consistency; desire to stand apart, experiment, and individuate. |
| Interaction | Cooperation, Contention | Default approach in direct social encounters: align and help, or challenge and compete. |
| Purpose | Drive, Direction | Amount of ambition/energy toward goals; clarity and commitment to long-term aims. |
| Morals | Empathy, Principle | Concern for others’ welfare; adherence to internal rules, duty, or fairness. |
| Perspective | Breadth, Depth | Ability to consider systems, other viewpoints, and long time horizons; reflective complexity. |
| Legacy | Generativity, Endurance | Desire to leave something behind; commitment to preserving values, lineage, or impact over time. |

---

## Why these work (domain rationale)
### Temperament
For infants, you want axes that are mostly about raw disposition.
- **Reactivity** influences crying, startle response, comfort-seeking, and how strongly needs push behavior.
- **Elasticity** captures whether the creature settles quickly or remains distressed; it later becomes useful for Emotional development.

These two also naturally become early inputs to the Emotional domain.

### Socialization
Toddlers are about first social patterns.
- **Affiliation** determines whether the creature seeks proximity, comfort, and inclusion.
- **Assertiveness** determines whether it initiates contact, resists others, or takes social space.

These can later influence Socialization-based effects on Interaction and Morals.

### Cognition
Children need axes that shape learning behavior.
- **Curiosity** drives exploration, novelty-seeking, and information gathering.
- **Structure** governs planning, rule-following, and preference for order.

Those two influence whether a creature learns through experimentation or through repetition and formal patterns.

### Emotional
If Temperament lays the groundwork, Emotional represents how lived experience is processed.
- **Sensitivity** controls how deeply events are felt.
- **Regulation** controls how much those feelings distort behavior over time.

This makes emotional memories meaningful without making every creature equally volatile.

### Identity
For teens, the central tension is self-definition.
- **Continuity** measures how strongly a creature preserves a coherent self-image.
- **Differentiation** measures the need to separate from others and become distinct.

This makes identity growth legible in behavior such as conformity, rebellion, experimentation, and self-labeling.

### Interaction
This domain focuses on social behavior in motion.
- **Cooperation** aligns, assists, and compromises.
- **Contention** challenges, tests, competes, or provokes.

Because Socialization influences this domain, it feels like a more mature expression of earlier social tendencies.

### Purpose
Young adults translate ability into meaning.
- **Drive** measures energy toward action and ambition.
- **Direction** measures whether that energy is focused or scattered.

Purpose can bias which long-term goals win out when goals are chosen from competing needs.

### Morals
Morals should be distinct from social skill.
- **Empathy** measures emotional concern for others.
- **Principle** measures internalized rules, duty, or fairness even when emotions do not align.

This gives you creatures who can be caring without being rule-bound, or principled without being emotionally warm.

### Perspective
Adults become more reflective and system-aware.
- **Breadth** holds multiple viewpoints, contexts, and tradeoffs at once.
- **Depth** captures sustained reflection, abstraction, and long-horizon thinking.

These influence elder behavior, mentorship, and interpretation of life events.

### Legacy
Elders are about what remains.
- **Generativity** measures the desire to nurture successors, institutions, or traditions.
- **Endurance** measures commitment to preserving meaning, memory, or impact over time.

This domain affects caregiving, teaching, story-sharing, inheritance behavior, and how a creature prepares for decline.

---

## Better-than-average pairings
Some pairings are especially strong because they create interesting behavior without overlapping too much:
- Reactivity + Elasticity.
- Affiliation + Assertiveness.
- Curiosity + Structure.
- Sensitivity + Regulation.
- Continuity + Differentiation.
- Cooperation + Contention.
- Drive + Direction.
- Empathy + Principle.
- Breadth + Depth.
- Generativity + Endurance.

These pairs are good because each axis answers a different question. That makes them easier to compute from needs, memories, traits, and relationships.

They also give you room to model mixed personalities instead of forcing a creature into one binary type.

---

## Practical implementation note (axis scope)
A useful rule of thumb is:
- If an axis can be described as a simple mood, it is probably too short-lived for your architecture.
- If it can be described as a long-term tendency that changes slowly through repeated experience, it is probably the right kind of axis.

For Aetherbourne, the best axes feel like “how this creature tends to become” rather than “how this creature feels right now.”

This creates a compact core model, with enough nuance to make aging and inheritance feel meaningful.

---

## Axis specification (behavior effects and loops)

### Temperament
- **Reactivity:** How strongly the creature responds to stimuli, setbacks, hunger spikes, loud sounds, social rejection, and sudden change.
- **Elasticity:** How quickly the creature returns to baseline after distress, shock, or disruption.

Behavior effects:
- High reactivity creatures startle easily, overreact to needs, and form stronger emotional memories from small events.
- High elasticity creatures recover quickly, tolerate disruption, and are less likely to spiral after a bad event.

Emergent loop:
- High reactivity increases memory formation and event salience.
- If paired with low elasticity, the creature becomes increasingly avoidant or volatile.
- If paired with high elasticity, the creature becomes lively, adaptable, and socially expressive.

### Socialization
- **Affiliation:** Desire for closeness, belonging, companionship, and group inclusion.
- **Assertiveness:** Willingness to initiate contact, state needs, push boundaries, or lead.

Behavior effects:
- High affiliation creatures seek groups, companionship, and frequent reassurance.
- High assertiveness creatures speak first, claim space, negotiate, and influence others.

Emergent loop:
- Affiliation drives proximity, which increases social memory density.
- Positive social memories reinforce trust and group dependence.
- Low affiliation plus high assertiveness can create loners, explorers, leaders, or pushy personalities depending on emotional history.
- High affiliation plus low assertiveness produces attachment-seeking followers or caregivers.

### Cognition
- **Curiosity:** Drive to explore, investigate, sample novelty, and learn through experience.
- **Structure:** Preference for planning, routine, classification, and predictability.

Behavior effects:
- High curiosity creatures wander, inspect objects, test systems, and pursue unfamiliar goals.
- High structure creatures prefer repeated routines, stable workflows, and predictable resource paths.

Emergent loop:
- Curiosity increases exposure to novel events, which creates more varied memory.
- Structure increases efficiency and skill repetition.
- High curiosity plus low structure yields improvisers, inventors, and wanderers.
- High structure plus low curiosity yields specialists, caretakers, planners, and conservators.

### Emotional
- **Sensitivity:** Depth of emotional response to events and relationships.
- **Regulation:** Ability to modulate emotion, delay reaction, and recover from emotional stress.

Behavior effects:
- High sensitivity means feelings matter more and memories form more easily.
- High regulation means emotions are less likely to hijack decision-making.

Emergent loop:
- Sensitive creatures react strongly to praise, loss, danger, and affection.
- If regulation is low, repeated emotional spikes can lock in fear, resentment, grief, or attachment patterns.
- If regulation is high, emotional intensity becomes usable information instead of behavior disruption.
- Regulation can grow through stable environments, trusted relationships, and repeated successful recovery.

### Identity
- **Continuity:** Need for an internally coherent self-image over time.
- **Differentiation:** Need to be distinct, unique, or separate from others.

Behavior effects:
- High continuity creatures prefer consistency, values, familiar roles, and stable self-narratives.
- High differentiation creatures seek individuality, experimentation, unusual roles, and resistance to being defined by others.

Emergent loop:
- Continuity strengthens habits, identity-linked memories, and commitment.
- Differentiation increases experimentation and can produce role conflict, creativity, or rebellion.
- High continuity plus low differentiation creates stable traditional personalities.
- High differentiation plus low continuity creates restless, adaptive, identity-searching personalities.

### Interaction
- **Cooperation:** Tendency to align with others, share effort, and maintain harmony.
- **Contention:** Tendency to challenge, compete, resist, or test social boundaries.

Behavior effects:
- High cooperation creatures assist, compromise, and stabilize groups.
- High contention creatures provoke change, defend status, and test social strength.

Emergent loop:
- Cooperation increases reciprocal trust and network centrality.
- Contention generates friction, which can lead to either conflict memories or respect-based bonds.
- High contention plus high assertiveness creates rivals, defenders, and political operators.
- High cooperation plus high affiliation creates nurturers, mediators, and community anchors.

### Purpose
- **Drive:** Energy and persistence toward goals.
- **Direction:** Clarity of long-term aims and the ability to focus effort coherently.

Behavior effects:
- High drive creatures act frequently, pursue tasks aggressively, and recover quickly from setbacks.
- High direction creatures choose fewer goals, but commit to them strongly and avoid aimless drift.

Emergent loop:
- Drive increases action frequency, which increases outcomes and feedback.
- Direction reduces goal switching, allowing deep progress and identity with a life path.
- High drive plus low direction creates restless opportunists.
- Low drive plus high direction creates patient but underactive planners.

### Morals
- **Empathy:** Tendency to feel concern for others’ suffering and emotional states.
- **Principle:** Tendency to follow internal rules, fairness standards, duties, or obligations.

Behavior effects:
- High empathy creatures are more affected by others’ pain and more likely to help.
- High principle creatures maintain consistency even when emotions or rewards suggest otherwise.

Emergent loop:
- Empathy increases emotional echo from social events.
- Principle creates stable commitments and predictable moral identity.
- High empathy plus high principle produces protectors, caregivers, and just leaders.
- High empathy plus low principle produces compassionate but inconsistent allies.
- Low empathy plus high principle produces rigid judges, cold enforcers, or duty-bound bureaucrats.

### Perspective
- **Breadth:** Ability to hold multiple viewpoints, contexts, and tradeoffs in mind.
- **Depth:** Ability to think long-term, reflect, and understand systems or consequences.

Behavior effects:
- High breadth creatures interpret social conflict more generously and consider broader context.
- High depth creatures think in layers, anticipate downstream effects, and connect present events to long arcs.

Emergent loop:
- Breadth reduces snap judgments and improves social adaptation.
- Depth improves foresight, mentorship, planning, and wisdom-based decision-making.
- High breadth plus high depth creates advisors, historians, and strategic elders.
- High depth plus low breadth creates intense but narrow philosophers or obsessives.

### Legacy
- **Generativity:** Desire to create successors, leave teachings, build institutions, or nourish future life.
- **Endurance:** Commitment to preserving what matters across time, loss, and generational change.

Behavior effects:
- High generativity creatures invest in offspring, students, communities, and future structures.
- High endurance creatures preserve memory, tradition, and hard-won meaning.

Emergent loop:
- Generativity turns accumulated wisdom into social continuation.
- Endurance stabilizes lineage identity and cultural persistence.
- High generativity plus high endurance produces founders, teachers, keepers of tradition, and community architects.
- High endurance plus low generativity creates guardians of memory who preserve but do not expand.

---

## Age-by-age development

### Infant: Temperament
At this stage, personality is mostly about raw responsiveness. The creature does not yet have a stable self-concept or social strategy, but its nervous system already biases how it reacts to hunger, comfort, noise, and disruption.

Primary behaviors:
- Crying, clinging, startling, settling, sleep response, comfort response.
- Early attachment patterns based on caregiver consistency.
- Basic tolerance or intolerance for environmental instability.

Key rule:
- Repeated soothing increases Elasticity.
- Frequent overstimulation increases Reactivity.
- Safe, predictable care gently supports future Socialization and Emotional regulation.

### Toddler: Socialization
Toddlers begin to form the first social habits. They learn whether others are safe, useful, interesting, annoying, or rewarding.

Primary behaviors:
- Seeking proximity, sharing, resisting, imitating, hiding, approaching, protesting.
- Preference for specific caretakers or companions.
- Early status behaviors and boundary testing.

Key rule:
- Positive social repetition increases Affiliation.
- Success in asserting needs increases Assertiveness.
- Rejection or inconsistency can turn Affiliation into guardedness or desperation, depending on Temperament.

### Child: Cognition and Emotional
Children begin to build mental models of the world. They also become emotionally legible to themselves, meaning they start to recognize, remember, and interpret feelings.

Primary behaviors:
- Learning tasks, experimentation, routine formation, asking questions, copying, categorizing.
- Emotional self-recognition, emotional memory formation, recovery from disappointment.

Key rule:
- Curiosity grows when exploration is rewarded.
- Structure grows when routine is reliable and successful.
- Sensitivity grows when events are emotionally intense and memorable.
- Regulation grows through successful recovery, caregiver support, and repeated safe processing.

### Teen: Identity and Interaction
Adolescence is where inner self and social behavior begin to diverge or align intentionally. The creature starts asking, implicitly or explicitly, “Who am I?” and “How do I deal with others on my own terms?”

Primary behaviors:
- Role experimentation, preference shifts, rebellion, conformity, self-labeling, social testing.
- Conflict style, alliance style, negotiation style, dominance style.

Key rule:
- Identity is shaped by the interaction between memory, social feedback, and competence.
- Differentiation rises when the creature is repeatedly compared, constrained, or overshadowed.
- Cooperation and Contention become more situational and strategic rather than purely instinctive.

### Young Adult: Purpose and Morals
This is the stage of commitment. The creature begins choosing what matters, what to build, what to defend, and what kind of life to invest in.

Primary behaviors:
- Career-like pursuit, role commitment, goal selection, sacrifice, loyalty, mentoring, moral judgment.
- Development of long-term plans and ethical consistency.

Key rule:
- Cognition influences what goals seem possible.
- Identity influences what goals feel authentic.
- Socialization and emotional history influence who the creature feels responsible for.
- Purpose becomes the bridge from capacity to destiny.

### Adult: Perspective
Adults can hold more of their life in context. They become better at weighing tradeoffs, understanding others’ motives, and seeing systems rather than isolated moments.

Primary behaviors:
- Strategic planning, mediation, teaching, compromise, hindsight, systems thinking, wise restraint.
- Better use of memory for interpretation rather than just reaction.

Key rule:
- Identity gives Perspective a viewpoint.
- Purpose gives Perspective an axis of meaning.
- Morals give Perspective a standard for judgment.
- This is where creatures become mentors, planners, skeptics, or sages.

### Elder: Legacy
Elders are concerned with continuity beyond the self. They may teach, preserve, bless, warn, create institutions, or shape descendants through memory and example.

Primary behaviors:
- Storytelling, succession planning, ritual keeping, mentorship, preservation, reconciliation, transmission of values.
- Reflection on meaning, loss, and what should endure.

Key rule:
- Purpose determines what the creature wants to leave behind.
- Perspective determines how broadly it understands that legacy.
- Legacy is where personality becomes culture.

---

## Inheritance rules
Use inheritance on three layers:

### 1. Genetic inheritance
Genes set starting ranges, not fixed outcomes.

Example:
- A creature might inherit high baseline Reactivity but moderate Elasticity.
- Another may inherit low Curiosity but high Structure.
- A third may have innate sensitivity to social rejection.

Best practice:
- Treat genes as bias fields, not hard values.
- Let each axis have a genetic range, such as ±15 to ±30 from species or lineage.

### 2. Aethersign inheritance
Aethersigns should act like cosmic predispositions that bias the shape of development.

Example effects:
- One Aethersign may intensify Curiosity and Breadth.
- Another may strengthen Endurance and Principle.
- Another may make Reactivity and Differentiation more likely.

Best practice:
- Aethersigns should influence *direction* more than raw magnitude.
- They can amplify certain developmental responses to the same life event.

### 3. Experiential inheritance
Memories, repeated emotions, and social patterns slowly reshape axes over time.

Examples:
- Repeated safety increases Elasticity and Regulation.
- Repeated rejection increases Differentiation, Contention, or low Affiliation.
- Repeated success through planning increases Structure and Direction.
- Repeated caregiving increases Empathy and Generativity.

Best practice:
- Experience should move axes gradually, with stronger changes from repeated high-salience events.

---

## Cross-domain inheritance logic
Each new domain should not replace the old one. Instead, earlier domains bias how the new one develops.

Examples:
- **Temperament influences Socialization** by shaping how safe or overwhelming social contact feels.
- **Temperament influences Emotional** by shaping intensity and recovery.
- **Socialization influences Identity** by shaping whether the creature defines itself through others or against others.
- **Socialization influences Interaction** by shaping default social style.
- **Cognition influences Purpose** by shaping what goals are imaginable and efficient.
- **Socialization and Emotional influence Morals** by shaping compassion, loyalty, and guilt.
- **Identity influences Perspective** by defining the vantage point from which the creature reflects.
- **Purpose influences Legacy** by determining what the creature believes is worth preserving.

---

## Emergent behavior loops
These are the most important part, because they make creatures feel alive instead of stat blocks.

### Need loop
Need arises, behavior responds, outcome occurs, memory forms, personality shifts, future need priorities change.

Example:
- Hungry creature becomes stressed.
- High Reactivity increases urgency.
- Successful food-seeking rewards Drive and Structure.
- Repeated failure may increase Contention or reduce Elasticity.

### Social loop
Interaction creates social outcomes, which become memories, which alter social preference.

Example:
- A highly Affiliated creature seeks others.
- If others respond positively, Affiliation strengthens and Cooperation grows.
- If others reject it, the creature may become clingier, more avoidant, or more Contending depending on Temperament and Emotional regulation.

### Competence loop
Success or failure in tasks changes self-concept and future ambition.

Example:
- A curious child explores a mineral field.
- Discovery rewards Curiosity and Structure if the environment is learnable.
- Successful mastery later increases Direction and Continuity.
- Failure without support may lead to withdrawal or Differentiation.

### Trauma loop
Repeated high-salience negative events can reshape the creature strongly.

Example:
- High Sensitivity + low Regulation means setbacks are remembered deeply.
- If social betrayal repeats, Affiliation may collapse while Contention rises.
- If the creature survives through self-reliance, Continuity and Principle may harden into a rigid identity.

### Mentorship loop
Older creatures can directly shape younger ones.

Example:
- Elder with high Generativity teaches child with high Curiosity.
- Child’s Structure, Direction, and Empathy rise.
- The child later becomes a reliable adult who teaches others, continuing the lineage.

### Cultural loop
Repeated traits can become common in families, groups, or settlements.

Example:
- A trade community rewards Structure, Principle, and Cooperation.
- Those traits become more successful socially.
- Children raised there inherit both genes and environmental reinforcement.
- Over generations the settlement develops a recognizable personality.

---

## Practical simulation rules
To keep this manageable in code, I’d recommend these implementation rules:
- Each domain unlocks at a life stage.
- Each domain adds 1 or 2 axes only.
- Old axes remain active forever, but their influence weight may decline relative to newer domains.
- New domains can inherit 20–40 percent of their baseline from prior domains.
- Major events move axes by small amounts; repeated events matter more than single events.
- High-salience memories should produce slow drift, not instant personality flips.
- Personality should be updated on a time tick or after important events, not every frame.

---

## Personality Drift & Resistance
Personality "drifts" based on the accumulation of memories, filtered through the creature's Aethersign and current age.

### Personality Resistance (PR)
**Personality Resistance** represents the "inertia" of a creature's character.

* **Base Resistance:** Starts at 10.0 for Infants.
* **Age Scaling:** PR increases by +5.0 per Age Stage.
* **Modality Modifier:** Applied to the total PR (e.g., Anchor = ×1.2).
* **Domain Affinity:** If a trait belongs to a domain affined to the creature's **State**, PR for that trait is ×0.9.

### Personality Drift Formula
```text
PersonalityChange = (MemoryStrength × EmotionalWeight × AxisModifier × DriveWeight) / PR
```

---

## Design philosophy
- **Slow Emergence:** Personality is a trailing indicator of a life lived.
- **Layered Complexity:** Adult behavior is the result of infant temperament being filtered through years of socialization and cognition.
- **Stability with Age:** The older a creature gets, the more "set in its ways" it becomes.

---

## Implementation / Notes
* **Storage:** Store Aethersign (State, Modality, Drive) permanently in the creature's data block.
* **Processing:** Run personality drift calculations during the "Sleep" or "Long Rest" state.

