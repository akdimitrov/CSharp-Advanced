using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Comparison<int> comp = new Comparison<int>((x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                return x.CompareTo(y);
            });

            Array.Sort(numbers, comp);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
