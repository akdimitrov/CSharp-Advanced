using System;
using System.Collections.Generic;
using System.Linq;

namespace T06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int divider = int.Parse(Console.ReadLine());

            numbers = numbers.Where(x => !isDivisible(x, divider)).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
