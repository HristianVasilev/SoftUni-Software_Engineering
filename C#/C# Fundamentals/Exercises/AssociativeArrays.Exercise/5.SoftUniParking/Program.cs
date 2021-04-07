using System;
using System.Collections.Generic;

namespace _5.SoftUniParking
{
    class Program
    {
        private static Dictionary<string, string> parking;

        static void Main(string[] args)
        {
            parking = new Dictionary<string, string>();

            byte countOfCommands = byte.Parse(Console.ReadLine());

            for (byte i = 0; i < countOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                RunCommand(commandArgs);
            }

            PrintAllFromParking();
        }

        private static void PrintAllFromParking()
        {
            foreach (var user in parking)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }

        private static void RunCommand(string[] commandArgs)
        {
            string action = commandArgs[0];
            string username = commandArgs[1];

            switch (action)
            {
                case "register":
                    string licensePlateNumber = commandArgs[2];
                    Register(username, licensePlateNumber);

                    break;
                case "unregister":
                    Unregister(username);

                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        private static void Unregister(string username)
        {
            if (!parking.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
                return;
            }

            parking.Remove(username);
            Console.WriteLine($"{username} unregistered successfully");
        }

        private static void Register(string username, string licensePlateNumber)
        {
            if (parking.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                return;
            }

            parking.Add(username, licensePlateNumber);
            Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
        }
    }

}
