using System;
using System.Linq;

namespace _3.ManOWar
{
    class Program
    {
        private static int[] pirateShipStatus;
        private static int[] warShipStatus;
        private static int maxHealth;

        static void Main(string[] args)
        {
            pirateShipStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            warShipStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            maxHealth = int.Parse(Console.ReadLine());

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();

                switch (action)
                {
                    case "Fire":
                        Fire(commandArgs);

                        break;
                    case "Defend":
                        Defend(commandArgs);

                        break;
                    case "Repair":
                        Repair(commandArgs);

                        break;
                    case "Status":
                        Status();

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine($"Pirate ship status: {pirateShipStatus.Sum()}");
            Console.WriteLine($"Warship status: {warShipStatus.Sum()}");

        }

        private static void Status()
        {
            int countOfSectionsForRepair = pirateShipStatus.Where(x => x < 0.2 * maxHealth).ToArray().Length;
            Console.WriteLine($"{countOfSectionsForRepair} sections need repair.");
        }

        private static void Repair(string[] commandArgs)
        {
            int index = int.Parse(commandArgs[0]);

            if (!ValidIndex(index, pirateShipStatus))
            {
                return;
            }

            int health = int.Parse(commandArgs[1]);

            pirateShipStatus[index] = Math.Min(pirateShipStatus[index] + health, maxHealth);
        }

        private static void Defend(string[] commandArgs)
        {
            int startIndex = int.Parse(commandArgs[0]);
            int endIndex = int.Parse(commandArgs[1]);

            bool validStartIdx = ValidIndex(startIndex, pirateShipStatus);
            bool validEndIdx = ValidIndex(endIndex, pirateShipStatus);

            if (!validStartIdx || !validEndIdx)
            {
                return;
            }

            int damage = int.Parse(commandArgs[2]);

            AttackPirateShip(startIndex, endIndex, damage);
        }

        private static void AttackPirateShip(int startIndex, int endIndex, int damage)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                pirateShipStatus[i] -= damage;

                if (pirateShipStatus[i] <= 0)
                {
                    Console.WriteLine("You lost! The pirate ship has sunken.");
                    Environment.Exit(0);
                }
            }
        }

        private static bool ValidIndex(int index, int[] array)
        {
            return index >= 0 && index < array.Length;
        }

        private static void Fire(string[] commandArgs)
        {
            int index = int.Parse(commandArgs[0]);

            if (!ValidIndex(index, warShipStatus))
            {
                return;
            }

            int damage = int.Parse(commandArgs[1]);

            warShipStatus[index] -= damage;

            if (warShipStatus[index] <= 0)
            {
                Console.WriteLine("You won! The enemy ship has sunken.");
                Environment.Exit(0);
            }
        }
    }
}
