using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        private const string produceSound = "DJAAF";


        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ExplainSelf());
            sb.AppendLine(produceSound);

            return sb.ToString().TrimEnd();
        }
    }
}
