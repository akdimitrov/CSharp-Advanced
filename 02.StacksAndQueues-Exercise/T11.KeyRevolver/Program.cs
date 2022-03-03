using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int intelligenceValue = int.Parse(Console.ReadLine());
            int totalBullets = 0;
            while (bullets.Count > 0 && locks.Count > 0)
            {
                totalBullets++;
                if (bullets.Pop() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (totalBullets % gunBarrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                int earnedMoney = intelligenceValue - (totalBullets * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
