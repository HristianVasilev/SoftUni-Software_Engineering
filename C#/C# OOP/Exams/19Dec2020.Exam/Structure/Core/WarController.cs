namespace WarCroft.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarCroft.Entities.Characters.Contracts;
    using WarCroft.Entities.Characters.Models;
    using WarCroft.Entities.Items;

    public class WarController
    {
        private ICollection<Character> characterParty;
        private IList<Item> pool;

        public WarController()
        {
            this.characterParty = new List<Character>();
            this.pool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = CreateCharacter(characterType, name);

            this.characterParty.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = CreateItem(itemName);

            this.pool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characterParty.FirstOrDefault(x => x.Name.Equals(characterName));

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item lastItem = this.pool.Last();
            // this.pool.RemoveAt(this.pool.Count - 1);
            character.Bag.AddItem(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characterParty.FirstOrDefault(x => x.Name.Equals(characterName));

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.Items.FirstOrDefault(x => x.GetType().Name.Equals(itemName));
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            var characters = this.characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(h => h.Health);

            StringBuilder sb = new StringBuilder();

            foreach (var character in characters)
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characterParty.FirstOrDefault(n => n.Name.Equals(attackerName));
            Character receiver = this.characterParty.FirstOrDefault(n => n.Name.Equals(receiverName));

            EnsureExists(attackerName, attacker);
            EnsureExists(receiverName, receiver);

            IAttacker attacker1 = attacker as IAttacker;

            if (attacker1 == null)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker1.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characterParty.FirstOrDefault(c => c.Name.Equals(healerName));
            Character receiver = this.characterParty.FirstOrDefault(c => c.Name.Equals(healingReceiverName));

            EnsureExists(healerName, healer);
            EnsureExists(healingReceiverName, receiver);

            IHealer iHealer = healer as IHealer;

            if (iHealer == null)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }



        private static Character CreateCharacter(string characterType, string name)
        {
            Character character;
            switch (characterType)
            {
                case nameof(Priest):
                    character = new Priest(name);
                    break;
                case nameof(Warrior):
                    character = new Warrior(name);
                    break;

                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            return character;
        }
        private static Item CreateItem(string itemName)
        {
            Item item;
            switch (itemName)
            {
                case nameof(FirePotion):
                    item = new FirePotion();
                    break;
                case nameof(HealthPotion):
                    item = new HealthPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return item;
        }
        private static void EnsureExists(string characterName, Character character)
        {
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }
    }
}
