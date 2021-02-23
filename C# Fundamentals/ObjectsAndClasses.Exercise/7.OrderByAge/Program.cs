using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personArgs[0];
                int ID = int.Parse(personArgs[1]);
                int age = int.Parse(personArgs[2]);

                Person person = new Person(name, ID, age);
                people.Add(person);
            }

            string allPeople = GetAllPeopleOrderByAge(ref people);
            Console.WriteLine(allPeople);
        }

        private static string GetAllPeopleOrderByAge(ref List<Person> people)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in people.OrderBy(x => x.Age))
            {
                sb.AppendLine(person.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }

    class Person
    {
        public Person(string name, int ID, int age)
        {
            this.Name = name;
            this.ID = ID;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int ID { get; private set; }
        public int Age { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
        }
    }
}
