using _09.ExplicitInterfaces.Models.Classes;
using _09.ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, age, country);
                citizens.Add(citizen);
            }

            foreach (var citizen in citizens)
            {
                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }

        }
    }
}
