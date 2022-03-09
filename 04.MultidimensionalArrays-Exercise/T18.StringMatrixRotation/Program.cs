using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T18.StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            Match number = Regex.Match(Console.ReadLine(), @"\d+");
            int rotationDegress = int.Parse(number.ToString()) % 360;
            string input = Console.ReadLine();
            List<List<char>> jagged = new List<List<char>>();
            int maxRowLength = 0;
            while (input != "END")
            {
                jagged.Add(new List<char>());
                jagged[^1].AddRange(input);
                if (maxRowLength < jagged[^1].Count)
                {
                    maxRowLength = jagged[^1].Count;
                }

                input = Console.ReadLine();
            }

            foreach (var row in jagged)
            {
                row.AddRange(new string(' ', maxRowLength - row.Count));
            }

            if (rotationDegress == 90)
            {
                for (int col = 0; col < maxRowLength; col++)
                {
                    for (int row = jagged.Count - 1; row >= 0; row--)
                    {
                        Console.Write(jagged[row][col]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotationDegress == 180)
            {
                for (int row = jagged.Count - 1; row >= 0; row--)
                {
                    for (int col = maxRowLength - 1; col >= 0; col--)
                    {
                        Console.Write(jagged[row][col]);
                    }
                    Console.WriteLine();
                }
            }
            else if (rotationDegress == 270)
            {
                for (int col = maxRowLength - 1; col >= 0; col--)
                {
                    for (int row = 0; row < jagged.Count; row++)
                    {
                        Console.Write(jagged[row][col]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                foreach (var row in jagged)
                {
                    Console.WriteLine(string.Join("", row));
                }
            }
        }
    }
}
