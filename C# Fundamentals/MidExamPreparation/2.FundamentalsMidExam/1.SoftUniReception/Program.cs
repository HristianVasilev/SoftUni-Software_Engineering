using System;
using System.Linq;

namespace _1.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int efficiencyPerHour = 0;

            for (int i = 0; i < 3; i++)
            {
                efficiencyPerHour += int.Parse(Console.ReadLine());
            }

            int studentsCount = int.Parse(Console.ReadLine());

            int time = 0;

            while (studentsCount > 0)
            {
                studentsCount -= efficiencyPerHour;
                time++;

                if (time % 4 == 0 && time != 0)
                {
                    time++;
                }
            }

            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
