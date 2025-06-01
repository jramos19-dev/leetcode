public class Stacks
{
    //  public List<string> GenerateParenthesis(int n) {

    // }


   public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach(string c in tokens){
            switch(c){
                case "+":
                stack.Push(stack.Pop() + stack.Pop());
                break;
                case "-":
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b-a);
                break;
                case "*":
                stack.Push(stack.Pop() * stack.Pop());
                break;
                case "/":
                int e = stack.Pop();
                int f = stack.Pop();
                stack.Push((int) ((double)f/e));
                break;
                default:
                stack.Push(int.Parse(c));
                break;


              
            }
        }
        return stack.Pop();
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
