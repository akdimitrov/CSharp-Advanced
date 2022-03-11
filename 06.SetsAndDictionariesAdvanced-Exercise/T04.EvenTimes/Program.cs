using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }
                numbers[num]++;
            }

            Console.WriteLine(numbers.First(x => x.Value % 2 == 0).Key);
        }
    }
}
