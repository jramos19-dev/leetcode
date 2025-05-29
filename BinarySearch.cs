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
            int right = piles.Length;
            int left = 0;
            int res = left;
            while (left < right)
            {
                if (piles[left] > res)
                {
                    res = piles[left];
                    left--;
                }
                if (piles[right] > res)
                {
                    res = piles[right];
                    right++;
                }

            }
            return res;

        }


    }
}
