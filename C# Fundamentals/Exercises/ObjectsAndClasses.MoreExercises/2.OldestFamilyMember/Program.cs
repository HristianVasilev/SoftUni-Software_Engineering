using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }

    class Family
    {
        private readonly List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People => this.people;

        internal void AddMember(Person member)
        {
            this.people.Add(member);
        }

        internal Person GetOldestMember()
        {
            return this.People.OrderByDescending(p => p.Age).First();
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }
        public int Age { get; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
