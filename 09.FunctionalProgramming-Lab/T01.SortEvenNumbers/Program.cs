using System;
using System.Linq;

namespace T01.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, bool> isEven = x => x % 2 == 0;
            Func<string, int> parser = x => int.Parse(x);
            int[] numbers = Console.ReadLine().Split(", ")
                .Select(parser)
                .Where(isEven)
                .OrderBy(x => x)
                .ToArray();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
