using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];
            int number = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = number++;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                int rowCol = int.Parse(cmd[0]);
                string direction = cmd[1];
                int moves = int.Parse(cmd[2]);

                if (direction == "up" || direction == "down")
                {
                    ShuffleCol(matrix, rowCol, direction, moves);
                }
                else if (direction == "left" || direction == "right")
                {
                    ShuffleRow(matrix, rowCol, direction, moves);
                }
            }

            ArrangeMatrix(matrix);
        }

        private static void ArrangeMatrix(int[,] matrix)
        {
            int number = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    bool isSwapped = false;
                    number++;
                    if (matrix[row, col] == number)
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }

                    for (int row1 = row; row1 < matrix.GetLength(0); row1++)
                    {
                        for (int col1 = 0; col1 < matrix.GetLength(1); col1++)
                        {
                            if (matrix[row1, col1] == number)
                            {
                                matrix[row1, col1] = matrix[row, col];
                                matrix[row, col] = number;
                                Console.WriteLine($"Swap ({row}, {col}) with ({row1}, {col1})");
                                isSwapped = true;
                                break;
                            }
                        }

                        if (isSwapped)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void ShuffleRow(int[,] matrix, int rowCol, string direction, int moves)
        {
            Queue<int> queue = new Queue<int>();
            moves = moves % matrix.GetLength(0);
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                queue.Enqueue(matrix[rowCol, col]);
            }

            if (direction == "right")
            {
                moves = matrix.GetLength(0) - moves;
            }

            for (int count = 0; count < moves; count++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[rowCol, col] = queue.Dequeue();
            }
        }

        private static void ShuffleCol(int[,] matrix, int rowCol, string direction, int moves)
        {
            Queue<int> queue = new Queue<int>();
            moves = moves % matrix.GetLength(1);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                queue.Enqueue(matrix[row, rowCol]);
            }

            if (direction == "down")
            {
                moves = matrix.GetLength(1) - moves;
            }

            for (int count = 0; count < moves; count++)
            {
                queue.Enqueue(queue.Dequeue());
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, rowCol] = queue.Dequeue();
            }
        }
    }
}
