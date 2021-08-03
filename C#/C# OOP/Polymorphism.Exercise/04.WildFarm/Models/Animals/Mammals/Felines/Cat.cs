using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Animals.Mammals.Felines
{
    class Cat : Feline
    {
        private const double weightCoef = 0.30;

        public Cat(string name, double weight,  string livingRegion, string breed)
            : base(name, weight,  livingRegion, breed) { }


        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Meat) && food.GetType() != typeof(Vegetable))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * weightCoef;
            base.Feed(food);
        }
    }
}
