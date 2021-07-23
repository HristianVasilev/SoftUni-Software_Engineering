using _07.MilitaryElite.Models.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private ICollection<IRepair> repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public Corps Corps { get; }
        public ICollection<IRepair> Repairs => repairs;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");

            foreach (var repair in repairs)
            {
                sb.AppendLine($"  {repair.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}
