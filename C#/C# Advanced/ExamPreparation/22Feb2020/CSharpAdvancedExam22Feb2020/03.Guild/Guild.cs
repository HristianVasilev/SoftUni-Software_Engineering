using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild
{
    class Guild
    {
        private ICollection<Player> players;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.players = new List<Player>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.players.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                this.players.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(x => x.Name.Equals(name));

            if (player == null)
            {
                return false;
            }

            return this.players.Remove(player);
        }

        public void PromotePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(x => x.Name.Equals(name));

            if (player == null)
            {
                return;
            }

            player.Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            Player player = this.players.FirstOrDefault(x => x.Name.Equals(name));

            if (player == null)
            {
                return;
            }

            player.Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            var collection = this.players.Where(x => x.Class.Equals(@class));

            this.players = this.players.Where(x => !x.Class.Equals(@class)).ToList();

            return collection.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.players)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
