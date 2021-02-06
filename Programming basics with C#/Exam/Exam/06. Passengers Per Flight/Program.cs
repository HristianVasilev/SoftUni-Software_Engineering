using System;

namespace _06._Passengers_Per_Flight
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCompanies = int.Parse(Console.ReadLine());
            int maxAveragePassengers = int.MinValue;
            string company = string.Empty;

            for (int i = 0; i < countOfCompanies; i++)
            {
                string companyName = Console.ReadLine();

                string input = string.Empty;
                byte counter = 0;
                int passengers = 0;
                while ((input = Console.ReadLine()) != "Finish")
                {
                    passengers += int.Parse(input);
                    counter++;
                }
                int averagePassengers = passengers / counter;

                if (averagePassengers > maxAveragePassengers)
                {
                    maxAveragePassengers = averagePassengers;
                    company = companyName;
                }
                Console.WriteLine($"{companyName}: {averagePassengers} passengers.");
            }

            Console.WriteLine($"{company} has most passengers per flight: {maxAveragePassengers}");
        }
    }
}
