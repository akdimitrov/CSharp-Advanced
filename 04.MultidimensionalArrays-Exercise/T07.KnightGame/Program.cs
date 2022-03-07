using System;

namespace T07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int removedKnights = 0;
            while (true)
            {
                int maxMatches = 0;
                int knightRow = 0;
                int knightCol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int matches = Matches(matrix, row, col);
                            if (matches > maxMatches)
                            {
                                maxMatches = matches;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                    }
                }

                if (maxMatches > 0)
                {
                    matrix[knightRow, knightCol] = '0';
                    removedKnights++;
                }
                else
                {
                    Console.WriteLine(removedKnights);
                    break;
                }
            }
        }

        static int Matches(char[,] matrix, int row, int col)
        {
            int matches = 0;
            if (isMatch(matrix, row + 1, col + 2)) matches++;
            if (isMatch(matrix, row + 1, col - 2)) matches++;
            if (isMatch(matrix, row + 2, col + 1)) matches++;
            if (isMatch(matrix, row + 2, col - 1)) matches++;
            if (isMatch(matrix, row - 1, col + 2)) matches++;
            if (isMatch(matrix, row - 1, col - 2)) matches++;
            if (isMatch(matrix, row - 2, col + 1)) matches++;
            if (isMatch(matrix, row - 2, col - 1)) matches++;
            return matches;
        }

        static bool isMatch(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1) &&
                matrix[row, col] == 'K';
        }
    }
}
