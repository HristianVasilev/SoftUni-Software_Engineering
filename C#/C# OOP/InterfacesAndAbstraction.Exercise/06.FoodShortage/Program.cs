using _06.FoodShortage.Models.Classes;
using FoodShortage.Models.Classes;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IObject> collection = new List<IObject>();

            int num = int.Parse(Console.ReadLine());
            ReadBuyers(ref collection, num);

            int boughtFood = 0;
            BuyFood(ref collection, ref boughtFood);
            Console.WriteLine(boughtFood);
        }

        private static void BuyFood(ref ICollection<IObject> collection, ref int boughtFood)
        {
            string buyer;
            while ((buyer = Console.ReadLine()) != "End")
            {
                IBuyer obj = collection.FirstOrDefault(x => x.Name.Equals(buyer)) as IBuyer;

                if (obj is null)
                {
                    continue;
                }

                boughtFood += obj.BuyFood();
            }
        }

        private static void ReadBuyers(ref ICollection<IObject> collection, int num)
        {
            for (int i = 0; i < num; i++)
            {
                string[] info = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);

                IObject buyer;

                switch (info.Length)
                {
                    case 3:
                        string group = info[2];

                        buyer = new Rebel(name, age, group);
                        break;
                    case 4:
                        string id = info[2];
                        DateTime birthdate = DateTime.Parse(info[3], new CultureInfo("es-ES"));

                        buyer = new Citizen(name, age, id, birthdate);
                        break;
                    default:
                        throw new InvalidOperationException();
                }

                AddBuyer(ref collection, buyer);
            }
        }

        private static void AddBuyer(ref ICollection<IObject> collection, IObject buyer)
        {
            if (collection.Any(x => x.Name.Equals(buyer.Name)))
            {
                return;
            }

            collection.Add(buyer);
        }
    }
}
