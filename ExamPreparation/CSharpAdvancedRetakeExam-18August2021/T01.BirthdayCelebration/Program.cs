using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int waste = 0;
            while (guests.Any() && plates.Any())
            {
                int guest = guests.Dequeue();
                while (guest > 0)
                {
                    guest -= plates.Pop();
                    if (plates.Count == 0)
                    {
                        break;
                    }
                }
                waste += guest * -1;
            }

            Console.WriteLine(guests.Any() ? $"Guests: {string.Join(" ", guests)}" : $"Plates: {string.Join(" ", plates)}");
            Console.WriteLine($"Wasted grams of food: {waste}");
        }
    }
}
