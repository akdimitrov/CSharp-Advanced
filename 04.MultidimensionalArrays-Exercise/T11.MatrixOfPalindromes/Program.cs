using System;
using System.Linq;

namespace T11.MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char first = (char)('a' + row);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = $"{first}{(char)(first + col)}{first}";
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
