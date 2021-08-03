using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public abstract class BaseHero
    {
        private string name;
        private int power;

        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name}";
        }
    }
}
