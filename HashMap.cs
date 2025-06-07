public class HashMap
{
    
}


public class MyHashMap
{
    int SIZE = 1000;
    List<(int key, int value)>[] buckets;

    public MyHashMap()
    {
        buckets = new List<(int key, int value)>[SIZE];
    }

    public void Put(int key, int value)
    {
        int index = key % SIZE;
        if (buckets[index] == null)
        {
            buckets[index] = new List<(int key, int value)>();
        }
        for (int i = 0; i < buckets[index].Count; i++)
        {
            if (buckets[index][i].key == key)
            {
                buckets[index][i] = (key, value);
                return;
            }
        }

        buckets[index].Add((key, value));
    }

    public int Get(int key)
    {
        int index = key % SIZE;
        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.key == key)
                {
                    return pair.value;
                }
            }
        }
        return -1;
    }

    public void Remove(int key)
    {
        int index = key % SIZE;
        if (buckets[index] != null)
        {
            for (int i = 0; i < buckets[index].Count; i++)
            {
                if (buckets[index][i].key == key)
                {
                    buckets[index].RemoveAt(i);
                    return;
                }
            }
        }
    }
}