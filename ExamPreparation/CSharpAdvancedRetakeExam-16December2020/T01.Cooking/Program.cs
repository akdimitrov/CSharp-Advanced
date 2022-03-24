using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> cooked = new Dictionary<string, int>()
            { ["Bread"] = 0, ["Cake"] = 0, ["Fruit Pie"] = 0, ["Pastry"] = 0 };

            while (liquids.Any() && ingredients.Any())
            {
                int ingredient = ingredients.Pop();
                int sum = liquids.Dequeue() + ingredient;
                switch (sum)
                {
                    case 25: cooked["Bread"]++; break;
                    case 50: cooked["Cake"]++; break;
                    case 75: cooked["Pastry"]++; break;
                    case 100: cooked["Fruit Pie"]++; break;
                    default: ingredients.Push(ingredient + 3); break;
                }
            }

            Console.WriteLine(!cooked.Any(x => x.Value == 0) ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");
            Console.WriteLine("Liquids left: {0}", !liquids.Any() ? "none" : string.Join(", ", liquids));
            Console.WriteLine("Ingredients left: {0}", !ingredients.Any() ? "none" : string.Join(", ", ingredients));
            Console.WriteLine(string.Join(Environment.NewLine, cooked.Select(x => $"{x.Key}: {x.Value}")));
        }
    }
}
