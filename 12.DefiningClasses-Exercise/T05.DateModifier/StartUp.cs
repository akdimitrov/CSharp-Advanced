﻿using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            Console.WriteLine(DateModifier.CalcDifference(date1, date2));
        }
    }
}
