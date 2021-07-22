using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IObject> citizens = new List<IObject>();
            SetCitizens(ref citizens);
            string specifiedDigits = Console.ReadLine();
            string result = GetResult(citizens, specifiedDigits);
            Console.WriteLine(result);
        }

        private static string GetResult(IList<IObject> citizens, string specifiedDigits)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var citizen in citizens)
            {
                if (citizen.Id.EndsWith(specifiedDigits))
                {
                    sb.AppendLine(citizen.Id);
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void SetCitizens(ref IList<IObject> citizens)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IObject @object;

                if (tokens.Length == 3)
                {
                    @object = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }
                else if (tokens.Length == 2)
                {
                    @object = new Robot(tokens[0], tokens[1]);
                }
                else
                {
                    throw new InvalidOperationException();
                }

                citizens.Add(@object);
            }
        }
    }
}
