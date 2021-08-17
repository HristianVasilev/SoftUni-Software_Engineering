namespace AquaShop.Models.Decorations.Models
{
    public class Plant : Decoration
    {
        private const int comfort = 5;
        private const decimal price = 10.00m;

        public Plant() : base(comfort, price) { }

    }
}
