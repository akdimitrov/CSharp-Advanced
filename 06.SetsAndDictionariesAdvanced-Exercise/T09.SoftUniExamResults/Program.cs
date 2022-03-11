using System;
using System.Collections.Generic;
using System.Linq;

namespace T09.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Dictionary<string, Dictionary<string, int>> usersScore = new Dictionary<string, Dictionary<string, int>>();
            string submission;
            while ((submission = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = submission.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string language = tokens[1];
                if (language == "banned")
                {
                    usersScore.Remove(username);
                    continue;
                }

                if (!submissions.ContainsKey(language))
                {
                    submissions[language] = 0;
                }
                submissions[language]++;

                int points = int.Parse(tokens[2]);
                if (!usersScore.ContainsKey(username))
                {
                    usersScore[username] = new Dictionary<string, int>();
                }
                if (!usersScore[username].ContainsKey(language) || usersScore[username][language] < points)
                {
                    usersScore[username][language] = points;
                }
            }

            Console.WriteLine("Results:");
            foreach (var user in usersScore.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value.Values.Sum()}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
