using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Masterchef
{
    class Program
    {
        private static Dictionary<string, int> dishes;
        private static Dictionary<string, int> preparedDishes;

        static void Main(string[] args)
        {
            dishes = new Dictionary<string, int>
            {
                {"Dipping sauce", 150},
                {"Green salad", 250},
                {"Chocolate cake", 300},
                {"Lobster", 400}
            };
            preparedDishes = new Dictionary<string, int>();

            Queue<int> numberOfIngredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> freshnessLevel = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Cook(ref numberOfIngredients, ref freshnessLevel);

            string result = GetResult(numberOfIngredients);
            Console.WriteLine(result);
        }

        private static string GetResult(Queue<int> numberOfIngredients)
        {
            StringBuilder sb = new StringBuilder();

            if (dishes.All(x => preparedDishes.ContainsKey(x.Key)))
            {
                sb.AppendLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                sb.AppendLine("You were voted off. Better luck next year.");
            }

            if (numberOfIngredients.Count != 0)
            {
                int ingridientsSum = numberOfIngredients.Sum();
                sb.AppendLine($"Ingredients left: {ingridientsSum}");
            }

            Dictionary<string, int> collection = preparedDishes
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var dish in collection)
            {
                sb.AppendLine($" # {dish.Key} --> {dish.Value}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void Cook(ref Queue<int> numberOfIngredients, ref Stack<int> freshnessLevel)
        {
            while (numberOfIngredients.Count != 0 && freshnessLevel.Count != 0)
            {
                int ingredient = numberOfIngredients.Peek();
                int freshness = freshnessLevel.Peek();

                if (ingredient == 0)
                {
                    numberOfIngredients.Dequeue();
                    continue;
                }

                int product = ingredient * freshness;

                if (dishes.Any(v => v.Value.Equals(product)))
                {
                    numberOfIngredients.Dequeue();
                    freshnessLevel.Pop();

                    string dish = dishes.First(x => x.Value.Equals(product)).Key;
                    AddDish(dish);
                }
                else
                {
                    freshnessLevel.Pop();
                    numberOfIngredients.Enqueue(numberOfIngredients.Dequeue() + 5);
                }
            }
        }

        private static void AddDish(string dish)
        {
            if (!preparedDishes.ContainsKey(dish))
            {
                preparedDishes.Add(dish, 0);
            }

            preparedDishes[dish]++;
        }
    }
}
