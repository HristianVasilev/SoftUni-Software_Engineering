using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> integers = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)));

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                Queue<string> commandArgs = new Queue<string>(command.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string action = commandArgs.Dequeue().ToLower();

                switch (action)
                {
                    case "add":
                        Add(commandArgs.Select(int.Parse), ref integers);
                        break;
                    case "remove":
                        Remove(int.Parse(commandArgs.LastOrDefault()), ref integers);
                        break;
                    default:
                        break;
                }
            }

            int countOfIntegers = integers.Sum();
            Console.WriteLine($"Sum: {countOfIntegers}");
        }

        private static void Remove(int count, ref Stack<int> integers)
        {
            if (integers.Count < count)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                integers.Pop();
            }
        }

        private static void Add(IEnumerable<int> numbers, ref Stack<int> integers)
        {
            foreach (var num in numbers)
            {
                integers.Push(num);
            }
        }
    }
}
