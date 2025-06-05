using System.Runtime.InteropServices.Marshalling;
using System.Security.AccessControl;

namespace leetcode
{
    public class BinarySearch
    {
        public static bool searchMatrix(int[][] matrix, int target)
        {
            int[] sorted = matrix.SelectMany(subarray => subarray).ToArray();

            int right = sorted.Length - 1;
            int left = 0;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sorted[mid] == target)
                {
                    return true;
                }
                else if (sorted[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return false;
        }
        public int MinEatingSpeed(int[] piles, int h)
        {
            // Initialize the binary search range
            int l = 1; // Minimum possible speed
            int r = piles.Max(); // Maximum speed is the largest pile
            int res = r; // Initialize result with max possible (we will try to minimize this)

            // Binary search to find the minimum eating speed
            while (l <= r)
            {
                int k = (l + r) / 2; // Midpoint: candidate eating speed
                long totalTime = 0;

                // Calculate total time needed to eat all bananas at speed k
                foreach (int p in piles)
                {
                    // Divide each pile by k and round up, since Koko can only eat whole bananas each hour
                    totalTime += (int)Math.Ceiling((double)p / k);
                }

                if (totalTime <= h)
                {
                    // If Koko can finish in h hours or less, try a smaller speed
                    res = k;
                    r = k - 1;
                }
                else
                {
                    // If it takes too long, increase the speed
                    l = k + 1;
                }
            }

            return res;
        }


        public int GuessNumber(int n)
        {

            int l = 1;
            int r = n;

            while (l <= r)
            {
                int mid = l + (r - l) / 2; // safer way to compute mid without overflow
                int res = guess(mid);     // call the API

                if (res == 0)
                    return mid;           // found the number
                else if (res < 0)
                    r = mid - 1;          // number is lower
                else
                    l = mid + 1;          // number is higher
            }

            return -1; // this should never be reached if input is valid

        }

        public int MySqrt(int x)
        {
            int l = 0;
            int r = x;
            int res = 0;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (mid * mid == x)
                {
                    return mid;
                }
                else if (mid * mid > x)
                {
                    res = mid;
                    r = mid + 1;
                }
                else
                {
                    l = mid - 1;
                }
            }
            return res;

        }



    }
}
