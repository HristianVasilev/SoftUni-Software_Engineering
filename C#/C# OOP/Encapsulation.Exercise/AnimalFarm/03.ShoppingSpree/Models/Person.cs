using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    class Person : IPerson
    {
        private string name;
        private decimal money;
        private ICollection<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value == null || value == default)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products => this.products as IReadOnlyCollection<Product>;

        public bool BuyProduct(Product product)
        {
            if (this.Money - product.Cost < 0)
            {
                return false;
            }

            this.products.Add(product);
            this.Money -= product.Cost;
            return true;
        }
    }
}
