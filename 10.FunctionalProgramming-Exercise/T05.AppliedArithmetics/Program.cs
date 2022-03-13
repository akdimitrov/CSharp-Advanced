using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, string, int> mathOperation = GetMathOperation;
            string operation = Console.ReadLine();
            while (operation != "end")
            {
                if (operation == "print")
                {
                    print(numbers);
                }
                else
                {
                    numbers = numbers.Select(x => mathOperation(x, operation)).ToList();
                }

                operation = Console.ReadLine();
            }
        }

        private static int GetMathOperation(int x, string operation)
        {
            switch (operation)
            {
                case "add": return x += 1;
                case "subtract": return x -= 1;
                case "multiply": return x *= 2;
                default: return x;
            }
        }
    }
}
