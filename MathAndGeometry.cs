using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Swift;

public class MathAndGeometry
{
    public List<int> SpiralOrder(int[][] matrix)
    {
        // Initialize result list to store the spiral order
        List<int> res = new List<int>();

        // Define boundaries
        int left = 0, right = matrix[0].Length;  // right is exclusive
        int top = 0, bottom = matrix.Length;     // bottom is exclusive

        // Loop while boundaries are valid
        while (left < right && top < bottom)
        {
            // Traverse the top row from left to right
            for (int i = left; i < right; i++)
            {
                res.Add(matrix[top][i]);
            }
            top++;  // move the top boundary down

            // Traverse the rightmost column from top to bottom
            for (int i = top; i < bottom; i++)
            {
                res.Add(matrix[i][right - 1]);
            }
            right--;  // move the right boundary left

            // ⚠️ BUG HERE: This check is wrong. It breaks the loop prematurely.
            if (left < right && top < bottom)
            {
                break;  // ❌ This causes early exit; should be a continue condition, not a break
            }

            // Traverse the bottom row from right to left
            for (int j = right - 1; j >= left; j--)  // FIX: j should decrement
            {
                res.Add(matrix[bottom - 1][j]);
            }
            bottom--;  // move the bottom boundary up

            // Traverse the leftmost column from bottom to top
            for (int i = bottom - 1; i >= top; i--)  // FIX: i should decrement
            {
                res.Add(matrix[i][left]);
            }
            left++;  // move the left boundary right
        }

        // Return the result
        return res;


    }

    public void SetZeroes(int[][] matrix)
    {
        // Given an m x n matrix of integers, if an element is 0, set its entire row and column to 0.
        // Must update the matrix in-place and aim for O(1) additional space.

        // Arrays to hold dimensions — these are unused in logic but used for getting lengths
        int[] ROWS = new int[matrix.Length];
        int[] COLS = new int[matrix[0].Length];

        // Flag to track if the first row needs to be zeroed
        bool firstRow = false;

        // First pass: mark rows and columns to be zeroed using the first row and column
        for (int r = 0; r < ROWS.Length; r++)
        {
            for (int c = 0; c < COLS.Length; c++)
            {
                if (matrix[r][c] == 0)
                {
                    // Mark column to be zeroed by setting top cell of column to 0
                    matrix[0][c] = 0;

                    if (r > 0)
                    {
                        // Mark row to be zeroed by setting left cell of row to 0
                        matrix[r][0] = 0;
                    }
                    else
                    {
                        // If the zero is in the first row, track it separately
                        firstRow = true;
                    }
                }
            }
        }

        // Second pass: set matrix cells to 0 based on markers, skipping first row and column
        for (int r = 1; r < ROWS.Length; r++)
        {
            for (int c = 1; c < COLS.Length; c++)
            {
                // If this cell's row or column was marked, set it to 0
                if (matrix[0][c] == 0 || matrix[r][0] == 0)
                {
                    matrix[r][c] = 0;
                }
            }
        }

        // If the top-left cell is 0, the first column needs to be zeroed
        if (matrix[0][0] == 0)
        {
            for (int r = 0; r < ROWS.Length; r++)
            {
                matrix[r][0] = 0;
            }
        }

        // If the first row had a zero, zero out the entire first row
        if (firstRow)
        {
            for (int c = 0; c < COLS.Length; c++)
            {
                matrix[0][c] = 0;
            }
        }
    }



    public bool IsHappy(int n)
    {
        var visited = new HashSet<int>();

        while (!visited.Contains(n))
        {
            n = sumOfSquares(n);
            if (n == 1)
            {
                return true;
            }
        }
        return false;

        int sumOfSquares(int n)
        {
            // 
            int output = 0;
            while (n != 0)
            {
                int digit = n % 10;
                digit *= digit;
                output += digit;
                n /= 10;
            }
            return output;


        }
    }
}