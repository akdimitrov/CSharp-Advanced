using System;

namespace T02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int snakeRow = -1;
            int snakeCol = -1;
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodQuantity = 0;
            while (foodQuantity < 10)
            {
                string direction = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                switch (direction)
                {
                    case "up": snakeRow--; break;
                    case "down": snakeRow++; break;
                    case "left": snakeCol--; break;
                    case "right": snakeCol++; break;
                }

                if (!IsInRage(matrix, snakeRow, snakeCol))
                {
                    break;
                }
                else if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    GoThroughLair(matrix, ref snakeRow, ref snakeCol);
                }

                matrix[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine(foodQuantity < 10 ? "Game over!" : "You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void GoThroughLair(char[,] matrix, ref int snakeRow, ref int snakeCol)
        {
            matrix[snakeRow, snakeCol] = '.';
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        snakeRow = row;
                        snakeCol = col;
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
