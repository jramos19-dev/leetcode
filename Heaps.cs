using System.Drawing;

public class Heaps
{
    public int[][] KClosest(int[][] points, int k)
    {


        var maxHeap = new PriorityQueue<int[], int>();

        foreach (var point in points)
        {
            int distance = point[0] * point[0] + point[1] * point[1];
            maxHeap.Enqueue(point, -distance); // Negative to simulate max-heap

            if (maxHeap.Count > k)
            {
                maxHeap.Dequeue(); // Remove the farthest point
            }

        }

        var result = new int[k][];
        for (int i = 0; i < k; i++)
        {
            result[i] = maxHeap.Dequeue();
        }

        return result;


    }
}


public class KthLargest {
private PriorityQueue<int, int> minHeap;
    private int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        this.minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k) {
                minHeap.Dequeue();
            }
        }
    }

    public int Add(int val) {
        minHeap.Enqueue(val, val);
        if (minHeap.Count > k) {
            minHeap.Dequeue();
        }
        return minHeap.Peek();
    }
}