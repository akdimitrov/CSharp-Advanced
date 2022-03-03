using System;
using System.Collections.Generic;

namespace T10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    continue;
                }

                int currentTime = greenLightDuration;
                string car = string.Empty;
                while (currentTime > 0 && cars.Count > 0)
                {
                    car = cars.Peek();
                    currentTime -= cars.Dequeue().Length;
                    passedCars++;
                }

                if (currentTime + freeWindowDuration < 0)
                {
                    int index = car.Length - Math.Abs(currentTime + freeWindowDuration);
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{car} was hit at {car[index]}.");
                    return;
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}
