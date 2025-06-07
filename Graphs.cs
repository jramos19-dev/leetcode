public class Graphs
{
    public int IslandPerimeter(int[][] grid)
    {
        int length = grid.Length;
        int width = grid[0].Length;
        int res = 0;


        for (int r = 0; r < length; r++)
        {
            for (int c = 0; c < width; c++)
            {
                if (grid[r][c] == 1)
                {
                    res += 4;
                    if (r > 0 && grid[r - 1][c] == 1)
                    {
                        res -= 2;
                    }
                    if (c > 0 && grid[r][c - 1] == 1)
                    {
                        res -= 2;
                    }
                }
            }
        }

        return res;
    }
}