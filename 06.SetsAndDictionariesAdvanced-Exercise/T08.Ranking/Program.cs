using System;
using System.Collections.Generic;
using System.Linq;

namespace T08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string pass = tokens[1];
                contests[contest] = pass;
                input = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> userRank = new SortedDictionary<string, Dictionary<string, int>>();
            string submission = Console.ReadLine();
            while (submission != "end of submissions")
            {
                string[] tokens = submission.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string pass = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (!userRank.ContainsKey(username))
                    {
                        userRank[username] = new Dictionary<string, int>();
                    }
                    if (!userRank[username].ContainsKey(contest) || userRank[username][contest] < points)
                    {
                        userRank[username][contest] = points;
                    }
                }

                submission = Console.ReadLine();
            }

            var bestCandidate = userRank.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in userRank)
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
