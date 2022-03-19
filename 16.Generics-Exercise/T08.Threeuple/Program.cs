using System;

namespace T08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            string[] second = Console.ReadLine().Split();
            string[] third = Console.ReadLine().Split();

            string town = first.Length > 4 ? $"{first[3]} {first[4]}" : first[3];
            var tuple1 = new Threeuple<string, string, string>
                ($"{first[0]} {first[1]}", first[2], town);

            var tuple2 = new Threeuple<string, int, bool>
                (second[0], int.Parse(second[1]), second[2] == "drunk");

            var tuple3 = new Threeuple<string, double, string>
                (third[0], double.Parse(third[1]), third[2]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
