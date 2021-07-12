using System;

namespace Person
{
    public class Child : Person
    {
        private const int minAge = 0;
        private const int maxAge = 15;

        public Child(string name, int age) : base(name, age)
        {
          
        }

        private void ValidAge(int age)
        {
            if (age >= minAge && age <= maxAge)
            {
                return;
            }

            throw new ArgumentException("Child's age is invalid!");
        }
    }
}
