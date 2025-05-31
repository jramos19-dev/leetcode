public class SlidingWindow
{
    public bool CheckInclusion(string s1, string s2)
    {

        if (s1.Length > s2.Length) return false;

        int l = 0;
        int r = s1.Length - 1;

        int[] s1Count = new int[26];
        int[] windowCount = new int[26];
        // Count chars in s1 and first window of s2
        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            windowCount[s2[i] - 'a']++;
        }

        if (s1Count.SequenceEqual(windowCount)) return true;

        for (int i = s1.Length; i < s2.Length; i++)
        {
            // Add new character to the window
            windowCount[s2[i] - 'a']++;
            // Remove character left behind
            windowCount[s2[i - s1.Length] - 'a']--;

            if (s1Count.SequenceEqual(windowCount)) return true;
        }

        return false;

    }

    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var maxHeap = new PriorityQueue<(int value, int index), int>();

        var result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            // Push value and index, use -value for max-heap behavior
            maxHeap.Enqueue((nums[i], i), -nums[i]);

            //when the window is valid (size>=k)
            if (i >= k - 1)
            {
                //revmoe elements outside the current window
                while (maxHeap.Peek().index <= i - k)
                {
                    maxHeap.Dequeue();
                }

                //the current max is at the top of the heap
                result.Add(maxHeap.Peek().value);
            }

        }

        return result.ToArray();


    }
}