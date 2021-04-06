using System;
using System.Linq;

namespace _3.HeartDelivery
{
    class Program
    {
        private static int[] houses;

        static void Main(string[] args)
        {
            houses = Console.ReadLine().Split('@', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int houseIndex = 0;
            int counter = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Love!")
            {
                counter++;

                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string jump = commandArgs[0];
                int length = int.Parse(commandArgs[1]);

                houseIndex += length;

                if (!ValidIndex(houseIndex))
                {
                    houseIndex = 0;
                }

                if (houses[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} already had Valentine's day.");
                    continue;
                }

                houses[houseIndex] -= 2;

                if (houses[houseIndex] == 0)
                {
                    Console.WriteLine($"Place {houseIndex} has Valentine's day.");
                }
            }

            PrintResult(houseIndex);
        }

        private static void PrintResult(int houseIndex)
        {
            Console.WriteLine($"Cupid's last position was {houseIndex}.");

            int placesHadValentinesDay = houses.Count(x => x == 0);

            if (placesHadValentinesDay == houses.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int failedPlaces = houses.Length - placesHadValentinesDay;
                Console.WriteLine($"Cupid has failed {failedPlaces} places.");
            }
        }

        private static bool ValidIndex(int houseIndex)
        {
            return houseIndex >= 0 && houseIndex < houses.Length;
        }
    }
}
