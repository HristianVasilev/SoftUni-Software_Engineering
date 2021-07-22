using _05.BirthdayCelebrations.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models.Classes
{
    class Robot : IObject
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }

        public string Id { get; }
    }
}
