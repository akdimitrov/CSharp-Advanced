using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> customStack = new CustomStack<int>();
            List<int> integerList = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToList();
            integerList.ForEach(x => customStack.Push(x));

            string input = Console.ReadLine();
            while (input != "END")
            {

                if (input.Contains("Push"))
                {
                    customStack.Push(int.Parse(input.Split()[1]));
                }
                else
                {
                    customStack.Pop();
                }
                input = Console.ReadLine();
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
