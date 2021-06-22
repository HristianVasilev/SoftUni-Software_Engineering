using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            Person[] peopleOlderThan30years = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToArray();

            foreach (var person in peopleOlderThan30years)
            {
                Console.WriteLine(person);
            }
        }
    }
}
