namespace _03.Raiding.Models
{
    class Rogue : BaseHero
    {
        private const int power = 80;

        public Rogue(string name) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{base.CastAbility()} hit for {this.Power} damage";
        }
    }
}
