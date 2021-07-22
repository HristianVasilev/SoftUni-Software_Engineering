using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models.Classes
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
