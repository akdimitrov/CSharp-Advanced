using System;
using System.Linq;

namespace T02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] garden = new int[dimensions[0], dimensions[1]];
            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input.Split().Select(int.Parse).ToArray();
                int flowerRow = coordinates[0];
                int flowerCol = coordinates[1];

                if (!IsInRage(garden, flowerRow, flowerCol))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[flowerRow, flowerCol] = -1;
                for (int col = 0; col < garden.GetLongLength(1); col++)
                {
                    garden[flowerRow, col]++;
                }

                for (int row = 0; row < garden.GetLongLength(0); row++)
                {
                    garden[row, flowerCol]++;
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
