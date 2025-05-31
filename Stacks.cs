public class Stacks
{
     public List<string> GenerateParenthesis(int n) {

    }




}



public class MinStack
{
    private Stack<int> stack = new Stack<int>();
    private Stack<int> prefix = new Stack<int>();

    public MinStack()
    {
        this.stack = new Stack<int>();
        this.prefix = new Stack<int>();

    }

    public void Push(int val)
    {
        stack.Push(val);
        if (prefix.Count == 0)
        {
            prefix.Push(val);
        }
        else
        {
            //we use peeek cause pop will remove it from the stack
            prefix.Push(Math.Min(prefix.Peek(), val));
        }
    }

    public void Pop()
    {
        if (stack.Count > 0)
        {
            stack.Pop();
            prefix.Pop();
        }
    }

    public int Top()
    {
        //peek again because pop actually removes it from the stack. 
        return this.stack.Peek();
    }

    public int GetMin()
    {
        return prefix.Peek();
    }
}
