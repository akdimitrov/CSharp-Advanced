using System;

namespace T04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                string symbols = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
