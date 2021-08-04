namespace _02.LegionSystem.Models
{
    using System;
    using _02.LegionSystem.Interfaces;

    public class Enemy : IEnemy
    {
        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(object obj)
        {
            IEnemy other = (IEnemy)obj;

            if (this.AttackSpeed > other.AttackSpeed)
            {
                return 1;
            }
            else if (this.AttackSpeed < other.AttackSpeed)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
