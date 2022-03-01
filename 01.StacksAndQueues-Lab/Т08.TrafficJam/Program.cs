using System;
using System.Collections.Generic;

namespace Т08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int passCount = int.Parse(Console.ReadLine());
            int passedCars = 0;
            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < passCount; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        passedCars++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
