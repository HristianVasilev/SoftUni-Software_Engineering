using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories.Models
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public decimal Calories => CalculateCalories();

        private decimal CalculateCalories()
        {
            decimal doughCalories = dough.Calories;
            decimal toppingCalories = toppings.Sum(x => x.Calories);

            return doughCalories + toppingCalories;
        }

        public void SetDough(Dough dough)
        {
            this.dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 15)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
    }
}
