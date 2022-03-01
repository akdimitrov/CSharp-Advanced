using System;
using System.Collections.Generic;

namespace T04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string problem = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < problem.Length; i++)
            {
                if (problem[i] == '(')
                {
                    stack.Push(i);
                }
                else if (problem[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(problem.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
