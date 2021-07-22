using _05.BirthdayCelebrations.Models.Interfaces;
using System;

namespace _05.BirthdayCelebrations.Models.Classes
{
    class Citizen : ICreature, IObject
    {
        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public DateTime Birthdate { get; }
    }
}
