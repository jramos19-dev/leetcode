public class TwoPointers
{
    public void ReverseString(char[] s)
    {
        if (s.Length == 0)
        {
            return;
        }
        for (int i = s.Length; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
    }


    public bool ValidPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {

                var lIsPal = isPalindrome(left + 1, right);
                var rIsPal = isPalindrome(left, right - 1);
                return lIsPal || rIsPal;
            }
            left++;
            right--;

        }
        return true;

        bool isPalindrome(int l, int r)
        {

            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
                l++;
                r--;

            }
            return true;
        }


    }

    public string MergeAlternately(string word1, string word2)
    {
        string res = "";
        int i = 0;
        for (; i < Math.Min(word1.Length, word2.Length) - 1; i++)
        {
            res += word1[i].ToString() + word2[i];
        }
        res += word1.Substring(i) + word2.Substring(i);

        return res;


    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // Start filling from the end of nums1 (total length is m + n)
        int last = m + n - 1;

        // Set pointers to the last valid elements of nums1 and nums2
        int i = m - 1; // Last element of initial nums1 data
        int j = n - 1; // Last element of nums2

        // Iterate while there are elements left in nums2 to merge
        while (j >= 0)
        {
            // If nums1 still has elements and the current nums1 element is greater than nums2
            if (i >= 0 && nums1[i] > nums2[j])
            {
                // Copy the larger nums1 element to the end of the array
                nums1[last--] = nums1[i--];
            }
            else
            {
                // Otherwise, copy the nums2 element to the end of the array
                nums1[last--] = nums2[j--];
            }
        }
    }
    public int RemoveDuplicates(int[] nums)
    {
        // If the array is empty, there are no elements to process.
        if (nums.Length == 0) return 0;

        // 'l' points to the last unique element in the array.
        int l = 0;

        // Start from the second element and scan through the array with 'r'.
        for (int r = 1; r < nums.Length; r++)
        {
            // If the current element is different from the last unique one,
            // it's a new unique element.
            if (nums[r] != nums[l])
            {
                // Move the 'l' pointer forward to make space for the new unique element.
                l++;

                // Copy the unique element to the correct position in the array.
                nums[l] = nums[r];
            }
            // If nums[r] == nums[l], it's a duplicate, so skip it.
        }

        // 'l' is the index of the last unique element, so total unique elements = l + 1.
        return l + 1;
    }


}