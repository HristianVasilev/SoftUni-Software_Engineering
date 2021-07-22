using FoodShortage.Models.Interfaces;

namespace _06.FoodShortage.Models.Classes
{
    class Rebel : IBuyer, IObject
    {
        private const int baseFood = 0;
        private const int increaseFood = 5;


        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = baseFood;
        }


        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; }


        public int BuyFood()
        {
            Food += increaseFood;
            return increaseFood;
        }
    }
}
