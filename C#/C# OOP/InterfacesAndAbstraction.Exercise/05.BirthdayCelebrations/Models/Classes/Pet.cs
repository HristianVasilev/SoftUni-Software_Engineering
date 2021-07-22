using _05.BirthdayCelebrations.Models.Interfaces;
using System;

namespace _05.BirthdayCelebrations.Models.Classes
{
    class Pet : ICreature, IObject
    {
        public Pet(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }

        public DateTime Birthdate { get; }
    }
}
