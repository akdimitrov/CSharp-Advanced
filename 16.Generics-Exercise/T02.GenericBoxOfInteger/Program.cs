using System;

namespace T02.GenericBoxOfInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Items.Add(int.Parse(Console.ReadLine()));
            }

            Console.WriteLine(box);
        }
    }
}
