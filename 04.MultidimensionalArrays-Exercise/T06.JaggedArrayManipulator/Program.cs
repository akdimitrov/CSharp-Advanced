using System;
using System.Linq;

namespace T06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    matrix[row] = matrix[row].Select(x => x * 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[row] = matrix[row].Select(x => x / 2).ToArray();
                    matrix[row + 1] = matrix[row + 1].Select(x => x / 2).ToArray();
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] cmd = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);
                if (row >= 0 && row < rows && col >= 0 && col < matrix[row].Length)
                {
                    switch (cmd[0])
                    {
                        case "Add": matrix[row][col] += value; break;
                        case "Subtract": matrix[row][col] -= value; break;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
