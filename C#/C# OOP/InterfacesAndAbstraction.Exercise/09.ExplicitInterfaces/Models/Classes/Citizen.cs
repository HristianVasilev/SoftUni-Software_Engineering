﻿using _09.ExplicitInterfaces.Models.Interfaces;

namespace _09.ExplicitInterfaces.Models.Classes
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }


        public string Name { get; }
        public int Age { get; }
        public string Country { get; }


        string IPerson.GetName()
        {
            return Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }


    }
}
