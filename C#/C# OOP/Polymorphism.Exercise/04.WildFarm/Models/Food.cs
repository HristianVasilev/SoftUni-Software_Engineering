namespace _04.WildFarm.Models
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }

    }
}
