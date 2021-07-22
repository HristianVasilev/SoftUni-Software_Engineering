using FoodShortage.Models.Interfaces;
using System;

namespace FoodShortage.Models.Classes
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
