using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            string output = GetGrade(grade);
            Console.WriteLine(output);
        }

        private static string GetGrade(double grade)
        {
            string message = string.Empty;
            grade = Math.Round(grade, 2);

            if (grade >= 2.0 && grade < 3)
            {
                message = "Fail";
            }
            else if (grade >= 3.0 && grade < 3.50)
            {
                message = "Poor";
            }
            else if (grade >= 3.50 && grade < 4.5)
            {
                message = "Good";
            }
            else if (grade >= 4.50 && grade <5.50)
            {
                message = "Very good";
            }
            else if (grade >= 5.50 && grade < 6.0)
            {
                message = "Excellent";
            }

            return message;
        }
    }
}
