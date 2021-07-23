using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public ICollection<IRepair> Repairs { get; }
    }
}
