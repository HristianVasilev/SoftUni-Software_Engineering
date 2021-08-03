namespace _04.WildFarm.Models.Animals
{
    abstract class Bird : Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get { return wingSize; }
            protected set { wingSize = value; }
        }

        public override string ToString()
        {
            return base.ToString() + $" [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
