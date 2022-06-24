using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            Stack<int> caloriesPerDay = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int totalMeals = 0;
            while (meals.Any() && caloriesPerDay.Any())
            {
                while (caloriesPerDay.Peek() > 0 && meals.Any())
                {
                    int cals = 0;
                    switch (meals.Dequeue())
                    {
                        case "salad": cals = 350; break;
                        case "soup": cals = 490; break;
                        case "pasta": cals = 680; break;
                        case "steak": cals = 790; break;
                    }

                    caloriesPerDay.Push(caloriesPerDay.Pop() - cals);
                    totalMeals++;
                }

                if (caloriesPerDay.Peek() < 0)
                {
                    int diff = Math.Abs(caloriesPerDay.Pop());
                    if (caloriesPerDay.Any())
                    {
                        caloriesPerDay.Push(caloriesPerDay.Pop() - diff);
                    }
                }
            }

            if (!meals.Any())
            {
                Console.WriteLine($"John had {totalMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesPerDay)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {totalMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
    }
}
