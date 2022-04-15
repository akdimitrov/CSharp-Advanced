using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> prices = Console.ReadLine().Split(", ").Select(decimal.Parse).ToList();
            Func<decimal, decimal> addVat = x => x * 1.2m;
            prices = prices.Select(addVat).ToList();
            prices.ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}