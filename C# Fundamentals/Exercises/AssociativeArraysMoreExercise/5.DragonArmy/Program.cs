using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var (type, dragons) in db)
            {
                double avgDamage = dragons.Average(x => x.Damage);
                double avgHealth = dragons.Average(x => x.Health);
                double avgArmor = dragons.Average(x => x.Armor);

                sb.AppendLine($"{type}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                dragons
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(d => sb.AppendLine(d.ToString()));
            }

            return sb.ToString().TrimEnd();
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
            else
            {
                exist.Change(damage, health, armor);
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

        public string Type { get; }
        public string Name { get; }
        public int Damage { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }

        internal void Change(int damage, int health, int armor)
        {
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public override string ToString()
        {
            return $"-{this.Name} -> damage: {this.Damage}, health: {this.Health}, armor: {this.Armor}";
        }
    }
}
