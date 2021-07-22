using FoodShortage.Models.Interfaces;
using System;

namespace FoodShortage.Models.Classes
{
    class Citizen : ICreature, IObject, IBuyer
    {
        private const int baseFood = 0;
        private const int increaseFood = 10;


        public Citizen(string name, int age, string id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = baseFood;
        }


        public string Name { get; }

        public int Age { get; }

        public string Id { get; }

        public DateTime Birthdate { get; }

        public int Food { get; private set; }


        public int BuyFood()
        {
            Food += increaseFood;
            return increaseFood;
        }
    }
}
