using System;
using System.Linq;

namespace T06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] cmdArgs = input.Split();
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row < 0 || col < 0 || row >= rows || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (cmdArgs[0] == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (cmdArgs[0] == "Subtract")
                {
                    matrix[row][col] -= value;
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
