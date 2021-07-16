namespace Restaurant.Foods
{
    public class Cake : Dessert
    {
        private const decimal price = 5m;
        private const double grams = 250;
        private const double calories = 1000;

        public Cake(string name) : base(name, price, grams, calories)
        {
        }
    }
}
