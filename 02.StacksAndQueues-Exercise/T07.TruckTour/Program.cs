using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < petrolPumps; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            for (int i = 0; i < petrolPumps; i++)
            {
                bool isFound = true;
                int totalPetrol = 0;
                foreach (var pump in pumps)
                {
                    totalPetrol += pump[0] - pump[1];
                    if (totalPetrol < 0)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                        isFound = false;
                        break;
                    }
                }

                if (isFound)
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
