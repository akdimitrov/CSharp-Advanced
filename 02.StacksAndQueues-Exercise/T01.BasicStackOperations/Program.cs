using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int elementsToPush = array[0];
            int elementsToPop = array[1];
            int searchedElement = array[2];
            Stack<int> stack = new Stack<int>(numbers.Take(elementsToPush));
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Count > 0 ? stack.Min() : 0);
            }
        }
    }
}
