using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Person
    {
        private string name;
        private int age;

        public Person()
        {

        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            set { name = value; }
        }

        public int Age
        {
            get => this.age;
            set { age = value; }
        }
    }
}
