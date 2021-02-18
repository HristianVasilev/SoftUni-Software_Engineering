using System;
using System.Linq;

namespace _1.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] employeesEfficiency = new int[3];

            for (int i = 0; i < employeesEfficiency.Length; i++)
            {
                employeesEfficiency[i] = int.Parse(Console.ReadLine());
            }

            int countOfPeople = int.Parse(Console.ReadLine());

            int totalEfficiencyPerHour = employeesEfficiency.Sum();

            double timeNeeded = countOfPeople / (1.0 * totalEfficiencyPerHour);

            double restHours = timeNeeded / 4.0;

            timeNeeded += restHours;

            Console.WriteLine($"Time needed: {Math.Ceiling(timeNeeded)}h.");
        }
    }
}
