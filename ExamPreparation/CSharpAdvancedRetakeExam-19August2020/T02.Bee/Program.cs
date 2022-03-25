using System;

namespace T02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int beeRow = -1;
            int beeCol = -1;
            char[,] matrix = new char[matrixSize, matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int polinationedFlowers = 0;
            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                FlyBee(matrix, ref beeRow, ref beeCol, direction);
                if (!IsInRage(matrix, beeRow, beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    FlyBee(matrix, ref beeRow, ref beeCol, direction);
                    if (!IsInRage(matrix, beeRow, beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    polinationedFlowers++;
                }
                matrix[beeRow, beeCol] = 'B';
            }

            Console.WriteLine(polinationedFlowers < 5
                ? $"The bee couldn't pollinate the flowers, she needed {5 - polinationedFlowers} flowers more"
                : $"Great job, the bee managed to pollinate {polinationedFlowers} flowers!");

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FlyBee(char[,] matrix, ref int beeRow, ref int beeCol, string direction)
        {
            matrix[beeRow, beeCol] = '.';
            switch (direction)
            {
                case "up": beeRow--; break;
                case "down": beeRow++; break;
                case "left": beeCol--; break;
                case "right": beeCol++; break;
            }
        }

        public static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
