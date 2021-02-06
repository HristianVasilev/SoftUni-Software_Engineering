using System;

namespace _08.ScholarShip
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double scholarShip = 0;
            double socialScholarShip = 0;
            double excellentScholarShip = 0;


            if (income < minSalary && averageGrade > 4.5)
            {
                socialScholarShip = minSalary * 0.35;
            }

            if (averageGrade >= 5.5)
            {
                excellentScholarShip = averageGrade * 25;
            }

            scholarShip = Math.Max(socialScholarShip, excellentScholarShip);

            if (scholarShip == 0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (scholarShip == socialScholarShip && socialScholarShip > excellentScholarShip)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarShip)} BGN");
            }
            else if (scholarShip == excellentScholarShip)
            {
                Console.WriteLine($"You get a scholarship for excellent results {(int)scholarShip} BGN");
            }
        }
    }
}
