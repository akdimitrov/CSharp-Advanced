using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] problem = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(problem);
            while (stack.Count > 1)
            {
                int firstNum = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int secondNum = int.Parse(stack.Pop());
                string result = operation == "+" ?
                    (firstNum + secondNum).ToString() :
                    (firstNum - secondNum).ToString();
                stack.Push(result);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
