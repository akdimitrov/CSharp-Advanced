using System;
using System.Linq;

namespace T05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SquareSize = 2;
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] column = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = column[col];
                }
            }

            int startingRow = 0;
            int startingCol = 0;
            int maxSum = int.MinValue;
            for (int row = 0; row < rows; row++)
            {
                if (row + SquareSize > rows)
                {
                    break;
                }
                for (int col = 0; col < cols; col++)
                {
                    if (col + SquareSize > cols)
                    {
                        break;
                    }

                    int sum = matrix[row, col] + matrix[row, col + 1] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startingRow = row;
                        startingCol = col;
                    }
                }
            }

            for (int row = startingRow; row < startingRow + SquareSize; row++)
            {
                for (int col = startingCol; col < startingCol + SquareSize; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
