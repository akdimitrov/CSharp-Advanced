using System;

namespace T02.TheBattleOfThe5Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int armyRow = 0;
            int armyCol = 0;
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                matrix[row] = inputRow.ToCharArray();
                if (inputRow.Contains('A'))
                {
                    armyRow = row;
                    armyCol = inputRow.IndexOf('A');
                }
            }

            bool hasWon = false;
            while (armor > 0)
            {
                string[] cmd = Console.ReadLine().Split();
                string direction = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);

                matrix[armyRow][armyCol] = '-';
                matrix[row][col] = 'O';
                armor--;

                MoveArmy(matrix, ref armyRow, ref armyCol, direction);
                if (matrix[armyRow][armyCol] == 'M')
                {
                    matrix[armyRow][armyCol] = '-';
                    hasWon = true;
                    break;
                }

                armor -= matrix[armyRow][armyCol] == 'O' ? 2 : 0;
                matrix[armyRow][armyCol] = armor > 0 ? 'A' : 'X';
            }

            Console.WriteLine(!hasWon ? $"The army was defeated at {armyRow};{armyCol}."
                : $"The army managed to free the Middle World! Armor left: {armor}");

            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }

        private static void MoveArmy(char[][] matrix, ref int armyRow, ref int armyCol, string direction)
        {
            switch (direction)
            {
                case "up": armyRow = armyRow - 1 >= 0 ? armyRow -= 1 : armyRow; break;
                case "down": armyRow = armyRow + 1 < matrix.Length ? armyRow += 1 : armyRow; break;
                case "left": armyCol = armyCol - 1 >= 0 ? armyCol -= 1 : armyCol; break;
                case "right": armyCol = armyCol + 1 < matrix[armyRow].Length ? armyCol += 1 : armyCol; break;
            }
        }
    }
}
