using System;
using System.Collections.Generic;

namespace T09.DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            while (number > 0)
            {
                stack.Push(number % 2);
                number /= 2;
            }

            Console.WriteLine(stack.Count == 0 ? "0" : string.Join("", stack));
        }
    }
}
