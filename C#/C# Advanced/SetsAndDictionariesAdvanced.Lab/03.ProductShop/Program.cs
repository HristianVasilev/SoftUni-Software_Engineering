using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ProductShop
{
    class Product
    {
        public Product(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Product: {this.ProductName}, Price: {this.Price:f1}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Product>> stores = new Dictionary<string, List<Product>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = tokens[0];
                string product = tokens[1];
                decimal price = decimal.Parse(tokens[2]);

                AddProduct(shop, product, price, ref stores);
            }

            string result = GetResult(stores);
            Console.WriteLine(result);
        }

        private static string GetResult(Dictionary<string, List<Product>> stores)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var store in stores.OrderBy(k => k.Key))
            {
                sb.AppendLine($"{store.Key}->");
                store.Value.ForEach(x => sb.AppendLine(x.ToString()));
            }

            return sb.ToString().TrimEnd();
        }

        private static void AddProduct(string shop, string productName, decimal price, ref Dictionary<string, List<Product>> store)
        {
            if (!store.ContainsKey(shop))
            {
                store.Add(shop, new List<Product>());
            }

            Product product = store[shop].FirstOrDefault(x => x.ProductName == productName);

            if (product == null)
            {
                store[shop].Add(new Product(productName, price));
            }
            else
            {
                product.Price = price;
            }
        }
    }
}
