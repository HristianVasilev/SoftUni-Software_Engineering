using System;
using System.Collections.Generic;

namespace _09.FruitorVegetable
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();

            data.Add("fruit", new List<string>() { "banana", "apple", "kiwi", "cherry", "lemon", "grapes" });
            data.Add("vegetable", new List<string>() { "tomato", "cucumber", "pepper", "carrot" });

            string product = Console.ReadLine();

            if (data["fruit"].Contains(product))
            {
                Console.WriteLine("fruit");
            }
            else if (data["vegetable"].Contains(product))
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
