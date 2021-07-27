namespace _09.ExplicitInterfaces.Models.Interfaces
{
    interface IPerson
    {
        public string Name { get; }
        public int Age { get; }

        string GetName();
    }
}
