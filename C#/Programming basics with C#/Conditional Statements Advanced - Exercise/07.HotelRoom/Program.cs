using System;

namespace _07.HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double apartment = 0.00;
            double studio = 0.00;

            switch (month)
            {
                case "May":
                case "October":

                    studio = 50;
                    apartment = 65;

                    break;

                case "June":
                case "September":

                    studio = 75.20;
                    apartment = 68.70;

                    break;

                case "July":
                case "August":

                    studio = 76;
                    apartment = 77;

                    break;
                default:
                    Console.WriteLine("Not working");
                    break;
            }

            if ((count > 7 && count <= 14) && (month == "May" || month == "October"))
            {
                studio *= 0.95;
            }
            else if (count > 14 && (month == "May" || month == "October"))
            {
                studio *= 0.70;
            }
            else if (count > 14 && (month == "June" || month == "September"))
            {
                studio *= 0.80;
            }

            if (count > 14)
            {
                apartment *= 0.90;
            }

            Console.WriteLine($"Apartment: {(apartment*count):F2} lv.");
            Console.WriteLine($"Studio: {(studio*count):F2} lv.");
        }
    }
}
