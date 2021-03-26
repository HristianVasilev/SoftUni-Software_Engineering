using System;
using System.Collections.Generic;

namespace _4.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> store = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] commantArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = commantArgs[0];
                decimal price = decimal.Parse(commantArgs[1]);
                int quantiy = int.Parse(commantArgs[2]);

                AddProduct(name, price, quantiy, ref store);
            }

            PrintAllProducts(ref store);
        }

        private static void PrintAllProducts(ref Dictionary<string, Product> store)
        {
            foreach (var item in store)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static void AddProduct(string name, decimal price, int quantiy, ref Dictionary<string, Product> store)
        {
            if (!store.ContainsKey(name))
            {
                store.Add(name, new Product(name, price,quantiy));
                return;
            }

            if (store[name].Price != price)
            {
                store[name].Price = price;
            }

            store[name].Quantity += quantiy;
        }
    }

    class Product
    {
        public Product(string name, decimal price, int quantiy)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantiy;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{this.Name} -> {(this.Price * this.Quantity):f2}";
        }
    }
}
