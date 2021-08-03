namespace _04.WildFarm.Models.Animals
{
    abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return livingRegion; }
            private set { livingRegion = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
