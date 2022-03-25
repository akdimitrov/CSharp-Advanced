using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            { ["Cherry Bombs"] = 0, ["Datura Bombs"] = 0, ["Smoke Decoy Bombs"] = 0 };

            while (bombEffects.Any() && bombCasings.Any() && bombs.Any(x => x.Value < 3))
            {
                int bombCasing = bombCasings.Pop();
                int sum = bombCasing + bombEffects.Peek();
                switch (sum)
                {
                    case 40: bombs["Datura Bombs"]++; break;
                    case 60: bombs["Cherry Bombs"]++; break;
                    case 120: bombs["Smoke Decoy Bombs"]++; break;
                    default: bombCasings.Push(bombCasing - 5); continue;
                }
                bombEffects.Dequeue();
            }

            Console.WriteLine(!bombs.Any(x => x.Value < 3)
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");
            Console.WriteLine("Bomb Effects: {0}", bombEffects.Any() ? string.Join(", ", bombEffects) : "empty");
            Console.WriteLine("Bomb Casings: {0}", bombCasings.Any() ? string.Join(", ", bombCasings) : "empty");
            Console.WriteLine(string.Join(Environment.NewLine, bombs.Select(x => $"{x.Key}: {x.Value}")));
        }
    }
}
