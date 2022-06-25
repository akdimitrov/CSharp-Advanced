using System;

namespace T02.WallDestroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (matrix[row, col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            int holes = 0;
            int rodHits = 0;
            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                int nextRow = currentRow;
                int nextCol = currentCol;
                switch (direction)
                {
                    case "up": nextRow--; break;
                    case "down": nextRow++; break;
                    case "left": nextCol--; break;
                    case "right": nextCol++; break;
                    default: continue;
                }

                if (holes == 0)
                {
                    matrix[currentRow, currentCol] = '*';
                    holes++;
                }

                if (!IsInRage(matrix, nextRow, nextCol))
                {
                    continue;
                }

                if (matrix[nextRow, nextCol] == '-' ||
                    matrix[nextRow, nextCol] == '*')
                {
                    currentRow = nextRow;
                    currentCol = nextCol;
                    if (matrix[currentRow, currentCol] == '-')
                    {
                        matrix[currentRow, currentCol] = '*';
                        holes++;
                    }
                    else
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }
                }
                else if (matrix[nextRow, nextCol] == 'R')
                {
                    rodHits++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[nextRow, nextCol] == 'C')
                {
                    holes++;
                    matrix[nextRow, nextCol] = 'E';
                    break;
                }
            }

            if (direction == "End")
            {
                matrix[currentRow, currentCol] = 'V';
                Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodHits} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
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
