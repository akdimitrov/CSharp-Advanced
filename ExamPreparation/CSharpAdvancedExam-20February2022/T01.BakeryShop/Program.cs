using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));
            Dictionary<string, int> products = new Dictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                double waterPercent = water.Peek() * 100 / (water.Peek() + flour.Peek());
                double flourDiff = flour.Pop() - water.Dequeue();
                string product = "Croissant";
                switch (waterPercent)
                {
                    case 50: break;
                    case 40: product = "Muffin"; break;
                    case 30: product = "Baguette"; break;
                    case 20: product = "Bagel"; break;
                    default: flour.Push(flourDiff); break;
                }

                if (!products.ContainsKey(product))
                {
                    products[product] = 0;
                }
                products[product]++;
            }

            foreach (var product in products.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            Console.WriteLine("Water left: {0}", water.Any() ? String.Join(", ", water) : "None");
            Console.WriteLine("Flour left: {0}", flour.Any() ? String.Join(", ", flour) : "None");
        }
    }
}
