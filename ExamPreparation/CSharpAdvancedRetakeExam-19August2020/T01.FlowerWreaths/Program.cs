using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int flowers = 0;
            while (lilies.Any() && roses.Any())
            {
                int sum = lilies.Pop() + roses.Dequeue();
                flowers += sum <= 15 ? sum : 15;
            }

            int wreaths = flowers / 15;
            Console.WriteLine(wreaths < 5 ? $"You didn't make it, you need {5 - wreaths} wreaths more!"
                : $"You made it, you are going to the competition with {wreaths} wreaths!");
        }
    }
}
