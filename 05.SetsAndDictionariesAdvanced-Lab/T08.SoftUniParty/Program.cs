using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestList = new HashSet<string>();
            string reservationNumber = Console.ReadLine();
            while (reservationNumber != "PARTY")
            {
                guestList.Add(reservationNumber);
                reservationNumber = Console.ReadLine();
            }

            string guest = Console.ReadLine();
            while (guest != "END")
            {
                guestList.Remove(guest);
                guest = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count);
            foreach (var guestNum in guestList.Where(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(guestNum);
            }
            foreach (var guestNum in guestList.Where(x => char.IsLetter(x[0])))
            {
                Console.WriteLine(guestNum);
            }
        }
    }
}
