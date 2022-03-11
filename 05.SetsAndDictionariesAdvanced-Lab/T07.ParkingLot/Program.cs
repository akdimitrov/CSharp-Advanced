using System;
using System.Collections.Generic;

namespace T07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string direction = input.Split(", ")[0];
                string carNumber = input.Split(", ")[1];
                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carNumbers.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(carNumbers.Count != 0 ?
                string.Join(Environment.NewLine, carNumbers) : "Parking Lot is Empty");
        }
    }
}
