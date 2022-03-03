using System;
using System.Collections.Generic;
using System.Linq;

namespace T16.PoisonousPlants2
{
    class Program
    {
        static void Main(string[] args)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            List<int> plants = Console.ReadLine().Split().Select(int.Parse).ToList();
            int days = 0;
            while (true)
            {
                plantsCount = plants.Count;
                int comparer = plants.Max();
                for (int i = 0; i < plantsCount; i++)
                {
                    if (plants[i] > comparer)
                    {
                        comparer = plants[i];
                        plants[i] = -1;
                        continue;
                    }
                    comparer = plants[i];
                }

                plants = plants.Where(x => x != -1).ToList();
                if (plantsCount == plants.Count)
                {
                    break;
                }
                days++;
            }

            Console.WriteLine(days);
        }
    }
}