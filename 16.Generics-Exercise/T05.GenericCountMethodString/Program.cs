using System;
using System.Linq;

namespace T05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Items.Add(Console.ReadLine());
            }

            string value = Console.ReadLine();
            Console.WriteLine(box.CountGreaterThan(value));
        }
    }
}
