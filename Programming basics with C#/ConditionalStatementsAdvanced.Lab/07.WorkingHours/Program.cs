using System;

namespace _07.WorkingHours
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if (!(hour >= 0 && hour <= 24))
            {
                throw new ArgumentException("Invalid hour!");
            }

            bool open = false;

            if (hour >= 10 && hour <= 18)
            {
                open = true;
            }

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":

                    if (open)
                    {
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }

                    break;
                case "Sunday":

                    Console.WriteLine("closed");

                    break;
                default:
                    throw new ArgumentException("Invalid day!");
            }
        }
    }
}
