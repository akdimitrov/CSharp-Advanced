using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Tire[] tires = new Tire[4];
                int tireIndex = 0;
                for (int j = 5; j < carInfo.Length; j += 2)
                {
                    double tirePressure = double.Parse(carInfo[j]);
                    int tireAge = int.Parse(carInfo[j + 1]);
                    tires[tireIndex++] = new Tire(tireAge, tirePressure);
                }

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string sortingCriteria = Console.ReadLine();
            var sortedCars = cars.Where(x => x.Cargo.Type == sortingCriteria && sortingCriteria == "fragile" ?
            x.Tires.Any(x => x.Pressure < 1) : x.Engine.Power > 250).ToList();

            sortedCars.ForEach(x => Console.WriteLine(x.Model));
        }
    }
}
