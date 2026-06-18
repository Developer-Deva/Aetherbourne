using System;
using Raylib_cs;

class Program
{
    // Simulation grid dimensions
    const int GridWidth = 50;
    const int GridHeight = 35;
    const int CellSize = 16; // Size of each pixel-art square in pixels

    // 0 = Empty, 1 = Plant/Food, 2 = Herbivore, 3 = Carnivore
    static int[,] grid = new int[GridWidth, GridHeight];
    static Random rand = new Random();

    static void Main()
    {
        // 1. Initialize Window (Upscaled to look like retro pixel art)
        Raylib.InitWindow(GridWidth * CellSize, GridHeight * CellSize, "Emergent Life Sim Workspace");
        Raylib.SetTargetFPS(10); // Slower updates so you can see emergent behavior develop

        // 2. Procedural Generation: Seed the world with random life forms
        for (int x = 0; x < GridWidth; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                int roll = rand.Next(100);
                if (roll < 15) grid[x, y] = 1;      // 15% chance for vegetation
                else if (roll < 18) grid[x, y] = 2; // 3% chance for prey
                else if (roll < 20) grid[x, y] = 3; // 2% chance for predators
                else grid[x, y] = 0;                // Empty space
            }
        }

        // 3. Main Simulation Loop
        while (!Raylib.WindowShouldClose())
        {
            // Logic Phase: Processes rule-based emergent behaviors
            UpdateSimulation();

            // Render Phase: Draws the pixel grid
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    Color cellColor = grid[x, y] switch
                    {
                        1 => Color.Lime,       // Vegetation
                        2 => Color.SkyBlue,    // Herbivore/Prey
                        3 => Color.Magenta,     // Carnivore/Predator
                        _ => Color.DarkGray    // Empty floor tile
                    };

                    // Draw the cell as a crisp retro block
                    Raylib.DrawRectangle(x * CellSize, y * CellSize, CellSize - 1, CellSize - 1, cellColor);
                }
            }

            // Debug: draw a persistent test string and a small box so we can verify rendering
            Raylib.DrawText("RENDER CHECK", 6, 6, 14, Color.Red);
            Raylib.DrawRectangle(6, 28, 20, 20, Color.Gold);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void UpdateSimulation()
    {
        // This is where your custom rules, cellular automata formulas, 
        // or entity logic functions will be called every frame.
    }
}
