using System;
using System.Linq;

namespace T01.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = array[0];
            int cols = array[1];
            int[,] matrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] col = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = col[j];
                }
            }

            Console.WriteLine(matrix.GetLongLength(0));
            Console.WriteLine(matrix.GetLongLength(1));
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);
        }
    }
}
