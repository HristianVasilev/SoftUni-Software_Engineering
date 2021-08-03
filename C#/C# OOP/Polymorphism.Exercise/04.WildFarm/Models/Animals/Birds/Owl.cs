using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Birds
{
    class Owl : Bird
    {
        private const double weightCoef = 0.25;

        public Owl(string name, double weight,  double wingSize)
            : base(name, weight,  wingSize) { }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Feed(Food food)
        {
            if (food.GetType() != typeof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * weightCoef;
            base.Feed(food);
        }
    }
}
