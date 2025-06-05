using System.Diagnostics.CodeAnalysis;
using System.Globalization;

public class Stacks
{
    //  public List<string> GenerateParenthesis(int n) {

    // }

    public int CalPoints(string[] operations)
    {

        List<int> list = new List<int>();
        for (int o = 0; o < operations.Length; o++)
        {
            if (operations[o] == "+")
            {
                int num1 = int.Parse(operations[o - 1]);
                int num2 = int.Parse(operations[o - 2]);
                list.Add(num1 + num2);
            }
            else if (operations[o] == "C")
            {
                list.RemoveAt(o - 1);
            }
            else if (operations[o] == "D")
            {
                int newNum = int.Parse(operations[o - 1]);
                list.Add(newNum * 2);
            }
            else
            {
                list.Add(int.Parse(operations[o]));

            }

        }

        return list.Sum();

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


public class MyStack {

    Queue<int> prefix;
    Queue<int> sufix;
    public MyStack()
    {
        this.prefix = new Queue<int>();
        this.sufix = new Queue<int>();


    }

    public void Push(int x)
    {
        sufix.Enqueue(x);
        while (prefix.Count > 0)
        {
            sufix.Enqueue(prefix.Dequeue());
        }
        var temp = prefix;
        prefix = sufix;
        sufix = temp;
    }
    
    public int Pop() {
        return prefix.Dequeue();
    }
    
    public int Top() {
        return prefix.Peek();
    }
    
    public bool Empty() {
        return prefix.Count == 0;
    }
}