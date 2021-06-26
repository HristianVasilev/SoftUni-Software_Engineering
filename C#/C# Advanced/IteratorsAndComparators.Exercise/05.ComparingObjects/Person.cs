using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _05.ComparingObjects
{
    class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Town { get; private set; }

        public int CompareTo([AllowNull] Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age);

                if (result == 0)
                {
                    result = this.Town.CompareTo(other.Town);
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Person person = obj as Person;

            if (person == null)
            {
                throw new InvalidCastException("The object is different than Person type!");
            }

            if (CompareTo(person) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
