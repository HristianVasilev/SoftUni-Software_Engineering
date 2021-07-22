using System;

namespace FoodShortage.Models.Interfaces
{
    interface ICreature
    {
        public string Name { get; }
        public DateTime Birthdate { get; }
    }
}
