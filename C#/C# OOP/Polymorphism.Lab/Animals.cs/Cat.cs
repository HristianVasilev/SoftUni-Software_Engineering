using System.Text;

namespace Animals
{
    class Cat : Animal
    {
        private const string produceSound = "MEEOW";

        public Cat(string name, string favouriteFood) : base(name, favouriteFood)
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
