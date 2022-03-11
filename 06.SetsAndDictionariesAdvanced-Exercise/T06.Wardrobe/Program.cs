using System;
using System.Collections.Generic;

namespace T06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] clothes = input[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }
            }

            string[] colorClothing = Console.ReadLine().Split();
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var item in color.Value)
                {
                    Console.Write($"* {item.Key} - {item.Value}");
                    if (color.Key == colorClothing[0] && item.Key == colorClothing[1])
                    {
                        Console.Write($" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
