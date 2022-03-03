using System;
using System.Collections.Generic;

namespace T14.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            for (int i = 0; i < n - 1; i++)
            {
                long lastNum = stack.Pop();
                long prevNum = stack.Peek();
                stack.Push(lastNum);
                stack.Push(prevNum + lastNum);
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
