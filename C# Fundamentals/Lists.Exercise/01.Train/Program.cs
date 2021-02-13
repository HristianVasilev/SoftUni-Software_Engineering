using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int passengers;

                if (tokens.Length > 1 && tokens[0] == "Add")
                {
                    passengers = int.Parse(tokens[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    passengers = int.Parse(tokens[0]);

                    FitPassengers(wagons, maxCapacityOfWagon, passengers);
                }
            }

            Console.WriteLine(string.Join(' ', wagons));
        }

        private static void FitPassengers(List<int> wagons, int maxCapacityOfWagon, int passengers)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passengers <= maxCapacityOfWagon)
                {
                    wagons[i] += passengers;
                    return;
                }
            }
        }
    }
}
