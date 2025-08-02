using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;


public class StockSpanner {

    Stack<Tuple<int, int>> stack;
    public StockSpanner()
    {
        stack = new Stack<Tuple<int, int>>();
    }

    public int Next(int price)
    {
        int span = 1; // Start with span = 1 to include the current day

        // While the stack is not empty AND the top price is less than or equal to the current price,
        // we "merge" their spans, since today's price breaks their streak
        while (!(stack.Count == 0) && stack.Peek().Item1 <= price)
        {
            // Add the span of the top element to today's span
            // (because all those days had lower or equal prices)
            span += stack.Peek().Item2;
            stack.Pop(); // Remove that price since it's now part of today's span
        }

        // Push the current price and its total span to the stack
        // (so it can help future days compute their spans)
        stack.Push(new Tuple<int, int>(price, span));

        // Return the span for the current day's price
        return span;
    }
}


public class Stacks
{

    public int[] AsteroidCollision(int[] asteroids)
    {

        Stack<int> stack = new Stack<int>(); // Stack to keep track of surviving asteroids

        foreach (int a in asteroids)
        {
            int current = a;

            // Collision check: only happens if current asteroid is moving left (negative)
            // and there's an asteroid on the stack moving right (positive)
            while (stack.Count > 0 && current < 0 && stack.Peek() > 0)
            {
                int diff = current + stack.Peek(); // Simulate collision: net size

                if (diff < 0)
                {
                    // Current asteroid is larger (more negative), so the one on stack explodes
                    stack.Pop();
                    // Keep checking the next asteroid in the stack
                }
                else if (diff > 0)
                {
                    // Asteroid on the stack is larger, so current one explodes
                    current = 0; // Set to 0 to mark as destroyed
                }
                else
                {
                    // Equal size, both explode
                    current = 0;
                    stack.Pop();
                }
            }

            // If current asteroid survived all collisions, push it to the stack
            if (current != 0)
            {
                stack.Push(current);
            }
        }

        return stack.Reverse().ToArray();


    }
    //  public List<string> GenerateParenthesis(int n) {
    // }
}
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

<<<<<<< HEAD

=======
>>>>>>> dc0bf5164fdf7477292df119e6abbcf710cfecf3
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