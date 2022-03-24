﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public IReadOnlyCollection<Fish> Fish => this.fish;

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count >= Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight) =>
            fish.Remove(fish.FirstOrDefault(x => x.Weight == weight));

        public Fish GetFish(string fishType) =>
            fish.FirstOrDefault(x => x.FishType == fishType);

        public Fish GetBiggestFish() =>
            fish.OrderByDescending(x => x.Length).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var fish in this.fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
