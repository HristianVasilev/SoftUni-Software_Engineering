
namespace _04.BorderControl
{
    class Robot : IObject
    {
        public Robot(string model, string id)
        {
            Name = model;
            Id = id;
        }

        public string Name { get; }

        public string Id { get; }
    }
}
