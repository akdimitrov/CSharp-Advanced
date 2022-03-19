using System;

namespace T01.GenericBoxOfString
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

            Console.WriteLine(box);
        }
    }
}
