using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            Lake lake = new Lake(integerList);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
