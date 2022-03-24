using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = roster.Where(x => x.Class == @class).ToArray();
            roster = roster.Where(x => x.Class != @class).ToList();
            return players;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Players in the guild: {Name}");
            roster.ForEach(x => report.AppendLine(x.ToString()));
            return report.ToString().TrimEnd();
        }
    }
}
