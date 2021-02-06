using System;
using System.Collections.Generic;

namespace _08.CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> ticket = new Dictionary<string, double>()
            {
                { "Monday",12 },
                { "Tuesday", 12 },
                { "Wednesday",14 },
                { "Thursday",14 },
                { "Friday",12 },
                { "Saturday",16 },
                { "Sunday", 16 }
            };

            string day = Console.ReadLine();

            if (ticket.ContainsKey(day))
            {
                Console.WriteLine(ticket[day]);
            }
        }
    }
}
