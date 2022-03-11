using System;
using System.Collections.Generic;

namespace T03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicTable = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();
                foreach (var element in elements)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
