public class Queues
{

}

public class MyQueue {
    Stack<int> prefix;
    Stack<int> suffix;

    public MyQueue()
    {
         this.suffix = new Stack<int>();
        this.prefix = new Stack<int>();

    }
    
    public void Push(int x) {
        suffix.Push(x);
    }

    public int Pop() {
        if (prefix.Count == 0)
        {
            while (suffix.Count > 0)
            {
                prefix.Push(suffix.Pop());
            }
        }
        return prefix.Pop();
    }

    public int Peek() {
        if (prefix.Count == 0)
        {
            while (suffix.Count > 0)
            {
                prefix.Push(suffix.Pop());
            }
        }
        return prefix.Peek();
    }
    
    public bool Empty() {
        return prefix.Count == 0 && suffix.Count == 0;
    }
}
