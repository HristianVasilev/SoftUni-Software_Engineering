using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals.Mammals
{
    class Dog : Mammal
    {
        private const double weightCoef = 0.40;

        public Dog(string name, double weight,  string livingRegion)
            : base(name, weight,  livingRegion) { }
        public override string AskForFood()
        {
            return "Woof!";
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
