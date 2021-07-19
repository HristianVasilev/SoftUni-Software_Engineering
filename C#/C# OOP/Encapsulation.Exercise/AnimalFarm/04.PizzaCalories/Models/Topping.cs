using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories.Models
{
    class Topping
    {
        private const int baseCalories = 2;

        private static Dictionary<string, double> toppings;
        private string name;
        private double modifier;
        private int weight;

        public Topping(string toppingType, int weight)
        {
            toppings = new Dictionary<string, double>
            {
                {"meat", 1.2},
                {"veggies", 0.8},
                {"cheese", 1.1},
                {"sauce", 0.9},
            };

            TryCreate(toppingType);
            this.Weight = weight;
        }

        public string Name => this.name;

        public double Modifier => this.modifier;

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.Name} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public decimal Calories => CalculateCalories();


        private decimal CalculateCalories()
        {
            return (decimal)(baseCalories * (weight * modifier));
        }

        private void TryCreate(string toppingType)
        {
            var kvp = toppings.FirstOrDefault(x => x.Key.Equals(toppingType));

            if (kvp.Key == default && kvp.Value == default)
            {
                throw new InvalidOperationException($"Cannot place {toppingType} on top of your pizza.");
            }

            this.name = kvp.Key;
            this.modifier = kvp.Value;
        }
    }


}
