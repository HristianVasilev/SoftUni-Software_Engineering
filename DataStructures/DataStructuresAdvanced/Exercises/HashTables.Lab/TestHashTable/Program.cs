namespace TestHashTable
{
    using HashTable;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> hashTable = new HashTable<string, int>();
            List<string> keys = new List<string>();
            int count = 5000;
            for (int i = 0; i < count; i++)
            {
                string key = Guid.NewGuid().ToString();
                keys.Add(key);
                hashTable.Add(key, i);
            }

            Console.WriteLine($"Keys count: {hashTable.Keys.Count()}");
            //foreach (var item in x)
            //{
            //    if (item == 0) Console.WriteLine("Empty");
            //}

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
