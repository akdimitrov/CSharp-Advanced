using System;

namespace T02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool hasWon = false;
            for (int i = 0; i < commands; i++)
            {
                string direction = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';
                MovePlayer(matrix, ref playerRow, ref playerCol, direction);

                char current = matrix[playerRow, playerCol];
                matrix[playerRow, playerCol] = 'f';
                if (current == 'F')
                {
                    hasWon = true;
                    break;
                }
            }

            Console.WriteLine(hasWon ? "Player won!" : "Player lost!");
            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MovePlayer(char[,] matrix, ref int playerRow, ref int playerCol, string direction)
        {
            int lastRow = playerRow;
            int lastCol = playerCol;

            switch (direction)
            {
                case "up": playerRow = playerRow - 1 < 0 ? matrix.GetLength(0) - 1 : playerRow -= 1; break;
                case "down": playerRow = playerRow + 1 >= matrix.GetLength(0) ? 0 : playerRow += 1; break;
                case "left": playerCol = playerCol - 1 < 0 ? matrix.GetLength(1) - 1 : playerCol -= 1; break;
                case "right": playerCol = playerCol + 1 >= matrix.GetLength(1) ? 0 : playerCol += 1; ; break;
            }

            if (matrix[playerRow, playerCol] == 'T')
            {
                playerRow = lastRow;
                playerCol = lastCol;
            }
            else if (matrix[playerRow, playerCol] == 'B')
            {
                MovePlayer(matrix, ref playerRow, ref playerCol, direction);
            }
        }
    }
}
