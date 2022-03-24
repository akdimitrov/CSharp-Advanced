using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public int Count => participants.Count;

        public void Add(Car car)
        {
            if (!participants.Any(x => x.LicensePlate == car.LicensePlate)
                && Capacity > Count && MaxHorsePower >= car.HorsePower)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return participants.Remove(FindParticipant(licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            return participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            return participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            participants.ForEach(x => report.AppendLine(x.ToString()));
            return report.ToString().TrimEnd();
        }
    }
}
