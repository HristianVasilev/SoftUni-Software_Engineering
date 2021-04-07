using System;
using System.Collections.Generic;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            Dictionary<byte, string> days = new Dictionary<byte, string>();

            days.Add(1, "Monday");
            days.Add(2, "Tuesday");
            days.Add(3, "Wednesday");
            days.Add(4, "Thursday");
            days.Add(5, "Friday");
            days.Add(6, "Saturday");
            days.Add(7, "Sunday");

            if (days.ContainsKey(n))
            {
                Console.WriteLine(days[n]);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
