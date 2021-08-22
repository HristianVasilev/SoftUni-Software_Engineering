namespace WarCroft.Entities.Inventory.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarCroft.Entities.Items;

    public abstract class Bag : IBag
    {
        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>(capacity);
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items as IReadOnlyCollection<Item>;



        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items.FirstOrDefault(t => t.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            return item;
        }
    }
}
