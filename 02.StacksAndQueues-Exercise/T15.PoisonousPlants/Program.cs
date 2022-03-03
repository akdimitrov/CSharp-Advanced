using System;
using System.Collections.Generic;
using System.Linq;

namespace T15.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int platnsCount = int.Parse(Console.ReadLine());
            int[] inputPlants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> plants = new Queue<int>(inputPlants);
            int days = 0;
            while (true)
            {
                bool allSurvived = true;
                platnsCount = plants.Count;
                int firstPlant = plants.Dequeue();
                plants.Enqueue(firstPlant);
                for (int i = 0; i < platnsCount - 1; i++)
                {
                    int currentPlant = plants.Dequeue();
                    if (currentPlant <= firstPlant)
                    {
                        plants.Enqueue(currentPlant);
                    }
                    else
                    {
                        allSurvived = false;
                    }
                    firstPlant = currentPlant;
                }

                if (allSurvived)
                {
                    break;
                }
                days++;
            }

            Console.WriteLine(days);
        }
    }
}
