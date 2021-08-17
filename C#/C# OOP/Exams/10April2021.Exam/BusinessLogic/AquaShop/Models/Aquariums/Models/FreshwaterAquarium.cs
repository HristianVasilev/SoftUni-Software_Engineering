namespace AquaShop.Models.Aquariums.Models
{
    public class FreshwaterAquarium : Aquarium
    {
        private const int capacity = 50;

        public FreshwaterAquarium(string name) : base(name, capacity) { }

    }
}
