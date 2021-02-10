using System;

namespace _1.DaysOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekDays =
                {
                    "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
                };
            int day = int.Parse(Console.ReadLine());
            if (1 > day || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(weekDays[day - 1]);
            }
        }
    }
}
