using _03.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            ICollection<Person> people;
            ICollection<Product> products;

            try
            {
                people = ReadPeople(peopleArgs);
                products = ReadProducts(productArgs);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                Environment.Exit(0);
                throw;
            }


            BuyProducts(ref people, ref products);
            string result = GetResult(people);
            Console.WriteLine(result);
        }

        private static string GetResult(ICollection<Person> people)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in people)
            {
                if (person.Products.Count == 0)
                {
                    sb.AppendLine($"{person.Name} - Nothing bought");
                    continue;
                }

                string products = string.Join(", ", person.Products);
                sb.AppendLine($"{person.Name} - {products}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void BuyProducts(ref ICollection<Person> people, ref ICollection<Product> products)
        {
            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "END")
            {
                string[] tokens = inputCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string personName = tokens[0];
                string productName = tokens[1];

                Person person = people.FirstOrDefault(p => p.Name.Equals(personName));
                Product product = products.FirstOrDefault(p => p.Name.Equals(productName));

                if (person == null || product == null)
                {
                    throw new ArgumentNullException("Invalid person or product!");
                }

                bool purchase = person.BuyProduct(product);
                string purchaseResult;

                if (purchase)
                {
                    purchaseResult = $"{person.Name} bought {product.Name}";
                }
                else
                {
                    purchaseResult = $"{person.Name} can't afford {product.Name}";
                }

                Console.WriteLine(purchaseResult);
            }
        }

        private static ICollection<Person> ReadPeople(string[] data)
        {
            ICollection<Person> collection = new List<Person>();

            for (int i = 0; i < data.Length; i++)
            {
                string[] args = data[i].Split('=');

                string name = args[0];
                decimal money = decimal.Parse(args[1]);

                Person person = new Person(name, money);

                collection.Add(person);
            }

            return collection;
        }

        private static ICollection<Product> ReadProducts(string[] data)
        {
            ICollection<Product> collection = new List<Product>();

            for (int i = 0; i < data.Length; i++)
            {
                string[] args = data[i].Split('=');

                string name = args[0];
                decimal money = decimal.Parse(args[1]);

                Product person = new Product(name, money);

                collection.Add(person);
            }

            return collection;
        }
    }
}
