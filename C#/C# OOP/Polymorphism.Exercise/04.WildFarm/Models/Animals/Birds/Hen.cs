using _04.WildFarm.Models.Animals;

namespace _04.WildFarm.Models.Birds
{
    class Hen : Bird
    {
        private const double weightCoef = 0.35;

        public Hen(string name, double weight,  double wingSize)
            : base(name, weight,  wingSize) { }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Feed(Food food)
        {
            this.Weight += food.Quantity * weightCoef;
            base.Feed(food);
        }
    }
}
