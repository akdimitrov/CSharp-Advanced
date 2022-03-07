using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[rowsCols[0], rowsCols[1]];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    lair[row, col] = inputRow[col];
                    if (inputRow[col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string moves = Console.ReadLine();
            string result = "dead";
            foreach (var direction in moves)
            {
                lair[currentRow, currentCol] = '.';
                int row = currentRow;
                int col = currentCol;
                switch (direction)
                {
                    case 'U': currentRow--; break;
                    case 'D': currentRow++; break;
                    case 'L': currentCol--; break;
                    case 'R': currentCol++; break;
                }

                if (IsOut(lair, currentRow, currentCol))
                {
                    result = "won";
                    currentRow = row;
                    currentCol = col;
                    SpreadBunnies(lair);
                    break;
                }
                else if (lair[currentRow, currentCol] == 'B')
                {
                    SpreadBunnies(lair);
                    break;
                }

                lair[currentRow, currentCol] = 'P';
                SpreadBunnies(lair);
                if (lair[currentRow, currentCol] == 'B')
                {
                    break;
                }
            }

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{result}: {currentRow} {currentCol}");
        }

        private static void SpreadBunnies(char[,] lair)
        {
            List<int[]> cells = new List<int[]>();
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] != 'B')
                    {
                        continue;
                    }

                    if (!IsOut(lair, row - 1, col) && lair[row - 1, col] != 'B')
                    {
                        cells.Add(new int[] { row - 1, col });
                    }
                    if (!IsOut(lair, row + 1, col) && lair[row + 1, col] != 'B')
                    {
                        cells.Add(new int[] { row + 1, col });
                    }
                    if (!IsOut(lair, row, col - 1) && lair[row, col - 1] != 'B')
                    {
                        cells.Add(new int[] { row, col - 1 });
                    }
                    if (!IsOut(lair, row, col + 1) && lair[row, col + 1] != 'B')
                    {
                        cells.Add(new int[] { row, col + 1 });
                    }
                }
            }

            foreach (var cell in cells)
            {
                lair[cell[0], cell[1]] = 'B';
            }
        }

        static bool IsOut(char[,] lair, int row, int col)
        {
            return row < 0 || row >= lair.GetLength(0) || col < 0 || col >= lair.GetLength(1);
        }
    }
}
