#!/bin/bash

OUTPUT="Aetherbourne-Knowledge-Base.md"

FILES=(
"README.md"
"docs/README.md"
# World
"docs/01_world/world.md"
"docs/01_world/flora.md"
"docs/01_world/minerals.md"

# Creature Foundations
"docs/02_creatures/creatures.md"
"docs/02_creatures/genetics.md"
"docs/01_world/cosmology.md"
"docs/02_creatures/personality.md"
"docs/note3.md"

# Creature State Systems
"docs/02_creatures/stats.md"
"docs/02_creatures/needs.md"
"docs/02_creatures/emotions.md"
"docs/02_creatures/memories.md"
"docs/02_creatures/relationships.md"

# Decision Systems
"docs/02_creatures/skills.md"
"docs/02_creatures/actions.md"
"docs/02_creatures/behavior.md"

# Simulation
"docs/03_simulation/time.md"
"docs/03_simulation/events.md"
"docs/bridge_contract.md"

# Society
"docs/04_society/communities.md"
"docs/04_society/culture.md"

# Content
"docs/05_content/items.md"
"docs/05_content/consumables.md"
"docs/05_content/tools.md"
"docs/05_content/weapons.md"
"docs/05_content/equipment.md"
"docs/05_content/stations.md"
"docs/05_content/crafting.md"
"docs/05_content/liquids.md"
"docs/05_content/gases.md"

# Other
"docs/note4.md"
)

# Create file header

cat > "$OUTPUT" << EOF

# Aetherbourne Knowledge Base

> Auto-generated from project documentation.
> Do not edit manually.

---

# Contents

EOF

# Generate table of contents

for file in "${FILES[@]}"
do
if [ -f "$file" ]; then
echo "- $file" >> "$OUTPUT"
fi
done

echo "" >> "$OUTPUT"
echo "---" >> "$OUTPUT"

# Append documents

for file in "${FILES[@]}"
do
if [ ! -f "$file" ]; then
echo "Warning: $file not found, skipping."
continue
fi

```
echo "" >> "$OUTPUT"
echo "---" >> "$OUTPUT"
echo "" >> "$OUTPUT"
echo "# FILE: $file" >> "$OUTPUT"
echo "" >> "$OUTPUT"
```

done

echo "Generated $OUTPUT"
