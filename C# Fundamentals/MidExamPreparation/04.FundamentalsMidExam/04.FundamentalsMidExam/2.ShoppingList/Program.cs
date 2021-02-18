using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ShoppingList
{
    class Program
    {
        private static List<string> groceries;

        static void Main(string[] args)
        {
            groceries = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                string item = commandArgs[1];

                switch (action)
                {
                    case "Urgent":
                        Urgent(item);

                        break;
                    case "Unnecessary":
                        Unnecessary(item);

                        break;
                    case "Correct":
                        string oldItem = commandArgs[1];
                        string newItem = commandArgs[2];
                        Correct(oldItem, newItem);

                        break;
                    case "Rearrange":
                        Rearrange(item);

                        break;
                    default:
                        break;
                }
            }


            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(", ", groceries));
        }

        private static void Rearrange(string item)
        {
            if (!groceries.Contains(item))
            {
                return;
            }

            groceries.Remove(item);
            groceries.Add(item);
        }

        private static void Correct(string oldItem, string newItem)
        {
            if (!groceries.Contains(oldItem))
            {
                return;
            }

            int index = groceries.IndexOf(oldItem);
            groceries[index] = newItem;
        }

        private static void Unnecessary(string item)
        {
            groceries.Remove(item);
        }

        private static void Urgent(string item)
        {
            if (groceries.Contains(item))
            {
                return;
            }

            groceries.Insert(0, item);
        }
    }
}
