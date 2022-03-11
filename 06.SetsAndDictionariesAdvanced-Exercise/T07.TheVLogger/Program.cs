using System;
using System.Collections.Generic;
using System.Linq;

namespace T07.TheVLogger
{
    class Vlogger
    {
        public Vlogger()
        {
            Followers = new SortedSet<string>();
            Followings = new HashSet<string>();
        }
        public SortedSet<string> Followers { get; set; }

        public HashSet<string> Followings { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Vlogger> vloggers = new Dictionary<string, Vlogger>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] cmd = input.Split();
                string first = cmd[0];
                if (cmd[1] == "joined" && !vloggers.ContainsKey(first))
                {
                    vloggers[first] = new Vlogger();
                }
                else if (cmd[1] == "followed")
                {
                    string second = cmd[2];
                    if (first != second && vloggers.ContainsKey(first) && vloggers.ContainsKey(second))
                    {
                        vloggers[second].Followers.Add(first);
                        vloggers[first].Followings.Add(second);
                    }
                }

                input = Console.ReadLine();
            }

            int counter = 0;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            foreach (var vlogger in vloggers.OrderByDescending(x => x.Value.Followers.Count).ThenBy(x => x.Value.Followings.Count))
            {
                Console.WriteLine($"{++counter}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Followings.Count} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
