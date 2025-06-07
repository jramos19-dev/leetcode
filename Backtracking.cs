public class Backtracking
{
    public int SubsetXORSum(int[] nums)
    {
        
        int dfs(int i , int total)
        {
            if (i == nums.Length)
            {
                return total;
            }
            //include the nums[i]
           return dfs(i + 1, total ^ nums[i]) +
            //do not include nums[i];
            dfs(i + 1, total);
        }


        return dfs(0, 0);
    }
}