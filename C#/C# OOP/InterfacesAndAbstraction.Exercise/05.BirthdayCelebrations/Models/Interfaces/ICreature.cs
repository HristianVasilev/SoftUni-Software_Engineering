using System;

namespace _05.BirthdayCelebrations.Models.Interfaces
{
    interface ICreature
    {
        public string Name { get; }
        public DateTime Birthdate { get; }
    }
}
