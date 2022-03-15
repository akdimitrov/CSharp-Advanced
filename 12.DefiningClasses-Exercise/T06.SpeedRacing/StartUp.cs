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
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmd = command.Split();
                string model = cmd[1];
                double distance = double.Parse(cmd[2]);
                cars.First(x => x.Model == model).DiveCar(distance);

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
