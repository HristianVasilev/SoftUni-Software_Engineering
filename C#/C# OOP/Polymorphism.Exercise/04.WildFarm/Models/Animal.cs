using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models
{
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            protected set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            private set { foodEaten = value; }
        }

        public abstract string AskForFood();

        public virtual void Feed(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}";
        }

    }
}
