using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                GradeQuery(name, grade, ref students);
            }

            string result = GetResult(students);
            Console.WriteLine(result);
        }

        private static string GetResult(Dictionary<string, List<decimal>> students)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var student in students)
            {
                sb.AppendLine($"{student.Key} -> {string.Join(' ', student.Value.Select(x => x.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }

            return sb.ToString().TrimEnd();
        }

        private static void GradeQuery(string name, decimal grade, ref Dictionary<string, List<decimal>> students)
        {
            if (!students.ContainsKey(name))
            {
                students.Add(name, new List<decimal>());
            }

            students[name].Add(grade);
        }
    }
}
