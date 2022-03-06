using System;

namespace T07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[rows][];
            pascalTriangle[0] = new long[] { 1 };
            Console.WriteLine(1);
            for (long row = 1; row < rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                for (long col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (col == 0 || col == pascalTriangle[row].Length - 1)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                    }

                    Console.Write($"{pascalTriangle[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
