namespace TestHashTable
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student(4);
            Student b = new Student(3);
            Student c = new Student(3);

            IEqualityComparer<Student> comparer = new StudentComparer();
            HashSet<Student> students = new HashSet<Student>(comparer);


            students.Add(a);
            students.Add(b);
            students.Add(c);

            Console.WriteLine(students.Count);

        }
    }

    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals([AllowNull] Student x, [AllowNull] Student y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Student obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    class Student
    {
        public Student(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }


    }
}
