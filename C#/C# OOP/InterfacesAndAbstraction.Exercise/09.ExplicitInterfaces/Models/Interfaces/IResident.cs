namespace _09.ExplicitInterfaces.Models.Interfaces
{
    interface IResident
    {
        public string Name { get; }
        public string Country { get; }
        string GetName();
    }
}
