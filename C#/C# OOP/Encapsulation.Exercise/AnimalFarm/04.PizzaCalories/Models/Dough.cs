using _04.PizzaCalories.Enums;
using System;

namespace _04.PizzaCalories.Models
{
    class Dough
    {
        private const int baseCaloriesPerGram = 2;
        private FlourType flourType;
        private BakingTechnique backingTechnique;
        private int weight;

        public Dough(string flourType, string backingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return flourType.Name; }
            private set
            {
                FlourType flourType;

                try
                {
                    flourType = new FlourType(value);
                    this.flourType = flourType;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException || ex is InvalidOperationException)
                    {
                        InvalidDough();
                    }
                }

            }
        }

        public string BackingTechnique
        {
            get => this.backingTechnique.Name;
            private set
            {
                BakingTechnique backingTechnique;

                try
                {
                    backingTechnique = new BakingTechnique(value);
                    this.backingTechnique = backingTechnique;
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException || ex is InvalidOperationException)
                    {
                        InvalidDough();
                    }
                }
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public decimal Calories => this.CalculateCalories();

        private void InvalidDough()
        {
            throw new ArgumentException("Invalid type of dough.");
        }

        private decimal CalculateCalories()
        {
            return (decimal)((baseCaloriesPerGram * this.Weight) * this.flourType.Modifier * this.backingTechnique.Modifier);
        }
    }
}
