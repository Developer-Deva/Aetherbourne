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

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void UpdateSimulation()
    {
        int[,] newGrid = new int[GridWidth, GridHeight];
        bool[,] moved = new bool[GridWidth, GridHeight];

        // 1) Plants spread and copy into newGrid
        for (int x = 0; x < GridWidth; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                if (grid[x, y] == 1)
                {
                    // keep plant
                    if (newGrid[x, y] == 0) newGrid[x, y] = 1;

                    // small chance to spread to a random adjacent empty cell
                    if (rand.NextDouble() < 0.05)
                    {
                        var dirs = GetShuffledDirections();
                        foreach (var d in dirs)
                        {
                            int nx = x + d.dx; int ny = y + d.dy;
                            if (InBounds(nx, ny) && newGrid[nx, ny] == 0 && grid[nx, ny] == 0)
                            {
                                newGrid[nx, ny] = 1;
                                break;
                            }
                        }
                    }
                }
            }
        }

        // helper to process animals in random order to avoid bias
        var coords = new System.Collections.Generic.List<(int x, int y)>();
        for (int x = 0; x < GridWidth; x++) for (int y = 0; y < GridHeight; y++) coords.Add((x, y));
        // shuffle
        for (int i = coords.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var t = coords[i]; coords[i] = coords[j]; coords[j] = t;
        }

        // 2) Herbivores (2): try to eat plants, else move randomly
        foreach (var (x, y) in coords)
        {
            if (grid[x, y] != 2) continue;
            if (moved[x, y]) continue;

            // try to eat adjacent plant
            var dirs = GetShuffledDirections();
            bool acted = false;
            foreach (var d in dirs)
            {
                int nx = x + d.dx; int ny = y + d.dy;
                if (!InBounds(nx, ny)) continue;
                if (grid[nx, ny] == 1 && newGrid[nx, ny] != 2)
                {
                    // move and eat plant
                    newGrid[nx, ny] = 2;
                    moved[nx, ny] = true;
                    acted = true;
                    break;
                }
            }

            if (acted) continue;

            // else move to random empty adjacent cell
            foreach (var d in dirs)
            {
                int nx = x + d.dx; int ny = y + d.dy;
                if (!InBounds(nx, ny)) continue;
                if (newGrid[nx, ny] == 0 && grid[nx, ny] == 0)
                {
                    newGrid[nx, ny] = 2;
                    moved[nx, ny] = true;
                    acted = true;
                    break;
                }
            }

            if (!acted)
            {
                if (newGrid[x, y] == 0) newGrid[x, y] = 2; // stay
            }
        }

        // 3) Carnivores (3): try to eat adjacent herbivores, else move randomly
        foreach (var (x, y) in coords)
        {
            if (grid[x, y] != 3) continue;
            if (moved[x, y]) continue;

            var dirs = GetShuffledDirections();
            bool acted = false;
            foreach (var d in dirs)
            {
                int nx = x + d.dx; int ny = y + d.dy;
                if (!InBounds(nx, ny)) continue;
                if (grid[nx, ny] == 2 && newGrid[nx, ny] != 3)
                {
                    // move and eat herbivore
                    newGrid[nx, ny] = 3;
                    moved[nx, ny] = true;
                    acted = true;
                    break;
                }
            }

            if (acted) continue;

            foreach (var d in dirs)
            {
                int nx = x + d.dx; int ny = y + d.dy;
                if (!InBounds(nx, ny)) continue;
                if (newGrid[nx, ny] == 0 && grid[nx, ny] == 0)
                {
                    newGrid[nx, ny] = 3;
                    moved[nx, ny] = true;
                    acted = true;
                    break;
                }
            }

            if (!acted)
            {
                if (newGrid[x, y] == 0) newGrid[x, y] = 3; // stay
            }
        }

        // If any empty cells remain, they stay 0 (already default)
        grid = newGrid;
    }

    static bool InBounds(int x, int y) => x >= 0 && x < GridWidth && y >= 0 && y < GridHeight;

    static (int dx, int dy)[] GetShuffledDirections()
    {
        var dirs = new (int dx, int dy)[] { (1,0), (-1,0), (0,1), (0,-1) };
        // shuffle locally
        for (int i = dirs.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            var t = dirs[i]; dirs[i] = dirs[j]; dirs[j] = t;
        }
        return dirs;
    }
}
