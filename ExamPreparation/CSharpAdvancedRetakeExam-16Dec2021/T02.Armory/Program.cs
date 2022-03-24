using System;

namespace T02.Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            int officerRow = 0;
            int officerCol = 0;
            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    armory[row, col] = inputRow[col];
                    if (inputRow[col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            int swordsValue = 0;
            while (swordsValue < 65)
            {
                armory[officerRow, officerCol] = '-';
                string direction = Console.ReadLine();
                switch (direction)
                {
                    case "up": officerRow--; break;
                    case "down": officerRow++; break;
                    case "left": officerCol--; break;
                    case "right": officerCol++; break;
                }

                if (!IsInRage(armory, officerRow, officerCol))
                {
                    break;
                }

                if (armory[officerRow, officerCol] == 'M')
                {
                    armory[officerRow, officerCol] = '-';
                    for (int row = 0; row < n; row++)
                    {
                        for (int col = 0; col < n; col++)
                        {
                            if (armory[row, col] == 'M')
                            {
                                officerRow = row;
                                officerCol = col;
                            }
                        }
                    }
                }
                else if (char.IsDigit(armory[officerRow, officerCol]))
                {
                    swordsValue += armory[officerRow, officerCol] - '0';
                }
                armory[officerRow, officerCol] = 'A';
            }

            Console.WriteLine(swordsValue < 65 ? "I do not need more swords!"
                : "Very nice swords, I will come back for more!");
            Console.WriteLine($"The king paid {swordsValue} gold coins.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(armory[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsInRage<T>(T[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
