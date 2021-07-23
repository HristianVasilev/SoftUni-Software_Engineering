using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.MilitaryElite.Models.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public ICollection<IMission> Missions => missions;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");

            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
