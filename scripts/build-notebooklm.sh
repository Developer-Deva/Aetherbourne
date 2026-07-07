#!/bin/bash
set -euo pipefail

OUTPUT="Aetherbourne-Knowledge-Base.md"

# Files to include manually (in this order)
FILES=(
    "README.md"
    "docs/README.md"

    # World
    "docs/01_world/world.md"
    "docs/flora/01_main.md"
    "docs/flora/02_overview.md"
    "docs/flora/03_generation.md"
    "docs/flora/04_data_tables.md"
    "docs/flora/05_presentation.md"
    "docs/flora/06_simulation_engine.md"
    "docs/flora/07_harvesting_and_processing.md"
    "docs/flora/08_economics_and_trade.md"
    "docs/flora/09_performance.md"
    "docs/flora/10_future_work.md"
    "docs/01_world/minerals.md"
    "docs/05_content/liquids.md"
    "docs/05_content/gases.md"
    "docs/01_world/cosmology.md"

    # Creature Foundations
    "docs/02_creatures/creatures.md"
    "docs/02_creatures/genetics.md"
    "docs/02_creatures/personality.md"
    "docs/note3.md"

    # Creature State
    "docs/02_creatures/stats.md"
    "docs/02_creatures/needs.md"
    "docs/02_creatures/emotions.md"
    "docs/02_creatures/memories.md"
    "docs/02_creatures/relationships.md"

    # Decision Systems
    "docs/02_creatures/skills.md"
    "docs/02_creatures/decisions.md"
    "docs/02_creatures/behavior.md"
    "docs/02_creatures/actions.md"

    # Simulation
    "docs/03_simulation/time.md"
    "docs/03_simulation/events.md"
    "docs/bridge_contracts.md"

    # Society
    "docs/04_society/communities.md"
    "docs/04_society/culture.md"

    # Content
    "docs/05_content/items.md"
    "docs/05_content/consumables.md"
    "docs/05_content/tools.md"
    "docs/05_content/weapons.md"
    "docs/05_content/equipment.md"
    "docs/05_content/furniture.md"
    "docs/05_content/stations.md"
    "docs/05_content/buildings.md"
    "docs/05_content/crafting.md"


    # Other
    "docs/note4.md"
)

# Build the complete file list
ALL_FILES=("${FILES[@]}")

for dir in "${DIRECTORIES[@]}"; do
    while IFS= read -r file; do
        ALL_FILES+=("$file")
    done < <(find "$dir" -maxdepth 1 -type f -name "*.md" | sort)
done

# Remove duplicate entries while preserving order
declare -A seen
UNIQUE_FILES=()

for file in "${ALL_FILES[@]}"; do
    if [[ -f "$file" && -z "${seen[$file]+x}" ]]; then
        UNIQUE_FILES+=("$file")
        seen["$file"]=1
    fi
done

# Create the header
cat > "$OUTPUT" <<EOF
# Aetherbourne Knowledge Base

> Auto-generated from project documentation.
> Do not edit manually.

---

# Contents

EOF

# Generate the Table of Contents
for file in "${UNIQUE_FILES[@]}"; do
    anchor=$(echo "$file" \
        | tr '[:upper:]' '[:lower:]' \
        | sed 's/[^a-z0-9]/-/g')

    echo "- [$file]($anchor)" >> "$OUTPUT"
done

echo "" >> "$OUTPUT"
echo "---" >> "$OUTPUT"

# Append each document
for file in "${UNIQUE_FILES[@]}"; do
    anchor=$(echo "$file" \
        | tr '[:upper:]' '[:lower:]' \
        | sed 's/[^a-z0-9]/-/g')

    {
        echo
        echo "---"
        echo
        echo "<a id=\"$anchor\"></a>"
        echo
        echo "# FILE: $file"
        echo
        cat "$file"
        echo
    } >> "$OUTPUT"
done

echo "Generated $OUTPUT"