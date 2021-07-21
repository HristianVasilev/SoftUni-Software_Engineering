namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                age = value;
            }
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}
