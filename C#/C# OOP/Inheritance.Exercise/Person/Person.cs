using System;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be a negative number!");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
