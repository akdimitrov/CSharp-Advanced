using System;
using System.Linq;

namespace T06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Items.Add(double.Parse(Console.ReadLine()));
            }

            double value = double.Parse(Console.ReadLine());
            Console.WriteLine(box.CountGreaterThan(value));
        }
    }
}
