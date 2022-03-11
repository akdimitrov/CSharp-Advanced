using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> sides = new Dictionary<string, SortedSet<string>>();
            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string side = string.Empty;
                string user = string.Empty;
                if (input.Contains("|"))
                {
                    string[] cmd = input.Split("|");
                    side = cmd[0].Trim();
                    user = cmd[1].Trim();
                }
                else
                {
                    string[] cmd = input.Split("->");
                    user = cmd[0].Trim();
                    side = cmd[1].Trim();
                    string key = sides.FirstOrDefault(x => x.Value.Contains(user)).Key;
                    if (key != null)
                    {
                        sides[key].Remove(user);
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }

                if (!sides.Values.Any(x => x.Contains(user)))
                {
                    if (!sides.ContainsKey(side))
                    {
                        sides[side] = new SortedSet<string>();
                    }
                    sides[side].Add(user);
                }
            }

            foreach (var side in sides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
