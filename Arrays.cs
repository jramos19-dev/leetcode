public class Arrays()
{
    int[] SortArray(int[] nums)
    {
        int n = nums.Length;

        //build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            heapify(nums, n, i);
        }

        //extrac t elements one by one from the heap 
        for (int i = n - 1; i > 0; i--)
        {
            Swap(nums, 0, i);

            heapify(nums, i, 0);
        }


        void heapify(int[] nums, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && nums[left] > nums[largest])
            {
                largest = left;

            }

            if (right < n && nums[right] > nums[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(nums, i, largest);

                heapify(nums, n, largest);
            }

        }

        void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        return nums;
    }
    bool IsValidSudoku(char[][] board)
    {
        // Dictionaries to store seen characters in rows, columns, and 3x3 squares
        Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
        Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
        Dictionary<string, HashSet<char>> squares = new Dictionary<string, HashSet<char>>();

        // Iterate through each cell in the 9x9 board
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char current = board[r][c];

                // Skip empty cells (typically represented by '.' in Sudoku)
                if (current == '.')
                    continue;

                // Each 3x3 square is identified by its row and column group (e.g., "0,0", "1,2")
                string squareKey = (r / 3) + "," + (c / 3);

                // Check if the current number already exists in the same row, column, or 3x3 square
                if ((rows.ContainsKey(r) && rows[r].Contains(current)) ||
                    (cols.ContainsKey(c) && cols[c].Contains(current)) ||
                    (squares.ContainsKey(squareKey) && squares[squareKey].Contains(current)))
                {
                    // If it does, the board is invalid
                    return false;
                }

                // If not present, initialize sets if needed and add the number to row, column, and square
                if (!rows.ContainsKey(r)) rows[r] = new HashSet<char>();
                if (!cols.ContainsKey(c)) cols[c] = new HashSet<char>();
                if (!squares.ContainsKey(squareKey)) squares[squareKey] = new HashSet<char>();

                rows[r].Add(current);
                cols[c].Add(current);
                squares[squareKey].Add(current);
            }
        }

        // If no conflicts were found, the board is valid
        return true;
    }



}

public class MyHashSet
{
    readonly int bucketSize = 1000;
    List<int>[] buckets;

    public MyHashSet()
    {
        buckets = new List<int>[bucketSize];
        for (int i = 0; i < bucketSize; i++)
        {
            buckets[i] = new List<int>();
        }
    }

    public void Add(int key)
    {
        int index = key % bucketSize;
        if (!buckets[index].Contains(key))
        {
            buckets[index].Add(key);
        }
    }

    public void Remove(int key)
    {
        int index = key % bucketSize;
        buckets[index].Remove(key);
    }

    public bool Contains(int key)
    {
        int index = key % bucketSize;
        return buckets[index].Contains(key);
    }



}


public class MyHashMap {

    int bucketSize = 1000;
    L
    public MyHashMap()
    {

    }
    
    public void Put(int key, int value) {
        
    }
    
    public int Get(int key) {
        
    }
    
    public void Remove(int key) {
        
    }
}
