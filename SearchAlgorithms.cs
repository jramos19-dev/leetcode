using System.Formats.Tar;

public static class SearchAlgorithms
{
    public static int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int middle = l + (r - l) / 2;

            if (target == nums[middle])
            {
                return middle;
            }
            else if (target < nums[middle])
            {
                r = middle - 1;
            }
            else
            {
                l = middle + 1;
            }
        }

        return -1; // return -1 if the target is not found
    }


    public static void testCode()
    {
        int[] nums = new int[] { -1, 0, 2, 4, 6, 8 };

        Console.WriteLine(Search(nums,4 ));
    }

}

