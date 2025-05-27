using System.Runtime.InteropServices.Swift;
using System.Threading.Tasks;
using System.Transactions;

public class DynamicArray {
    
    int []  basicArray;
    int length;
    int capacity;

    public DynamicArray(int capacity) {
        this.capacity = capacity;
        this.length = 0;
        this.basicArray = new int[this.capacity];
    }

    public int Get(int i) {
        return basicArray[i];
    }

    public void Set(int i, int n) {
        basicArray[i] = n;
    }

    public void PushBack(int n) {

        if (length == capacity)
        {
            Resize();
        }

        basicArray[length] = n;
        length++;
    }

    public async Task<int> PopBack()
    {
        if (length > 0)
        {
            length--;
        }
        return basicArray[length];
    }

    private void Resize()
    {
        capacity *= 2;
        int[] newArray = new int[capacity];
        for (int i = 0; i < length; i++)
        {
            newArray[i] = basicArray[i];
        }
        basicArray = newArray;

    }

    public int GetSize() {
        return length;
    }

    public int GetCapacity() {
        return capacity;
    }
}



// Singly Linked List Node
public class ListNode {
    public int val;
    public ListNode next;

    // Constructor that sets 'next' to null by default
    public ListNode(int val) {
        this.val = val;
        this.next = null;
    }

    // Constructor that accepts both value and next node
    public ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }
}


public class LinkedList
{
    private ListNode head;
    private ListNode tail;


    public LinkedList()
    {
        this.head = new ListNode(-1);
        this.tail = this.head;
    }

    public int Get(int index)
    {
        var curr = this.head.next;
        int i = 0;
        while (curr != null)
        {
            if (i == index)
            {
                return curr.val;
            }
            i++;
            curr = curr.next;
        }
        return -1;//if it couldnt find it throuw out of bounds. 
    }

    public void InsertHead(int val)
    {
        var newNode = new ListNode(val);
        newNode.next = this.head.next;
        this.head.next = newNode;
        if (newNode.next == null)
        {
            this.tail = newNode;
        }
    }

    public void InsertTail(int val)
    {
        this.tail.next = new ListNode(val);
        this.tail = this.tail.next;
    }

    public bool Remove(int index)
    {
        int i = 0;
        ListNode current = this.head;
        while (i < index && current != null)
        {

            i++;
            current = current.next;
        }
        if (current != null && current.next != null)
        {
            if (current.next == this.tail)
            {
                this.tail = current;
            }
            current.next = current.next.next;
            return true;
        }
        return false;
    }

    public List<int> GetValues()
    {
        ListNode current = this.head.next;
        List<int> res = new List<int>();
        while (current != null)
        {
            res.Add(current.val);
            current = current.next;

        }
        return res;
    }
}