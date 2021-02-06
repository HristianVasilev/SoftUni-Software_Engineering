using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfBadGrades = int.Parse(Console.ReadLine());
            int badGrade = 0;
            string task = string.Empty;
            int countOfTasks = 0;
            int sum = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Enough")
            {
                task = input;
                int grade = int.Parse(Console.ReadLine());
                countOfTasks++;
                sum += grade;

                if (grade <= 4)
                {
                    badGrade++;
                }
                if (badGrade == countOfBadGrades)
                {
                    Console.WriteLine($"You need a break, {badGrade} poor grades.");
                    return;
                }
            }
            Console.WriteLine($"Average score: {(sum * 1.0 / countOfTasks):f2}");
            Console.WriteLine($"Number of problems: {countOfTasks}");
            Console.WriteLine($"Last problem: {task}");
        }
    }
}
