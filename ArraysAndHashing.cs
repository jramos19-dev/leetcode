using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class ArraysAndHashing
{
    public int MajorityElement(int[] nums)
    {
        int count = 0;
        int candidate = 0;
        foreach (int num in nums)
        {
            if (count == 0)
            {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }
        return candidate;

    }

public List<List<int>> FourSum(int[] nums, int target)
{
    Array.Sort(nums);
    List<List<int>> results = new List<List<int>>();
    List<int> quad = new List<int>();

    void ksum(int k, int start, long target)
    {
        if (k == 2)
        {
            int l = start, r = nums.Length - 1;
            while (l < r)
            {
                long sum = (long)nums[l] + nums[r];
                if (sum < target) l++;
                else if (sum > target) r--;
                else
                {
                    var newQuad = new List<int>(quad);
                    newQuad.Add(nums[l]);
                    newQuad.Add(nums[r]);
                    results.Add(new List<int>(newQuad)); // convert to List<int>
                    l++;
                    r--;
                    while (l < r && nums[l] == nums[l - 1]) l++;
                    while (l < r && nums[r] == nums[r + 1]) r--;
                }
            }
        }
        else
        {
            for (int i = start; i < nums.Length - k + 1; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) continue;
                if ((long)nums[i] * k > target) break;
                if ((long)nums[nums.Length - 1] * k < target) break;

                quad.Add(nums[i]);
                ksum(k - 1, i + 1, target - nums[i]);
                quad.RemoveAt(quad.Count - 1);
            }
        }
    }

    ksum(4, 0, target);
    return results;
}


    public int FindJudge(int n, int[][] trust)
    {
        int[] incoming = new int[n + 1];
        int[] outgoing = new int[n + 1];

        foreach (int[] t in trust)
        {
            int a = t[0];
            int b = t[1];
            outgoing[a]++;
            incoming[b]++;

        }

        for (int i = 1; i <= n; i++)
        {
            if (outgoing[i] == 0 && incoming[i] == n - 1)
            {
                return i;
            }
        }
        return -1;
    }

    public void SortColors(int[] nums)
    {
        int l = 0; //left pointer
        int r = nums.Length - 1; //right pointer
        int i = 0; //iterator

        void swap(int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
        while (i <= r)
        {
            if (nums[i] == 0)
            {
                swap(l, i);
                l++;
            }
            else if (nums[i] == 2)
            {
                swap(i, r);
                r--;
                i--;
            }
            i++;
        }
    }
    public List<int> MajorityElement(int[] nums)
    {
        //elements that appear more than 3 times
        int threshold = nums.Length / 3 ;
        Dictionary<int, int> map = new Dictionary<int, int>();
        List<int> res = new List<int>();

        foreach (int n in nums)
        {
            if (!map.ContainsKey(n))
            {
                map[n] = 0;
            }
            map[n]++;

        }
        foreach (var kvp in map)
        {
            if (kvp.Value > threshold)
            {
                res.Add(kvp.Key);
            }
        }

        return res;
    }

}
// public class MyHashSet {
//     int[] array; 
//     public MyHashSet() {
//         this.array = new int[];        
//     }
    
//     public void Add(int key) {
//         this.set.Add(key);
//     }
    
//     public void Remove(int key) {
//         this.set.Remove(key);
//     }
    
//     public bool Contains(int key) {
//         return this.set.Contains(key);
//     }
// }