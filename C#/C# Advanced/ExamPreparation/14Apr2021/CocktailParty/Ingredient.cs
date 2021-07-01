using System;
using System.Diagnostics.CodeAnalysis;

namespace CocktailParty
{
    class Ingredient : IComparable<Ingredient>
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public int CompareTo([AllowNull] Ingredient other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return $"Ingredient: {this.Name}{Environment.NewLine}Quantity: {this.Quantity}{Environment.NewLine}Alcohol: {this.Alcohol}";
        }
    }
}
