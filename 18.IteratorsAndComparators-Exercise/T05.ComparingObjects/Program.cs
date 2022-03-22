using System;
using System.Collections.Generic;
using System.Linq;

namespace T05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] personInfo = input.Split();
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);
                string town = personInfo[2];

                people.Add(new Person(name, age, town));
                input = Console.ReadLine();
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;
            int equalCount = people.Count(x => x.CompareTo(people[personIndex]) == 0);

            if (equalCount < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {people.Count - equalCount} {people.Count}");
            }
        }
    }
}
