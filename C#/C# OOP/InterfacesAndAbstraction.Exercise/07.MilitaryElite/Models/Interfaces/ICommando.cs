using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public ICollection<IMission> Missions { get; }
    }
}
