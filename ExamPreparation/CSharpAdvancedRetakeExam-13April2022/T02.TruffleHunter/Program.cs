using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.TruffleHunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] currentRow = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            List<char> foundTruffles = new List<char>();
            int eatenTruffles = 0;
            string command = Console.ReadLine();
            while (command != "Stop the hunt")
            {
                string[] tokens = command.Split();
                string cmd = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);

                if (cmd == "Collect" &&
                    IsInRage(matrix, row, col) &&
                    "BSW".Contains(matrix[row, col]))
                {
                    foundTruffles.Add(matrix[row, col]);
                    matrix[row, col] = '-';
                }
                else if (cmd == "Wild_Boar")
                {
                    string direction = tokens[3];
                    eatenTruffles += EatTruffles(matrix, row, col, direction);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest " +
                $"{foundTruffles.Count(x => x == 'B')} black, " +
                $"{foundTruffles.Count(x => x == 'S')} summer, and " +
                $"{foundTruffles.Count(x => x == 'W')} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenTruffles} truffles.");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        static int EatTruffles(char[,] matrix, int row, int col, string direction)
        {
            int eatenTruffles = 0;
            while (IsInRage(matrix, row, col))
            {
                if ("BSW".Contains(matrix[row, col]))
                {
                    eatenTruffles++;
                    matrix[row, col] = '-';
                }

                switch (direction)
                {
                    case "up": row -= 2; break;
                    case "down": row += 2; break;
                    case "left": col -= 2; break;
                    case "right": col += 2; break;
                }
            }

            return eatenTruffles;
        }

        static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
