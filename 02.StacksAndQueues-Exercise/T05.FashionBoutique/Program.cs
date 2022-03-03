using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int racks = 0;
            while (clothes.Count > 0)
            {
                racks++;
                int currentRack = 0;
                while (currentRack + clothes.Peek() <= rackCapacity)
                {
                    currentRack += clothes.Pop();
                    if (clothes.Count == 0)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(racks);
        }
    }
}
