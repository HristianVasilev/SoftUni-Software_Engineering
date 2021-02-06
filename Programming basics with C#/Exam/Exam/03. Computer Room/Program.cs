using System;

namespace _03._Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();

            double day = 0;
            double night = 0;
            double price = 0;

            switch (month)
            {
                case "march":
                case "april":
                case "may":

                    day = 10.50;
                    night = 8.40;

                    break;
                case "june":
                case "july":
                case "august":

                    day = 12.60;
                    night = 10.20;

                    break;
            }

            if (type == "day")
            {
                price = day;
            }
            else if (type == "night")
            {
                price = night;
            }

            if (people >= 4)
            {
                price *= 0.90;
            }

            if (hours >= 5)
            {
                price *= 0.50;
            }

            Console.WriteLine($"Price per person for one hour: {price:f2}");
            Console.WriteLine($"Total cost of the visit: {(people * hours * price):f2}");
        }
    }
}
