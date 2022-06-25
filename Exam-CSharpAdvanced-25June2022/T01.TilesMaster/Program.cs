using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.TilesMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> greyTiles = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> locationsTiles = new Dictionary<string, int>();
            while (whiteTiles.Any() && greyTiles.Any())
            {
                if (whiteTiles.Peek() == greyTiles.Peek())
                {
                    int area = whiteTiles.Pop() + greyTiles.Dequeue();
                    string location = "Floor";
                    switch (area)
                    {
                        case 40: location = "Sink"; break;
                        case 50: location = "Oven"; break;
                        case 60: location = "Countertop"; break;
                        case 70: location = "Wall"; break;
                    }

                    if (!locationsTiles.ContainsKey(location))
                    {
                        locationsTiles[location] = 0;
                    }

                    locationsTiles[location]++;
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }
            }

            Console.WriteLine(whiteTiles.Any() ?
                $"White tiles left: {string.Join(", ", whiteTiles)}" :
                "White tiles left: none");
            Console.WriteLine(greyTiles.Any() ?
                $"Grey tiles left: {string.Join(", ", greyTiles)}" :
                "Grey tiles left: none");
            foreach (var location in locationsTiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
