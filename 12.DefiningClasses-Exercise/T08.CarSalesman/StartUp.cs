using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int inputEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = new Engine(model, power);
                if (engineInfo.Length == 3)
                {
                    string property = engineInfo[2];
                    if (property.All(x => Char.IsDigit(x)))
                    {
                        engine.Displacement = property;
                    }
                    else
                    {
                        engine.Efficiency = property;
                    }
                }
                if (engineInfo.Length > 3)
                {
                    engine.Displacement = engineInfo[2];
                    engine.Efficiency = engineInfo[3];
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            int inputCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];

                Car car = new Car(model, engines.First(x => x.Model == engineModel));
                if (carInfo.Length == 3)
                {
                    string property = carInfo[2];
                    if (property.All(x => Char.IsDigit(x)))
                    {
                        car.Weight = property;
                    }
                    else
                    {
                        car.Color = property;
                    }
                }
                else if (carInfo.Length > 3)
                {
                    car.Weight = carInfo[2];
                    car.Color = carInfo[3];
                }

                cars.Add(car);
            }

            cars.ForEach(x => Console.WriteLine(x));
        }
    }
}
