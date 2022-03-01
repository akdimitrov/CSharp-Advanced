﻿using System;
using System.Collections.Generic;

namespace T07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> kids = new Queue<string>(Console.ReadLine().Split());
            int tossCount = int.Parse(Console.ReadLine());
            while (kids.Count > 1)
            {
                for (int i = 1; i < tossCount; i++)
                {
                    kids.Enqueue(kids.Dequeue());
                }
                Console.WriteLine($"Removed {kids.Dequeue()}");
            }
            Console.WriteLine($"Last is {kids.Dequeue()}");
        }
    }
}
