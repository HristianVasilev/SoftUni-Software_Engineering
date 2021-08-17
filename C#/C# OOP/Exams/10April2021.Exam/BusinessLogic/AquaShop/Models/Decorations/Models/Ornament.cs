namespace AquaShop.Models.Decorations.Models
{
    public class Ornament : Decoration
    {
        private const int comfort = 1;
        private const decimal price = 5.00m;

        public Ornament() : base(comfort, price) { }

    }
}
