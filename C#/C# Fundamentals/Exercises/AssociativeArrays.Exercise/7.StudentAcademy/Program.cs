using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StudentAcademy
{
    class Program
    {
        private static Dictionary<string, List<double>> studentAcademy;

        static void Main(string[] args)
        {
            studentAcademy = new Dictionary<string, List<double>>();

            int countOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                AddResult(studentName, grade);
            }

            PrintStudents();
        }

        private static void PrintStudents()
        {
            Dictionary<string, List<double>> filteredAdacemy = studentAcademy
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var student in filteredAdacemy)
            {
                string studentName = student.Key;
                double averageGrade = student.Value.Average();

                Console.WriteLine($"{studentName} -> {averageGrade:f2}");
            }
        }

        private static void AddResult(string studentName, double grade)
        {
            if (!studentAcademy.ContainsKey(studentName))
            {
                studentAcademy.Add(studentName, new List<double>());
            }

            studentAcademy[studentName].Add(grade);
        }
    }
}
