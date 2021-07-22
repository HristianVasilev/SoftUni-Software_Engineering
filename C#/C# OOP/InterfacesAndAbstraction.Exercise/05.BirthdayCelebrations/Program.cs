using _05.BirthdayCelebrations.Models.Classes;
using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<IObject> collection = new List<IObject>();
            SetObjects(ref collection);
            int year = int.Parse(Console.ReadLine());

            string result = GetResult(collection, year);
            Console.WriteLine(result);
        }

        private static string GetResult(ICollection<IObject> collection, int year)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var obj in collection)
            {
                ICreature creature = obj as ICreature;

                if (creature is null)
                {
                    continue;
                }

                if (creature.Birthdate.Year.Equals(year))
                {
                    CultureInfo cultureInfo = new CultureInfo("es-ES");
                    sb.AppendLine(creature.Birthdate.ToString("d", cultureInfo));
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void SetObjects(ref ICollection<IObject> collection)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = arguments[0];
                string name = arguments[1];
                string id;
                DateTime birthdate;

                IObject obj;

                switch (type)
                {
                    case "Citizen":
                        int age = int.Parse(arguments[2]);
                        id = arguments[3];
                        birthdate = DateTime.Parse(arguments[4], new CultureInfo("es-ES"));

                        obj = new Citizen(name, age, id, birthdate);
                        break;
                    case "Robot":
                        id = arguments[2];

                        obj = new Robot(name, id);
                        break;
                    case "Pet":
                        birthdate = DateTime.Parse(arguments[2], new CultureInfo("es-ES"));

                        obj = new Pet(name, birthdate);
                        break;

                    default:
                        throw new InvalidOperationException();
                }

                collection.Add(obj);
            }
        }
    }
}
