using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double averageGrades = 0;
            byte counter = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Finish")
            {
                counter++;
                string presentation = input;
                double grades = 0;
                for (int i = 0; i < n; i++)
                {
                    grades += double.Parse(Console.ReadLine());
                }
                grades /= n;
                averageGrades += grades;
                Console.WriteLine($"{presentation} - {grades:f2}.");
            }
            averageGrades /= counter;
            Console.WriteLine($"Student's final assessment is {averageGrades:f2}.");
        }
    }
}

