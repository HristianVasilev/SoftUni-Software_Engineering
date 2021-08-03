namespace _03.Raiding.Models
{
    internal class Druid : BaseHero
    {
        private const int power = 80;

        public Druid(string name) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} healed for {this.Power}";
        }
    }
}
