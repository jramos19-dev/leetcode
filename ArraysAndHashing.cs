using System.Reflection.Metadata.Ecma335;

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