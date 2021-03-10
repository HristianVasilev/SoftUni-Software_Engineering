using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.DragonArmy
{
    class Program
    {
        private static Dictionary<string, List<Dragon>> db;

        static void Main(string[] args)
        {
            db = new Dictionary<string, List<Dragon>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];
                string name = tokens[1];
                int damage = ParseOrDefault(tokens[2], 45);
                int health = ParseOrDefault(tokens[3], 250);
                int armor = ParseOrDefault(tokens[4], 10);

                AddToDB(type, name, damage, health, armor);
            }

        }

        private static void AddToDB(string type, string name, int damage, int health, int armor)
        {
            if (!db.ContainsKey(type))
            {
                db.Add(type, new List<Dragon>());
            }

            Dragon exist = db[type].FirstOrDefault(x => x.Type == type && x.Name == name);

            if (exist is null)
            {
                db[type].Add(new Dragon(type, name, damage, health, armor));
            }
            
        }



        private static int ParseOrDefault(string value, int defaultValue)
        {
            int damage;
            if (int.TryParse(value, out damage))
            {
                damage = int.Parse(value);
            }
            else
            {
                damage = defaultValue;
            }

            return damage;
        }
    }

    internal class Dragon
    {
        public Dragon(string type, string name, int damage, int health, int armor)
        {
            this.Type = type;
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
