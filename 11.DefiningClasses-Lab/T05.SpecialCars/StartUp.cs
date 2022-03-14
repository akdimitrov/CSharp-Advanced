using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            string inputTires = Console.ReadLine();
            while (inputTires != "No more tires")
            {
                string[] tiresInfo = inputTires.Split();
                List<Tire> tires = new List<Tire>();
                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);
                    tires.Add(new Tire(year, pressure));
                }

                tiresList.Add(tires.ToArray());
                inputTires = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            string engine = Console.ReadLine();
            while (engine != "Engines done")
            {
                string[] engineInfo = engine.Split();
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));

                engine = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();
            string input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                int fuelQuantity = int.Parse(carInfo[3]);
                int fuelConsumption = int.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tiresList[tiresIndex]));
                input = Console.ReadLine();
            }

            List<Car> specialCars = cars.Where(
                car => car.Year >= 2017 &&
                car.Engine.HorsePower > 300 &&
                car.Tires.Sum(x => x.Pressure) >= 9 &&
                car.Tires.Sum(x => x.Pressure) <= 10)
                .ToList();

            specialCars.ForEach(x => x.Drive(20));
            specialCars.ForEach(x => Console.WriteLine(x.WhoAmI()));
        }
    }
}
