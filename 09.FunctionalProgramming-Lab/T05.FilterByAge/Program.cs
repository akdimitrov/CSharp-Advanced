using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peopleAges = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] nameAge = Console.ReadLine().Split(", ");
                peopleAges[nameAge[0]] = int.Parse(nameAge[1]);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<KeyValuePair<string, int>, int, bool> filter = GetFilter(condition);
            peopleAges = peopleAges.Where(x => filter(x, age)).ToDictionary(x => x.Key, x => x.Value);
            Action<KeyValuePair<string, int>> printPerson = PrintPerson(format);
            foreach (var person in peopleAges)
            {
                printPerson(person);
            }
        }

        private static Action<KeyValuePair<string, int>> PrintPerson(string format)
        {
            if (format == "name")
            {
                return x => Console.WriteLine(x.Key);
            }
            else if (format == "age")
            {
                return x => Console.WriteLine(x.Value);
            }
            return x => Console.WriteLine($"{x.Key} - {x.Value}");

        }

        private static Func<KeyValuePair<string, int>, int, bool> GetFilter(string condition)
        {
            if (condition == "older")
            {
                return (person, age) => person.Value >= age;
            }
            return (person, age) => person.Value < age;
        }
    }
}
