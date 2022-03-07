using System;
using System.Linq;

namespace T08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int row = 0; row < n; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            string[] coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in coordinates)
            {
                int[] rowCol = item.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = rowCol[0];
                int col = rowCol[1];
                int damage = matrix[row, col];
                if (damage > 0)
                {
                    ProcessBomb(matrix, row, col, damage);
                }
            }

            int aliveCells = 0;
            int sum = 0;
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells++;
                    sum += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
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

        static void ProcessBomb(int[,] matrix, int row, int col, int damage)
        {
            matrix[row, col] = 0;
            if (IsInMatrixAndAlive(matrix, row - 1, col - 1))
            {
                matrix[row - 1, col - 1] -= damage;
            }
            if (IsInMatrixAndAlive(matrix, row - 1, col))
            {
                matrix[row - 1, col] -= damage;
            }
            if (IsInMatrixAndAlive(matrix, row - 1, col + 1))
            {
                matrix[row - 1, col + 1] -= damage;
            }

            if (IsInMatrixAndAlive(matrix, row, col - 1))
            {
                matrix[row, col - 1] -= damage;
            }
            if (IsInMatrixAndAlive(matrix, row, col + 1))
            {
                matrix[row, col + 1] -= damage;
            }

            if (IsInMatrixAndAlive(matrix, row + 1, col - 1))
            {
                matrix[row + 1, col - 1] -= damage;
            }
            if (IsInMatrixAndAlive(matrix, row + 1, col))
            {
                matrix[row + 1, col] -= damage;
            }
            if (IsInMatrixAndAlive(matrix, row + 1, col + 1))
            {
                matrix[row + 1, col + 1] -= damage;
            }
        }

        static bool IsInMatrixAndAlive(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLongLength(0) && col >= 0 && col < matrix.GetLength(1) &&
                matrix[row, col] > 0;
        }
    }
}
