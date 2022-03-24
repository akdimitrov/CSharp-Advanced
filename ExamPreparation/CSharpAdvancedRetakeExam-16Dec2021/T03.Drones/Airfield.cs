using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private readonly List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            drones = new List<Drone>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            else if (Count >= Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            return drones.Remove(drones.FirstOrDefault(x => x.Name == name));
        }

        public int RemoveDroneByBrand(string brand)
        {
            return drones.RemoveAll(x => x.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            var drone = drones.FirstOrDefault(x => x.Name == name);
            if (drone != null)
            {
                drone.Available = false;
            }
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var drone in drones.Where(x => x.Range >= range))
            {
                drone.Available = false;
            }
            return drones.Where(x => x.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Drones available at {Name}:");
            foreach (var drone in drones.Where(x => x.Available))
            {
                report.AppendLine(drone.ToString());
            }
            return report.ToString().TrimEnd();
        }
    }
}
