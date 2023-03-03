using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        private Dictionary<string,Player> players;

        public Team(string name)
        {
            Name = name;
            players = new Dictionary<string,Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        public int Rating
        {
            get
            {
                double ratingSum = 0;
                foreach (Player p in players.Values) 
                {
                    ratingSum += p.Stats;
                }

                return (int)Math.Round(ratingSum);
            }
        }


        public void AddPlayer(Player player)
        {
            players.Add(player.Name,player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.ContainsKey(playerName))
            {
                players.Remove(playerName);
            }
            else
            {
                Console.WriteLine($"Player {playerName} is not in {Name} team.");
            }
        }

    }
}
