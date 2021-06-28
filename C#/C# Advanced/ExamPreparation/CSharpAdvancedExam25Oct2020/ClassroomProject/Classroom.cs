using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity, params Student[] students)
        {
            this.Capacity = capacity;
            this.students = new List<Student>(students);
        }

        public int Capacity { get; private set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Count >= this.Capacity)
            {
                return "No seats in the classroom";
            }

            this.students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students
                .FirstOrDefault(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName));

            if (student == null)
            {
                return "Student not found";
            }

            this.students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            IEnumerable<Student> collection = this.students.Where(s => s.Subject.Equals(subject));

            if (collection.Count() == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in collection)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.FirstOrDefault(s => s.FirstName.Equals(firstName) && s.LastName.Equals(lastName));
        }
    }
}
