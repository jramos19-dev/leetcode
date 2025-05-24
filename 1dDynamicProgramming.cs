/*Given an integer array nums, find a subarray that has the largest product within the array and return it.

A subarray is a contiguous non-empty sequence of elements within an array.

You can assume the output will fit into a 32-bit integer.
*/

/* we want to keep track of a min and max numbers to decide if we can make 
a product even if we have negative values, 

base case is also a 0 , we dont want to use them 
*/

// public int MaxProduct(int[] nums) {
//     // Initialize result to the maximum value in the array in case all elements are negative or zero
//     int result = nums.Max();

//     // Track the running maximum and minimum product ending at the current index
//     int max = 1;
//     int min = 1;

//     foreach (int n in nums)
//     {
//         // If the current number is 0, reset both max and min.
//         // A product chain can't continue through 0.
//         if (n == 0)
//         {
//             max = 1;
//             min = 1;
//             continue;
//         }

//         // Store the previous max value because it will be used to compute the new min
//         int prevMax = max;

//         // Update max: take the maximum of:
//         // 1. current number alone (start a new subarray),
//         // 2. current number * previous max (extend the positive product),
//         // 3. current number * previous min (in case a negative * negative becomes positive)
//         max = Math.Max(Math.Max(n * max, n * min), n);

//         // Update min similarly: this handles negative numbers which could flip the sign
//         min = Math.Min(Math.Min(n * prevMax, n * min), n);

//         // Update result if the current max is greater than the global max product found so far
//         result = Math.Max(result, max);
//     }

//     return result; // Return the maximum product found among all subarrays
// }


// bool WordBreak(string s, List<string> wordDict)
// {
//     // We use a DP array where dp[i] is true if we can segment the substring s[i:] (from i to end)
//     bool[] dp = new bool[s.Length + 1];

//     // Base case: an empty string can always be segmented
//     dp[s.Length] = true;

//     // Loop backwards from the end of the string towards the start (bottom-up DP)
//     for (int i = s.Length - 1; i >= 0; i--)
//     {
//         // Check every word in the dictionary
//         foreach (string word in wordDict)
//         {
//             // Check if the word fits in the current position
//             // Make sure (i + word.Length) doesn't go out of bounds
//             // Then check if the substring starting at i matches the dictionary word
//             if ((i + word.Length) <= s.Length && s.Substring(i, word.Length) == word)
//             {
//                 // If the rest of the string after this word can be segmented, mark dp[i] as true
//                 dp[i] = dp[i + word.Length];
//             }

//             // If we already found a match at this position, we don't need to check further
//             if (dp[i])
//             {
//                 break;
//             }
//         }
//     }

//     // The answer is whether the entire string (starting from 0) can be segmented
//     return dp[0];
// }


//  int LengthOfLIS(int[] nums) // Function to find the length of the Longest Increasing Subsequence (LIS)
// {
//     int[] Lis = new int[nums.Length]; // Create an array to store the LIS ending at each index

//     for (int i = 0; i < Lis.Length; i++) // Initialize each element of LIS array to 1
//     {
//         Lis[i] = 1; // Every element is a subsequence of length 1 by itself
//     }

//     // Traverse the array in reverse order
//     for (int i = nums.Length - 1; i >= 0; i--)
//         for (int j = i + 1; j < nums.Length; j++) // Check all elements after i
//         {
//             if (nums[i] < nums[j]) // If nums[i] can be followed by nums[j] in an increasing subsequence
//             {
//                 Lis[i] = Math.Max(Lis[i], 1 + Lis[j]); // Update LIS at i based on LIS at j
//             }
//         }

//     return Lis.Max(); // Return the maximum value in the LIS array, which is the result
// }


// int UniquePaths(int m, int n) // Function to calculate the number of unique paths in an m x n grid
// {
//     int[] dp = new int[n]; // Create a 1D DP array of size 'n' (columns)
//     Array.Fill(dp, 1); // Fill it with 1s, because there's only 1 way to reach the bottom row or rightmost column

//     // Loop from second-last row (m-2) up to the first row (0)
//     for (int i = m - 2; i >= 0; i--) {
//         // Loop from second-last column (n-2) to the first column (0)
//         for (int j = n - 2; j >= 0; j--)
//         {
//             dp[j] += dp[j + 1]; // Update dp[j] by adding the value to its right (dp[j+1])
//         }
//     }

//     return dp[0]; //The top-left cell now holds the total number of unique paths
// }



using System.Runtime.ExceptionServices;

int LongestCommonSubsequence(string text1, string text2)
{
     // Create a 2D DP array with one extra row and column for the base case (empty string)
    int[,] dp = new int[text2.Length + 1, text1.Length + 1];

    // Iterate from the end of both strings to the beginning
    for (int i = text1.Length - 1; i >= 0; i--)
    {
        for (int j = text2.Length - 1; j >= 0; j--)
        {
            // If characters match, add 1 to the result from next characters
            if (text1[i] == text2[j])
            {
                dp[j, i] = 1 + dp[j + 1, i + 1];
            }
            else
            {
                // If they don't match, take the max of skipping a character from either string
                dp[j, i] = Math.Max(dp[j + 1, i], dp[j, i + 1]);
            }
        }
    }

    // The answer is in the top-left cell of the DP table
    return dp[0, 0];

}
