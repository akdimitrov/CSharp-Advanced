using System;
using System.Linq;

namespace T09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] moves = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[n, n];
            int totalCoals = 0;
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowSymbols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowSymbols[col];
                    if (rowSymbols[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    else if (rowSymbols[col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            int collectedCoals = 0;
            foreach (var move in moves)
            {
                int row = currentRow;
                int col = currentCol;
                switch (move)
                {
                    case "left": currentCol--; break;
                    case "right": currentCol++; break;
                    case "up": currentRow--; break;
                    case "down": currentRow++; break;
                }

                if (!IsInField(field, currentRow, currentCol))
                {
                    currentRow = row;
                    currentCol = col;
                    continue;
                }

                char currentSymbol = field[currentRow, currentCol];
                if (currentSymbol == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    Environment.Exit(0);
                }
                else if (currentSymbol == 'c')
                {
                    field[currentRow, currentCol] = '*';
                    collectedCoals++;
                    if (totalCoals == collectedCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({currentRow}, {currentCol})");
        }

        private static bool IsInField(char[,] field, int startRow, int startCol)
        {
            return startRow >= 0 && startRow < field.GetLength(0) && startCol >= 0 && startCol < field.GetLength(1);
        }
    }
}
