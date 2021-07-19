using _04.PizzaCalories.Enums;
using _04.PizzaCalories.Models;
using System;
using System.Linq;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pizzaArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaArgs[1];

            Pizza pizza = CreatePizza(pizzaName);

            Dough dough = CreateDough();
            pizza.SetDough(dough);

            AddToppings(ref pizza);
            string result = GetResult(pizza);
            Console.WriteLine(result);
        }

        private static string GetResult(Pizza pizza)
        {
            return $"{pizza.Name} - {pizza.Calories:f2} Calories.";
        }

        private static Dough CreateDough()
        {
            string[] doughArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string flourType = doughArgs[1].ToLower();
            string backingTechnique = doughArgs[2].ToLower();
            int weight = int.Parse(doughArgs[3]);

            try
            {
                Dough dough = new Dough(flourType, backingTechnique, weight);
                return dough;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
                throw;
            }

        }

        private static Pizza CreatePizza(string pizzaName)
        {
            try
            {
                return new Pizza(pizzaName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
                throw;
            }
        }

        private static void AddToppings(ref Pizza pizza)
        {
            string inputTopping;
            while ((inputTopping = Console.ReadLine()) != "END")
            {
                string[] toppingArgs = inputTopping.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string toppingType = toppingArgs[1].ToLower();
                int toppingWeight = int.Parse(toppingArgs[2]);

                try
                {
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                catch (ArgumentException ex )
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                    throw;
                }
               
            }
        }
    }
}
