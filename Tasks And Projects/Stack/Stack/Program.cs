using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack.Stack<int> stack = new MyStack.Stack<int>(4);
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(3);
            stack.Pop();
            Console.WriteLine(stack.ToString());

 
            Console.ReadLine();
        }
    }
}
