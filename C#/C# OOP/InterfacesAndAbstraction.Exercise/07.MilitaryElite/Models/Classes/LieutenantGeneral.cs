using _07.MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public ICollection<IPrivate> PrivatesUnderCommand => this.privates;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var priv in privates)
            {
                sb.AppendLine($"  {priv.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
