﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] studentArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentArgs[0];
                string lastName = studentArgs[1];
                int age = int.Parse(studentArgs[2]);
                string homeTown = studentArgs[3];

                Student current = new Student(firstName, lastName, age, homeTown);

                if (ExistingStudent(ref students, current))
                {
                    int index = students.IndexOf(current);
                    students[index] = current;
                    continue;
                }

                students.Add(current);
            }

            string town = Console.ReadLine();

            List<Student> filteredStudents = students.Where(x => x.HomeTown.Equals(town)).ToList();

            PrintResult(filteredStudents);
        }

        private static bool ExistingStudent(ref List<Student> students, Student current)
        {
            return students.Any(s => s.Equals(current));
        }

        private static void PrintResult(List<Student> filteredStudents)
        {
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string HomeTown { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            Student student = (Student)obj;

            return this.FirstName == student.FirstName && this.LastName == student.LastName;
        }


    }

}
