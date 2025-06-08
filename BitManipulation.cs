using System.Collections;
using System.Globalization;
using System.Text;

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


    public string AddBinary(string a, string b)
    {
        int carry = 0;

        // Store original lengths of a and b
        int aLength = a.Length;
        int bLength = b.Length;

        // StringBuilder to build the resulting binary string
        StringBuilder result = new StringBuilder();

        // Loop while there are digits left in a or b, or there's a carry
        while (aLength > 0 || bLength > 0 || carry > 0)
        {
            // Get the current bit from a, or 0 if we've gone past its beginning
            int bitA = (aLength > 0) ? a[aLength - 1] - '0' : 0;

            // Get the current bit from b, or 0 if we've gone past its beginning
            int bitB = (bLength > 0) ? b[bLength - 1] - '0' : 0;

            // Add the bits along with any carry from previous step
            int sum = bitA + bitB + carry;

            // The new bit to add to result is sum % 2 (0 or 1)
            result.Insert(0, sum % 2);

            // Update carry (1 if sum is 2 or 3, 0 if sum is 0 or 1)
            carry = sum / 2;

            // Move to the next most significant bit in both strings
            aLength--;
            bLength--;
        }

        // Return the final binary string
        return result.ToString();
    }
}