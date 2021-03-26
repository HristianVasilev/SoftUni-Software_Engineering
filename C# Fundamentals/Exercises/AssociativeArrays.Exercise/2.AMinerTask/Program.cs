using System;
using System.Collections.Generic;

namespace _2.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> store = new Dictionary<string, int>();

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                string resource = command;
                int quantity = int.Parse(Console.ReadLine());

                AddToStore(resource, quantity, ref store);
            }

            PrintResourcesInTheStore(ref store);
        }

        private static void PrintResourcesInTheStore(ref Dictionary<string, int> store)
        {
            foreach (var item in store)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        private static void AddToStore(string resource, int quantity, ref Dictionary<string, int> store)
        {
            if (!store.ContainsKey(resource))
            {
                store.Add(resource, 0);
            }

            store[resource] += quantity;
        }
    }
}
