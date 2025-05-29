using System.Collections;

public class BitManipulation()
{

    public static int SingleNumber(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
        {
            result ^= num;  // XOR cancels out duplicates
        }
        return result;
    }
}