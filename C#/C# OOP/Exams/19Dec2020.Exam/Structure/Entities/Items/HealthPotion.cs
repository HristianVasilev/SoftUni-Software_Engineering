namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class HealthPotion : Item
    {
        private const int baseWeight = 5;


        public HealthPotion() : base(baseWeight) { }
        public HealthPotion(int weight) : base(weight) { }


        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += 20;
        }
    }
}
