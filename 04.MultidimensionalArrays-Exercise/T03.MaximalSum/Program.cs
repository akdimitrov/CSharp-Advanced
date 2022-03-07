using System;
using System.Linq;

namespace T03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SquareSize = 3;
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int maxSum = 0;
            int rowIndex = 0;
            int colIndex = 0;
            for (int row = 0; row <= rows - SquareSize; row++)
            {
                for (int col = 0; col <= cols - SquareSize; col++)
                {
                    int sum = 0;
                    for (int i = row; i < row + SquareSize; i++)
                    {
                        for (int j = col; j < col + SquareSize; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = rowIndex; row < rowIndex + SquareSize; row++)
            {
                for (int col = colIndex; col < colIndex + SquareSize; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
