using System;
using System.Linq;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] employeesEfficiency = new byte[3];

            for (int i = 0; i < employeesEfficiency.Length; i++)
            {
                employeesEfficiency[i] = byte.Parse(Console.ReadLine());
            }

            short countOfPeople = short.Parse(Console.ReadLine());

            short totalEfficiencyPerHour = (short)(employeesEfficiency.Sum(x => x));

            double timeNeeded = countOfPeople / (1.0 * totalEfficiencyPerHour);

            short restHours = (short)(timeNeeded / 3);

            timeNeeded += restHours;

            Console.WriteLine($"Time needed: {Math.Ceiling(timeNeeded)}h.");
        }
    }
}
