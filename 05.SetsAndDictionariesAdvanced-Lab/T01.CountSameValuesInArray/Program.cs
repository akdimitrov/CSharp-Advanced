using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();
            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
            foreach (var number in array)
            {
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }
                numbers[number]++;
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
