using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Capacity > Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(GetEmployee(name));
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Employees working at Bakery {Name}:");
            data.ForEach(x => report.AppendLine(x.ToString()));
            return report.ToString().TrimEnd();
        }
    }
}
