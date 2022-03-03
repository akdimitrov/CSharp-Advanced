using System;
using System.Collections.Generic;
using System.Linq;

namespace T12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedLitresOfWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                while (currentCup > 0 && bottles.Count > 0)
                {
                    currentCup -= bottles.Pop();
                }

                if (currentCup <= 0)
                {
                    cups.Dequeue();
                    wastedLitresOfWater += Math.Abs(currentCup);
                }
            }

            Console.WriteLine(cups.Count > 0 ?
                $"Cups: {string.Join(" ", cups)}" :
                $"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedLitresOfWater}");
        }
    }
}
