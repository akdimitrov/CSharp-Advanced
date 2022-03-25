using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (Capacity > Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(x => x.Name == name));
        }

        public Pet GetPet(string name, string owner)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            data.ForEach(x => sb.AppendLine($"Pet {x.Name} with owner: {x.Owner}"));
            return sb.ToString().TrimEnd();
        }
    }
}
