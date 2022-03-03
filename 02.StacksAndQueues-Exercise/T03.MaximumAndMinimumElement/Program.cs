using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] query = Console.ReadLine().Split();
                if (query[0] == "1")
                {
                    stack.Push(int.Parse(query[1]));
                }
                else if (query[0] == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (query[0] == "3" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (query[0] == "4" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
