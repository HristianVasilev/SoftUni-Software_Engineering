namespace WarCroft.Entities.Characters.Models
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory.Models;

    public class Warrior : Character, IAttacker
    {
        private const double defaultBaseHealth = 100;
        private const double defaultBaseArmor = 50;
        private const double defaultAbilityPoints = 40;

        public Warrior(string name)
            : base(name, defaultBaseHealth, defaultBaseArmor, defaultAbilityPoints, new Satchel()) { }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            if (this.Equals(character))
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
