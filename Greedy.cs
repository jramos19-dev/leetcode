public class Greedy
{
    public int MaxSubArray(int[] nums)
    {
        int maxSub = nums[0];
        int currentSum = 0;

        foreach (int n in nums)
        {
            if (currentSum < 0)
            {
                currentSum = 0;

            }
            currentSum += n;
            maxSub = Math.Max(maxSub, currentSum);
        }
        return maxSub;

    }


    public bool CanJump(int[] nums)
    {
        //given an array of non-negative ints nums, you are position on the first index
        // of the array , for each element in the arry represents the max jump lenght
        // at that position 
        //determine if you can reach the last index 
        // we dont have to do the max jump if it helps better

        // 2, 3, 1, 1, 4
        //output true 
        //using dp[] to cache results of places where weve already tried going

        int goal = nums[nums.Length - 1];

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (i + nums[i] >= goal)
            {
                goal = i;
            }




        }
        return goal == 0; 


    }

    public bool LemonadeChange(int[] bills)
    {

        int fiveCount = 0;
        int tenCount = 0;

        for (int i = 0; i < bills.Length; i++)
        {
            if (bills[i] == 5)
            {
                fiveCount++;
            }
            else if (bills[i] == 10 && fiveCount > 0)
            {
                fiveCount--;
                tenCount++;
            }
            else
            {
                if (fiveCount > 0 && tenCount > 0)
                {
                    fiveCount--;
                    tenCount--;
                }
                else if (fiveCount >= 3)
                {
                    fiveCount -= 3;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }


}
