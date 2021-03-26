using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            int countOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfStudents; i++)
            {
                string[] studentArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentArgs[0];
                string lastName = studentArgs[1];
                double grade = double.Parse(studentArgs[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            string allStudents = GetStudents(ref students);
            Console.WriteLine(allStudents);
        }

        private static string GetStudents(ref List<Student> students)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var student in students)
            {
                sb.AppendLine(student.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Grade { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
        }
    }
}
