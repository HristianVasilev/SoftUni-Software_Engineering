namespace WarCroft.Entities.Characters.Contracts
{
    using System;
    using WarCroft.Constants;
    using WarCroft.Entities.Inventory.Models;
    using WarCroft.Entities.Items;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;

            this.BaseHealth = health;
            this.Health = this.BaseHealth;

            this.BaseArmor = armor;
            this.Armor = this.BaseArmor;

            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public virtual double BaseHealth { get; protected set; }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > BaseHealth)
                {
                    value = BaseHealth;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                health = value;
            }
        }

        public double BaseArmor { get; protected set; }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public bool IsAlive { get; set; } = true;


        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double availableHitPoints = hitPoints - this.Armor;
            this.Armor -= hitPoints;

            if (availableHitPoints > 0)
            {
                this.Health -= availableHitPoints;
            }

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }


        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {this.IsAlive}";
        }
    }
}