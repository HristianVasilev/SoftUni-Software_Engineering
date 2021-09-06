namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _02.LegionSystem.Interfaces;
    using _02.LegionSystem.Models;

    public class Legion : IArmy
    {
        private PriorityQueue<IEnemy> priorityQueue;
        private Dictionary<int, IEnemy> dict;

        public Legion()
        {
            priorityQueue = new PriorityQueue<IEnemy>();
            this.dict = new Dictionary<int, IEnemy>();
        }

        public int Size => this.priorityQueue.Size;

        public bool Contains(IEnemy enemy)
        {
            return this.dict.ContainsKey(enemy.AttackSpeed);
        }

        public void Create(IEnemy enemy)
        {
            if (!this.dict.ContainsKey(enemy.AttackSpeed))
            {
                this.dict.Add(enemy.AttackSpeed, enemy);
                this.priorityQueue.Add(enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            for (int i = 0; i < this.dict.Count; i++)
            {
                if (this.dict[i].AttackSpeed.Equals(speed))
                {
                    return this.dict[i];
                }
            }

            return null;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            List<IEnemy> enemies = this.dict.Where(k => k.Key > speed).Select(x => x.Value).ToList();
            return enemies;
        }

        public IEnemy GetFastest()
        {
            EnsureNotEmpty("Legion has no enemies!");

            return this.priorityQueue.Peek();
        }

        public IEnemy[] GetOrderedByHealth()
        {
            if (this.Size == 0)
            {
                return this.dict.Values.ToArray();
            }

            return this.dict.Values.OrderByDescending(x => x.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            List<IEnemy> enemies = this.dict.Where(x => x.Key < speed).Select(x => x.Value).ToList();
            return enemies;
        }

        public IEnemy GetSlowest()
        {
            EnsureNotEmpty("Legion has no enemies!");

            int[] enemiesSpeeds = this.dict.Keys.ToArray();
            int minSpeed = enemiesSpeeds.Min();

            return this.dict[minSpeed];
        }

        public void ShootFastest()
        {
            EnsureNotEmpty("Legion has no enemies!");

            IEnemy enemy = this.priorityQueue.Dequeue();
            this.dict.Remove(enemy.AttackSpeed);
        }

        public void ShootSlowest()
        {
            EnsureNotEmpty("Legion has no enemies!");

            IEnemy enemy = this.GetSlowest();

            priorityQueue.Remove(enemy);
            this.dict.Remove(enemy.AttackSpeed);
        }



        private void EnsureNotEmpty(string message)
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException(message);
            }
        }

    }
}
