using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string action = string.Join(' ', command.Skip(1));

                switch (action)
                {
                    case "is going!":
                        if (CheckTheName(guests, name))
                        {
                            Console.WriteLine($"{name} is already in the list!");
                        }
                        else
                        {
                            guests.Add(name);
                        }

                        break;
                    case "is not going!":
                        if (!CheckTheName(guests, name))
                        {
                            Console.WriteLine($"{name} is not in the list!");
                        }
                        else
                        {
                            guests.Remove(name);
                        }

                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintResult(guests);
        }

        private static void PrintResult(List<string> guests)
        {
            Console.WriteLine(string.Join(Environment.NewLine, guests));
        }

        private static bool CheckTheName(List<string> guests, string name)
        {
            return guests.Contains(name);
        }
    }
}
