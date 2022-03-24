using System;

namespace T02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            char[,] board = new char[8, 8];
            for (int row = 7; row >= 0; row--)
            {
                string inputRow = Console.ReadLine().Trim();
                for (int col = 0; col <= 7; col++)
                {
                    board[row, col] = inputRow[col];
                    if (inputRow[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (inputRow[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                if (IsWhiteCapture(whiteRow, whiteCol, blackRow, blackCol))
                {
                    Console.WriteLine($"Game over! White capture on {(char)('a' + blackCol)}{blackRow + 1}.");
                    break;
                }
                whiteRow++;
                if (whiteRow == 7)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)('a' + whiteCol)}{whiteRow + 1}.");
                    break;
                }

                if (IsBlackCapture(whiteRow, whiteCol, blackRow, blackCol))
                {
                    Console.WriteLine($"Game over! Black capture on {(char)('a' + whiteCol)}{whiteRow + 1}.");
                    break;
                }
                blackRow--;
                if (blackRow == 0)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)('a' + blackCol)}{blackRow + 1}.");
                    break;
                }
            }
        }

        private static bool IsWhiteCapture(int whiteRow, int whiteCol, int blackRow, int blackCol)
                => (whiteRow + 1 == blackRow && whiteCol - 1 == blackCol)
                || (whiteRow + 1 == blackRow && whiteCol + 1 == blackCol);

        private static bool IsBlackCapture(int whiteRow, int whiteCol, int blackRow, int blackCol)
                => (blackRow - 1 == whiteRow && blackCol - 1 == whiteCol)
                || (blackRow - 1 == whiteRow && blackCol + 1 == whiteCol);
    }
}
