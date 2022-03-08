using System;
using System.Collections.Generic;
using System.Linq;

namespace T14.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] first = new int[n][];
            int[][] second = new int[n][];
            int totalCells = 0;
            for (int row = 0; row < n * 2; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                totalCells += numbers.Length;
                if (row < n)
                {
                    first[row] = numbers;
                    continue;
                }
                second[row - n] = numbers.Reverse().ToArray();
            }

            int rowLength = first[0].Length + second[0].Length;
            for (int row = 0; row < n; row++)
            {
                first[row] = first[row].Concat(second[row]).ToArray();
                if (first[row].Length != rowLength)
                {
                    Console.WriteLine($"The total number of cells is: {totalCells}");
                    Environment.Exit(0);
                }
            }

            foreach (var item in first)
            {
                Console.WriteLine($"[{string.Join(", ", item)}]");
            }
        }
    }
}
