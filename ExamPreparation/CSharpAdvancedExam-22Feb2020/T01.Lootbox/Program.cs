using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> box1 = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> box2 = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int totalValue = 0;
            while (box1.Any() && box2.Any())
            {
                int box1Item = box1.Peek();
                int box2Item = box2.Pop();
                int value = box1Item + box2Item;
                if (value % 2 == 0)
                {
                    box1.Dequeue();
                    totalValue += value;
                }
                else
                {
                    box1.Enqueue(box2Item);
                }
            }

            Console.WriteLine(!box1.Any() ? "First lootbox is empty" : "Second lootbox is empty");
            Console.WriteLine(totalValue >= 100 ? $"Your loot was epic! Value: {totalValue}" : $"Your loot was poor... Value: {totalValue}");
        }
    }
}
