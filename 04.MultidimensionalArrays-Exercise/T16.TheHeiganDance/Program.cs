using System;

namespace T16.TheHeiganDance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PlagueCloudDamage = 3500;
            const int EruptionDamage = 6000;
            int[,] matrix = new int[15, 15];
            double playerHitPoints = 18500;
            double heiganHitPoints = 3000000;
            int playerRow = 7;
            int playerCol = 7;
            double playerDamage = double.Parse(Console.ReadLine());
            string lastSpell = string.Empty;
            bool isHit = false;
            while (playerHitPoints > 0)
            {
                heiganHitPoints -= playerDamage;
                if (lastSpell == "Cloud" && isHit)
                {
                    playerHitPoints -= PlagueCloudDamage;
                }
                isHit = false;

                if (playerHitPoints <= 0 || heiganHitPoints <= 0)
                {
                    break;
                }

                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string spell = input[0];
                int spellRow = int.Parse(input[1]);
                int spellCol = int.Parse(input[2]);

                int startRow = Math.Max(spellRow - 1, 0);
                int endRow = Math.Min(spellRow + 1, 14);
                int startCol = Math.Max(spellCol - 1, 0);
                int endCol = Math.Min(spellCol + 1, 14);
                for (int row = startRow; row <= endRow; row++)
                {
                    for (int col = startCol; col <= endCol; col++)
                    {
                        matrix[row, col] = 1;
                    }
                }

                if (matrix[playerRow, playerCol] == 1)
                {
                    if (playerRow - 1 >= 0 && matrix[playerRow - 1, playerCol] == 0)
                    {
                        playerRow--;
                    }
                    else if (playerCol + 1 < 15 && matrix[playerRow, playerCol + 1] == 0)
                    {
                        playerCol++;
                    }
                    else if (playerRow + 1 < 15 && matrix[playerRow + 1, playerCol] == 0)
                    {
                        playerRow++;
                    }
                    else if (playerCol - 1 >= 0 && matrix[playerRow, playerCol - 1] == 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerHitPoints -= spell == "Cloud" ? PlagueCloudDamage : EruptionDamage;
                        isHit = true;
                    }
                }

                lastSpell = spell;
                matrix = new int[15, 15];
            }

            lastSpell = lastSpell == "Cloud" ? "Plague Cloud" : lastSpell;
            Console.WriteLine(heiganHitPoints <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganHitPoints:f2}");
            Console.WriteLine(playerHitPoints <= 0 ? $"Player: Killed by {lastSpell}" : $"Player: {playerHitPoints}");
            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }
    }
}
