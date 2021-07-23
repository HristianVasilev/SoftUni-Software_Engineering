using System.Collections.Generic;

namespace _07.MilitaryElite.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        public ICollection<IPrivate> PrivatesUnderCommand { get; }
    }
}
