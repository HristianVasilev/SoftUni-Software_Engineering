using ValidationAttributes.Models.Attributes;

namespace ValidationAttributes.Models
{
    class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(1, 100)]
        public int Age { get; private set; }

    }
}
