using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            { ["Chocolate cake"] = 0, ["Dipping sauce"] = 0, ["Green salad"] = 0, ["Lobster"] = 0 };
            while (ingredients.Any() && freshnessValues.Any())
            {
                int freshnessValue = freshnessValues.Pop();
                int ingredient = ingredients.Dequeue();
                while (ingredient == 0 && ingredients.Any())
                {
                    ingredient = ingredients.Dequeue();
                }
                if (ingredient == 0)
                {
                    break;
                }

                int freshnessLevel = freshnessValue * ingredient;
                switch (freshnessLevel)
                {
                    case 150: dishes["Dipping sauce"]++; break;
                    case 250: dishes["Green salad"]++; break;
                    case 300: dishes["Chocolate cake"]++; break;
                    case 400: dishes["Lobster"]++; break;
                    default: ingredients.Enqueue(ingredient + 5); break;
                }
            }

            Console.WriteLine(!dishes.Any(x => x.Value == 0)
                ? "Applause! The judges are fascinated by your dishes!"
                : "You were voted off. Better luck next year.");
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
