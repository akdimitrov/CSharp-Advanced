using System;
using System.Collections.Generic;
using System.Linq;

namespace T13.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<char> snake = new Queue<char>(Console.ReadLine());
            int[] shot = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            ReadMatrix(matrix, snake);
            ShootMatrix(matrix, shot);
            ArrangeMatrix(matrix);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ArrangeMatrix(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Stack<char> stack = new Stack<char>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, col] != ' ')
                    {
                        stack.Push(matrix[row, col]);
                    }
                }

                if (stack.Count > 0)
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        if (stack.Count > 0)
                        {
                            matrix[row, col] = stack.Pop();
                            continue;
                        }
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void ShootMatrix(char[,] matrix, int[] shot)
        {
            int shotRow = shot[0];
            int shotCol = shot[1];
            int radius = shot[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2));
                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void ReadMatrix(char[,] matrix, Queue<char> snake)
        {
            int counter = 0;
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                counter++;
                if (counter % 2 != 0)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                    continue;
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake.Peek();
                    snake.Enqueue(snake.Dequeue());
                }
            }
        }
    }
}
