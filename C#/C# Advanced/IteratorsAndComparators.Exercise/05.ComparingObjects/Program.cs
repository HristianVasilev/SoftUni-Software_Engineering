using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = ReadPeople();

            int index = int.Parse(Console.ReadLine());

            string result = GetResult(people, index);
            Console.WriteLine(result);
        }

        private static string GetResult(Person[] people, int index)
        {
            Person matchPerson = people[index - 1];

            int countOfMatches = 0;
            int countOfNonMatches = 0;

            foreach (var person in people)
            {
                if (person.Equals(matchPerson))
                {
                    countOfMatches++;
                }
                else
                {
                    countOfNonMatches++;
                }
            }

            if (countOfMatches - 1 == 0)
            {
                return "No matches";
            }

            int totalPeople = people.Length;

            return $"{countOfMatches} {countOfNonMatches} {totalPeople}";
        }

        private static Person[] ReadPeople()
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            return people.ToArray();
        }
    }
}
