using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

            byte n = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddHero(tokens, ref heroes);
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "CastSpell":
                        CastSpell(tokens, ref heroes);
                        break;
                    case "TakeDamage":
                        TakeDamage(tokens, ref heroes);
                        break;
                    case "Recharge":
                        Recharge(tokens, ref heroes);
                        break;
                    case "Heal":
                        Heal(tokens, ref heroes);
                        break;

                    default:
                        throw new NotImplementedException("Invalid command!");
                }
            }

            PrintAll(ref heroes);
        }

        private static void PrintAll(ref Dictionary<string, Hero> heroes)
        {
            var collection = heroes
                .OrderByDescending(x => x.Value.HP)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var hero in collection)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }

        private static void Heal(string[] tokens, ref Dictionary<string, Hero> heroes)
        {
            string heroName = tokens[1];
            int amount = int.Parse(tokens[2]);

            int oldHP = heroes[heroName].HP;
            heroes[heroName].HP += amount;
            int newHP = heroes[heroName].HP;

            Console.WriteLine($"{heroName} healed for {newHP - oldHP} HP!");
        }

        private static void Recharge(string[] tokens, ref Dictionary<string, Hero> heroes)
        {
            string heroName = tokens[1];
            int amount = int.Parse(tokens[2]);

            int oldMP = heroes[heroName].MP;
            heroes[heroName].MP += amount;
            int newMP = heroes[heroName].MP;

            Console.WriteLine($"{heroName} recharged for {newMP - oldMP} MP!");
        }

        private static void TakeDamage(string[] tokens, ref Dictionary<string, Hero> heroes)
        {
            string heroName = tokens[1];
            int damage = int.Parse(tokens[2]);
            string attacker = tokens[3];

            if (heroes[heroName].HP - damage > 0)
            {
                heroes[heroName].HP -= damage;

                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
            }
            else
            {
                heroes.Remove(heroName);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        private static void CastSpell(string[] tokens, ref Dictionary<string, Hero> heroes)
        {
            string heroName = tokens[1];
            int mpNeeded = int.Parse(tokens[2]);
            string spellName = tokens[3];

            if (heroes[heroName].MP >= mpNeeded)
            {
                heroes[heroName].MP -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        private static void AddHero(string[] tokens, ref Dictionary<string, Hero> heroes)
        {
            string heroName = tokens[0];
            int HP = int.Parse(tokens[1]);
            int MP = int.Parse(tokens[2]);

            if (!heroes.ContainsKey(heroName))
            {
                heroes.Add(heroName, new Hero(0, 0));
            }

            heroes[heroName].HP += HP;
            heroes[heroName].MP += MP;
        }
    }

    class Hero
    {
        private int hp;
        private int mp;

        public Hero(byte hp, byte mp)
        {
            this.HP = hp;
            this.MP = mp;
        }

        public int HP
        {
            get => this.hp;
            set
            {
                if (value > 100)
                {
                    this.hp = 100;
                }
                else
                {
                    this.hp = value;
                }
            }
        }
        public int MP
        {
            get => this.mp;
            set
            {
                if (value > 200)
                {
                    this.mp = 200;
                }
                else
                {
                    this.mp = value;
                }
            }
        }
    }
}
