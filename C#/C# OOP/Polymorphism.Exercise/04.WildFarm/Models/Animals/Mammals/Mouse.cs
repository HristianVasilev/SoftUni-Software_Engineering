using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Animals.Mammals
{
    class Mouse : Mammal
    {
        private const double weightCoef = 0.10;

        public Mouse(string name, double weight,  string livingRegion)
            : base(name, weight,  livingRegion) { }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Vegetable) && food.GetType() != typeof(Fruit))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * weightCoef;
            base.Feed(food);
        }
    }
}
