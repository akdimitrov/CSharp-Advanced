using System;
using System.Linq;

namespace T04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                string[] column = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = column[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmd[0] == "swap" && cmd.Length == 5)
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);
                    if (IsValidCoordinate(matrix, row1, col1) && IsValidCoordinate(matrix, row2, col2))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                        PrintMatrix(matrix);
                        continue;
                    }
                }

                Console.WriteLine("Invalid input!");
            }
        }

        static void PrintMatrix(string[,] matrix)
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

        static bool IsValidCoordinate(string[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
    }
}
