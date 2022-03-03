using System;
using System.Collections.Generic;

namespace T06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (songs.Count > 0)
            {
                string input = Console.ReadLine();
                string action = input.Split()[0];
                if (action == "Play")
                {
                    songs.Dequeue();
                }
                else if (action == "Add")
                {
                    string song = input.Substring(4);
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }
                    songs.Enqueue(song);
                }
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
