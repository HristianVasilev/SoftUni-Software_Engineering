using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] boxArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int serialNumber = int.Parse(boxArgs[0]);
                string itemName = boxArgs[1];
                int itemQuantity = int.Parse(boxArgs[2]);
                decimal itemPrice = decimal.Parse(boxArgs[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity);
                boxes.Add(box);
            }

            string result = GetAllBoxes(ref boxes);
            Console.WriteLine(result);
        }

        private static string GetAllBoxes(ref List<Box> boxes)
        {
            boxes = boxes.OrderByDescending(x => x.PriceForBox).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var box in boxes)
            {
                sb.AppendLine(box.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }

    class Item
    {
        public Item(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
    }

    class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.ItemQuantity = itemQuantity;
        }

        public int SerialNumber { get; private set; }
        public Item Item { get; private set; }

        public int ItemQuantity { get; private set; }

        public decimal PriceForBox => this.ItemQuantity * Item.Price;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.SerialNumber}");
            sb.AppendLine($"-- {this.Item.Name} - ${this.Item.Price:f2}: {this.ItemQuantity}");
            sb.AppendLine($"-- ${this.PriceForBox:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
