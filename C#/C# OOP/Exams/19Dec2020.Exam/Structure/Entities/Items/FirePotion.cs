namespace WarCroft.Entities.Items
{
    using WarCroft.Entities.Characters.Contracts;

    public class FirePotion : Item
    {
        private const int baseWeight = 5;

        public FirePotion() : base(baseWeight) { }
        public FirePotion(int weight) : base(weight) { }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
