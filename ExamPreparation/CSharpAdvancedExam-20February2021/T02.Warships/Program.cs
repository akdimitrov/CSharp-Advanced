using System;
using System.Linq;

namespace T02.Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] attacks = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] field = new char[n, n];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            for (int row = 0; row < n; row++)
            {
                char[] fieldRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                playerOneShips += fieldRow.Count(x => x == '<');
                playerTwoShips += fieldRow.Count(x => x == '>');
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = fieldRow[col];
                }
            }

            int totalShips = playerOneShips + playerTwoShips;
            foreach (var attack in attacks)
            {
                int[] coordinates = attack.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (IsInRage(field, row, col))
                {
                    if (field[row, col] == '<')
                    {
                        field[row, col] = 'X';
                        playerOneShips--;
                    }
                    else if (field[row, col] == '>')
                    {
                        field[row, col] = 'X';
                        playerTwoShips--;
                    }
                    else if (field[row, col] == '#')
                    {
                        MineBlast(field, row, col, ref playerOneShips, ref playerTwoShips);
                    }
                }

                if (playerOneShips <= 0 || playerTwoShips <= 0)
                {
                    break;
                }
            }

            if (playerOneShips > 0 && playerTwoShips > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }
            else
            {
                string winner = playerOneShips > 0 ? "One" : "Two";
                totalShips -= playerOneShips + playerTwoShips;
                Console.WriteLine($"Player {winner} has won the game! {totalShips} ships have been sunk in the battle.");
            }
        }

        public static void MineBlast(char[,] field, int mineRow, int mineCol, ref int playerOneShips, ref int playerTwoShips)
        {
            for (int row = Math.Max(mineRow - 1, 0); row < Math.Min(mineRow + 2, field.GetLength(0)); row++)
            {
                for (int col = Math.Max(mineCol - 1, 0); col < Math.Min(mineCol + 2, field.GetLength(1)); col++)
                {
                    if (field[row, col] == '<')
                    {
                        playerOneShips--;
                    }
                    else if (field[row, col] == '>')
                    {
                        playerTwoShips--;
                    }

                    field[row, col] = 'X';
                }
            }
        }

        public static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
