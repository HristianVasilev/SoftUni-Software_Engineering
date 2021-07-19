using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree.Models
{
    public class Product : IProduct
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
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

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
