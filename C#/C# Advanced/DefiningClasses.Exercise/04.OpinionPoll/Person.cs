namespace DefiningClasses
{
    public class Person
    {
        private string name = "No name";
        private int age = 1;

        public Person()
        {

        }

        public Person(int age) : this()
        {
            this.Age = age;
        }

        public Person(string name, int age) : this(age)
        {
            this.Name = name;
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

        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
