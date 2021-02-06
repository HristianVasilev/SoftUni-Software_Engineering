using System;

namespace _05.Time_15seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;
            if (minutes >= 60)
            {
                hour++;
                if (hour >= 24)
                {
                    hour = 0;
                }
                minutes = minutes % 60;
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
