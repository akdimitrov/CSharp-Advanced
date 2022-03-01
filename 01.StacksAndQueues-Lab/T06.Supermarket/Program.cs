using System;
using System.Collections.Generic;

namespace T06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, customers));
                    customers.Clear();
                }
                else
                {
                    customers.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
