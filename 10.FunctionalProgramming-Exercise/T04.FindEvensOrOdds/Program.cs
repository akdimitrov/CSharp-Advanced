using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string oddEven = Console.ReadLine();
            List<int> numbers = new List<int>();
            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.Where(x => oddEven == "even" ? isEven(x) : !isEven(x)).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
