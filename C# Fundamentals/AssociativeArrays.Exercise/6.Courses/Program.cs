using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Courses
{
    class Program
    {
        private static Dictionary<string, List<string>> coursesData;

        static void Main(string[] args)
        {
            coursesData = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] commandArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = commandArgs[0];
                string studentName = commandArgs[1];

                AddStudent(courseName, studentName);
            }

            PrintCourseData();
        }

        private static void PrintCourseData()
        {
            var coursesCollection = coursesData.OrderByDescending(x => x.Value.Count).ToDictionary(k => k.Key, v => v.Value);
            ;
            foreach (KeyValuePair<string, List<string>> course in coursesCollection)
            {
                string courseName = course.Key;
                int countOfStudents = course.Value.Count;
                Console.WriteLine($"{courseName}: {countOfStudents}");

                IOrderedEnumerable<string> students = course.Value.OrderBy(n => n);
                foreach (var student in students)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }

        private static void AddStudent(string courseName, string studentName)
        {
            if (!coursesData.ContainsKey(courseName))
            {
                coursesData.Add(courseName, new List<string>());
            }

            coursesData[courseName].Add(studentName);
        }
    }
}
