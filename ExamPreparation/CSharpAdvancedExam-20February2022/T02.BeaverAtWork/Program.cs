using System;
using System.Collections.Generic;
using System.Linq;

namespace T02.BeaverAtWork
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int beaverRow = 0;
            int beaverCol = 0;
            int branches = 0;
            char[,] pond = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string pondRow = Console.ReadLine().Replace(" ", "");
                branches += pondRow.Count(x => char.IsLower(x));
                for (int col = 0; col < n; col++)
                {
                    pond[row, col] = pondRow[col];
                    if (pondRow[col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                }
            }

            List<char> collectedBranches = new List<char>();
            string direction;
            while ((direction = Console.ReadLine()) != "end" && branches > 0)
            {
                int nextRow = beaverRow;
                int nextCol = beaverCol;

                if (!HasNext(pond, ref nextRow, ref nextCol, direction))
                {
                    if (collectedBranches.Any())
                    {
                        collectedBranches.RemoveAt(collectedBranches.Count - 1);
                    }
                    continue;
                }

                if (pond[nextRow, nextCol] == 'F')
                {
                    pond[nextRow, nextCol] = '-';
                    switch (direction)
                    {
                        case "up": nextRow = nextRow - 1 >= 0 ? 0 : n - 1; break;
                        case "down": nextRow = nextRow + 1 <= n - 1 ? n - 1 : 0; break;
                        case "left": nextCol = nextCol - 1 >= 0 ? 0 : n - 1; break;
                        case "right": nextCol = nextCol + 1 <= n - 1 ? n - 1 : 0; break;
                    }
                }

                if (char.IsLower(pond[nextRow, nextCol]))
                {
                    collectedBranches.Add(pond[nextRow, nextCol]);
                    branches--;
                }

                pond[beaverRow, beaverCol] = '-';
                pond[nextRow, nextCol] = 'B';
                beaverRow = nextRow;
                beaverCol = nextCol;
            }

            Console.WriteLine(branches == 0 ?
                $"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}."
                : $"The Beaver failed to collect every wood branch. There are {branches} branches left.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write($"{pond[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool HasNext(char[,] matrix, ref int row, ref int col, string direction)
        {
            switch (direction)
            {
                case "up": row--; break;
                case "down": row++; break;
                case "left": col--; break;
                case "right": col++; break;
            }
            return IsInRage(matrix, row, col);
        }

        public static bool IsInRage(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
