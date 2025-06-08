using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Swift;
using System.Text;

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


    int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if ((digits[i] < 9))
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }
        digits = new int[digits.Length + 1];
        digits[0] = 1;
        return digits;

    }

    double MyPow(double x, int n)
    {
        double b = x;

        if (n > 0)
        {
            for (int i = 0; i < n - 1; i++)
            {
                x *= b;
            }
            return x;
        }


        for (int i = 0; i < Math.Abs(n) - 1; i++)
        {
            x *= 1 / b;

        }

        return x;

    }

    string ConvertToTitle(int columnNumber)
    {
        StringBuilder result = new StringBuilder();

        while (columnNumber > 0)
        {
            columnNumber--;
            int remainder = columnNumber % 26;
            char letter = (char)('A' + remainder);
            result.Insert(0, letter);
            columnNumber /= 26;

        }
        return result.ToString();

    }


    public string GcdOfStrings(string str1, string str2)
    {
        int len1 = str1.Length;
        int len2 = str2.Length;

        if (str1 + str2 != str2 + str1)
        {
            return "";
        }

        int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }

        int g = gcd(str1.Length, str2.Length);
        return str1.Substring(0, g);
    }
    public int[][] Transpose(int[][] matrix)
    {
        int length = matrix.Length;
        int width = matrix[0].Length;

        int[][] result = new int[width][];
        for (int i = 0; i < width; i++)
        {
            result[i] = new int[length];
        }

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                result[j][i] = matrix[i][j];
            }
        }

        return result;
    }




    public int RomanToInt(string s)
    {

        // 1. Create a lookup table for Roman symbols to their integer values
        Dictionary<char, int> symbolMapping = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        // 2. Initialize the result accumulator
        int res = 0;

        // 3. Iterate through each character in the input string
        for (int i = 0; i < s.Length; i++)
        {
            // 3a. If this symbol is less than the next one, we have a “subtractive” case
            //     e.g. IV (1 before 5) or IX (1 before 10)
            if (i + 1 < s.Length && symbolMapping[s[i]] < symbolMapping[s[i + 1]])
            {
                // Subtract current value
                res -= symbolMapping[s[i]];
            }
            else
            {
                // Otherwise, just add the current value
                res += symbolMapping[s[i]];
            }
        }

        // 4. Return the final computed integer
        return res;


    }


}