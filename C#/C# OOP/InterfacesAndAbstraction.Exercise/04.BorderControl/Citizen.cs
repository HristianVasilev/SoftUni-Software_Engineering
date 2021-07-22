namespace _04.BorderControl
{
    class Citizen : IObject
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
    }
}
