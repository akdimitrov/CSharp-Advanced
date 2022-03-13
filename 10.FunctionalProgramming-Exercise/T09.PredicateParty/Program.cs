using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            while (command != "Party!")
            {
                string[] cmd = command.Split();
                string condition = cmd[1];
                string value = cmd[2];

                if (cmd[0] == "Remove")
                {
                    names.RemoveAll(GetPredicate(condition, value));
                }
                else if (cmd[0] == "Double")
                {
                    List<string> duplicates = names.FindAll(GetPredicate(condition, value)).ToList();
                    if (duplicates.Any())
                    {
                        int index = names.FindIndex(GetPredicate(condition, value));
                        names.InsertRange(index, duplicates);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(names.Any() ?
                $"{string.Join(", ", names)} are going to the party!" :
                "Nobody is going to the party!");
        }

        private static Predicate<string> GetPredicate(string condition, string value)
        {
            switch (condition)
            {
                case "StartsWith": return x => x.StartsWith(value);
                case "EndsWith": return x => x.EndsWith(value);
                default: return x => x.Length == int.Parse(value);
            }
        }
    }
}
