using System;
using System.Collections.Generic;

namespace _11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> workDays = new Dictionary<string, double>()
            {
                { "banana",2.50 },
                { "apple", 1.20 },
                { "orange",0.85 },
                { "grapefruit",1.45 },
                { "kiwi",2.70 },
                { "pineapple",5.50 },
                { "grapes", 3.85 }
            };

            Dictionary<string, double> weekDays = new Dictionary<string, double>()
            {
                { "banana",2.70 },
                { "apple", 1.25 },
                { "orange",0.90 },
                { "grapefruit",1.60 },
                { "kiwi",3.00 },
                { "pineapple",5.60 },
                { "grapes", 4.20 }
            };

            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double count = double.Parse(Console.ReadLine());

            double result = 0;

            if (!(workDays.ContainsKey(fruit) || weekDays.ContainsKey(fruit)))
            {
                Console.WriteLine("error");
                return;
            }

            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":

                    result = workDays[fruit] * count;

                    break;
                case "Saturday":
                case "Sunday":

                    result = weekDays[fruit] * count;

                    break;
                default:
                    Console.WriteLine("error");
                    return;
            }

            Console.WriteLine($"{result:F2}");
        }
    }
}
