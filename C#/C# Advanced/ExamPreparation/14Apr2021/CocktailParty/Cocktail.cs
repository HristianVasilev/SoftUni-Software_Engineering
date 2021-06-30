using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    class Cocktail
    {
        private ICollection<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new HashSet<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => this.ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            this.ingredients.Add(ingredient);
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = ingredients.FirstOrDefault(x => x.Name.Equals(name));

            if (ingredient == null)
            {
                return false;
            }

            return this.ingredients.Remove(ingredient);
        }

        public Ingredient FindIngredient(string name)
        {
            return this.ingredients.FirstOrDefault(x => x.Name.Equals(name));
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            if (this.ingredients.Count == 0)
            {
                throw new ArgumentException("There is no ingredients available!");
            }

            int maxAlcohol = this.ingredients.Max(x => x.Alcohol);

            return this.ingredients.First(x => x.Alcohol.Equals(maxAlcohol));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
