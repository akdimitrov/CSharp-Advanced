using System;
using System.Collections.Generic;
using System.Linq;

namespace T04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> products = new SortedDictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] info = input.Split(", ");
                string store = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);
                if (!products.ContainsKey(store))
                {
                    products[store] = new Dictionary<string, double>();
                }
                products[store][product] = price;

                input = Console.ReadLine();
            }

            foreach (var store in products)
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
