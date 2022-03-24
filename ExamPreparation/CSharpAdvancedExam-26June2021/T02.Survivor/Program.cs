using System;

namespace T02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int collectedTokens = 0;
            int opponentTokens = 0;
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();
            }

            string command;
            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] cmd = command.Split();
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                if (!IsInRage(matrix, row, col))
                {
                    continue;
                }

                if (cmd[0] == "Find")
                {
                    CollectTokens(matrix, row, col, ref collectedTokens);
                }
                else if (cmd[0] == "Opponent")
                {
                    string direction = cmd[3];
                    CollectTokens(matrix, row, col, ref opponentTokens);
                    MoveOpponent(matrix, row, col, ref opponentTokens, direction);
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static void MoveOpponent(char[][] matrix, int row, int col, ref int opponentTokens, string direction)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (direction)
                {
                    case "up": row--; break;
                    case "down": row++; break;
                    case "left": col--; break;
                    case "right": col++; break;
                }

                if (!IsInRage(matrix, row, col))
                {
                    break;
                }
                CollectTokens(matrix, row, col, ref opponentTokens);
            }
        }

        private static void CollectTokens(char[][] matrix, int row, int col, ref int tokens)
        {
            if (matrix[row][col] == 'T')
            {
                matrix[row][col] = '-';
                tokens++;
            }
        }

        public static bool IsInRage<T>(T[][] jaggedArray, int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length
                && col >= 0 && col < jaggedArray[row].Length;
        }
    }
}
