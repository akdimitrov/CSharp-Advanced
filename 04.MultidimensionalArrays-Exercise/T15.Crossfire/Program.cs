using System;
using System.Collections.Generic;
using System.Linq;

namespace T15.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<List<int>> matrix = new List<List<int>>();
            int num = 1;
            for (int row = 0; row < size[0]; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row].Add(num++);
                }
            }

            string input = Console.ReadLine();
            while (input != "Nuke it from orbit")
            {
                int[] cmd = input.Split().Select(int.Parse).ToArray();
                int inputRow = cmd[0];
                int inputCol = cmd[1];
                int radius = cmd[2];
                for (int row = 0; row < matrix.Count; row++)
                {
                    for (int col = 0; col < matrix[row].Count; col++)
                    {
                        if (row == inputRow && Math.Abs(inputCol - col) <= radius)
                        {
                            matrix[row][col] = -1;
                        }
                        else if (col == inputCol && Math.Abs(inputRow - row) <= radius)
                        {
                            matrix[row].RemoveAt(col);
                            break;
                        }
                    }
                }

                if (inputRow >= 0 && inputRow < matrix.Count)
                {
                    matrix[inputRow] = matrix[inputRow].Where(x => x != -1).ToList();
                    if (matrix[inputRow].Count == 0)
                    {
                        matrix.RemoveAt(inputRow);
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
