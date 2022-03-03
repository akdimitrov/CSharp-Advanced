using System;
using System.Collections.Generic;

namespace T08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            bool isBalanced = true;
            foreach (var item in input)
            {
                if ("{[(".Contains(item))
                {
                    stack.Push(item);
                }
                else
                {
                    char searchedItem = '(';
                    switch (item)
                    {
                        case ']': searchedItem = '['; break;
                        case '}': searchedItem = '{'; break;
                    }

                    if (stack.Count == 0 || stack.Pop() != searchedItem)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
