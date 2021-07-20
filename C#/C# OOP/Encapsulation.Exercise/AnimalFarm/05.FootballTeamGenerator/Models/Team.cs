using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Models
{
    class Team
    {
        private string name;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (value == string.Empty || value == null || value.Contains(' '))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Rating => CalculteRating();



        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            int index = FindIndex(playerName);

            if (index == -1)
            {
                throw new ArgumentException($"Player {playerName} is not in {Name} team.");
            }

            players.RemoveAt(index);
        }



        private int FindIndex(string playerName)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Name.Equals(playerName))
                {
                    return i;
                }
            }

            return -1;
        }

        private int CalculteRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(players.Average(x => x.SkillLevel));
        }
    }
}
