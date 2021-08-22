namespace WarCroft.Entities.Inventory.Models
{
    public class Backpack : Bag
    {
        private const int defaultCapacity = 100;

        public Backpack() : base(defaultCapacity) { }

    }
}
