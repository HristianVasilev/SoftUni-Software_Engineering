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

            int countOfPeople = int.Parse(Console.ReadLine());
            int efficiencyPerHour = employeesEfficiency.Sum(x => x);

            int time = 0;

            while (countOfPeople > 0)
            {
                time++;
                countOfPeople -= efficiencyPerHour;

                if (time % 4 == 0)
                {
                    time++;
                }
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
