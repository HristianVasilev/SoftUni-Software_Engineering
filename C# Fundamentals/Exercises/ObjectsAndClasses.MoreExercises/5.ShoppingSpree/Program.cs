using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.ShoppingSpree
{
    class Program
    {
        private static List<Person> people;
        private static List<Product> products;

        static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            AddPeople(peopleArgs);

            string[] productsArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            AddProducts(productsArgs);

            string purchase = string.Empty;
            while ((purchase = Console.ReadLine()) != "END")
            {
                string[] purchaseArgs = purchase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = purchaseArgs[0];
                string productName = purchaseArgs[1];

                Person person = people.FirstOrDefault(p => p.Name.Equals(personName));
                Product product = products.FirstOrDefault(p => p.Name.Equals(productName));

                if (person is null || product is null)
                {
                    throw new ArgumentNullException();
                }

                try
                {
                    person.Buy(product);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            PrintResult();

        }

        private static void PrintResult()
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void AddProducts(string[] productsArgs)
        {
            products = new List<Product>();

            foreach (var prod in productsArgs)
            {
                string[] productArgs = prod.Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }

        private static void AddPeople(string[] peopleArgs)
        {
            people = new List<Person>();

            foreach (var per in peopleArgs)
            {
                string[] personArgs = per.Split('=', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }

    class Product
    {
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name { get; private set; }
        public decimal Cost { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class Person
    {
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name { get; private set; }
        public decimal Money { get; private set; }
        public List<Product> Bag => this.bagOfProducts;

        public void Buy(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }

            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        public override string ToString()
        {
            if (this.Bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", this.Bag)}";
        }
    }
}
