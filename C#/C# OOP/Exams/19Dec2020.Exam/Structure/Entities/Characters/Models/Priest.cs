namespace WarCroft.Entities.Characters.Models
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Inventory.Models;

    public class Priest : Character, IHealer
    {
        private const double defaultBaseHealth = 100;
        private const double defaultBaseArmor = 50;
        private const double defaultAbilityPoints = 40;

        public Priest(string name)
            : base(name, defaultBaseHealth, defaultBaseArmor, defaultAbilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            character.Health += this.AbilityPoints;
        }
    }
}
