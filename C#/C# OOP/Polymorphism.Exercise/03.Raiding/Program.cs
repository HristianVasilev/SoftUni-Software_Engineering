using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _03.Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            StringBuilder sb = new StringBuilder();

            while (heroes.Count != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                BaseHero hero;
                try
                {
                    hero = CreateHero(heroName, heroType);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                heroesPower += hero.Power;
                sb.AppendLine(hero.CastAbility());
                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            string castResult = sb.ToString().TrimEnd();
            Console.WriteLine(castResult);

            string battleResult = GetBattleResult(bossPower, heroesPower);
            Console.WriteLine(battleResult);
        }

        private static string GetCastResult(ICollection<BaseHero> heroes)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes)
            {
                sb.AppendLine(hero.CastAbility());
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetBattleResult(int bossPower, int heroesPower)
        {
            string result;
            if (heroesPower >= bossPower)
            {
                result = "Victory!";
            }
            else
            {
                result = "Defeat...";
            }

            return result;
        }

        private static BaseHero CreateHero(string heroName, string heroType)
        {
            // *** Using Reflection!
            //
            IEnumerable<Type> alltypes = Assembly
                .GetAssembly(typeof(BaseHero))
                .GetTypes()
                .Where(c => c.IsClass && c.IsSubclassOf(typeof(BaseHero)));

            Type type = alltypes.FirstOrDefault(x => x.Name.Equals(heroType));

            if (type == null)
            {
                throw new InvalidOperationException("Invalid hero!");
            }

            ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
            BaseHero hero = (BaseHero)constructorInfo.Invoke(new object[] { heroName });

            // *** Using basic approach

            //BaseHero hero;

            //switch (heroType)
            //{
            //    case nameof(Druid):
            //        hero = new Druid(heroName);
            //        break;
            //    case nameof(Paladin):
            //        hero = new Paladin(heroName);
            //        break;
            //    case nameof(Rogue):
            //        hero = new Rogue(heroName);
            //        break;
            //    case nameof(Warrior):
            //        hero = new Warrior(heroName);
            //        break;

            //    default:
            //        throw new InvalidOperationException("Invalid hero!");
            //}

            return hero;
        }
    }
}
