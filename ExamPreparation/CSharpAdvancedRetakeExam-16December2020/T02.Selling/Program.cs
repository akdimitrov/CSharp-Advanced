using System;

namespace T02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int currentRow = -1;
            int currentCol = -1;
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            int money = 0;
            while (money < 50)
            {
                matrix[currentRow, currentCol] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up": currentRow--; break;
                    case "down": currentRow++; break;
                    case "left": currentCol--; break;
                    case "right": currentCol++; break;
                }

                if (!IsInRage(matrix, currentRow, currentCol))
                {
                    break;
                }
                else if (matrix[currentRow, currentCol] == 'O')
                {
                    MoveToOtherPillar(matrix, ref currentRow, ref currentCol);
                }
                else if (char.IsDigit(matrix[currentRow, currentCol]))
                {
                    money += matrix[currentRow, currentCol] - '0';
                }

                matrix[currentRow, currentCol] = 'S';
            }

            Console.WriteLine(money < 50 ? "Bad news, you are out of the bakery."
                : "Good news! You succeeded in collecting enough money!");
            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveToOtherPillar(char[,] matrix, ref int currentRow, ref int currentCol)
        {
            matrix[currentRow, currentCol] = '-';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'O')
                    {
                        currentRow = row;
                        currentCol = col;
                        row = matrix.GetLength(0);
                        break;
                    }
                }
            }
        }

        public static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
