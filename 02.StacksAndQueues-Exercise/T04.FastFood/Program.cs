using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ordersQueue = new Queue<int>(orders);
            Console.WriteLine(ordersQueue.Max());
            while (ordersQueue.Count > 0)
            {
                if (foodQuantity < ordersQueue.Peek())
                {
                    break;
                }
                foodQuantity -= ordersQueue.Dequeue();
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
        }
    }
}
