using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<Predicate<int>> predicates = new List<Predicate<int>>();
            foreach (var divider in dividers)
            {
                predicates.Add(x => x % divider == 0);
            }

            List<int> numbers = new List<int>();
            for (int i = 1; i <= rangeEnd; i++)
            {

                bool isDivisible = true;
                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
