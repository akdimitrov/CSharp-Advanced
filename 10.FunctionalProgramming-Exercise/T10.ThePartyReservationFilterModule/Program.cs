using System;
using System.Collections.Generic;
using System.Linq;

namespace T10.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> predicates = new Dictionary<string, Predicate<string>>();
            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] cmd = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string action = cmd[0];
                string type = cmd[1];
                string value = cmd[2];

                if (action == "Add filter")
                {
                    predicates[type + value] = GetPredicate(type, value);
                }
                else if (action == "Remove filter")
                {
                    predicates.Remove(type + value);
                }

                command = Console.ReadLine();
            }

            foreach (var predicate in predicates)
            {
                guests.RemoveAll(predicate.Value);
            }

            Console.WriteLine(string.Join(" ", guests));
        }

        private static Predicate<string> GetPredicate(string type, string value)
        {
            if (type == "Starts with")
            {
                return x => x.StartsWith(value);
            }
            else if (type == "Ends with")
            {
                return x => x.EndsWith(value);
            }
            else if (type == "Length")
            {
                return x => x.Length == int.Parse(value);
            }
            return x => x.Contains(value);
        }
    }
}
