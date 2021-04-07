using System;

namespace _2.MuOnline
{
    class Program
    {
        private static int health;
        private static int bitCoins;

        static void Main(string[] args)
        {
            health = 100;
            bitCoins = 0;

            string[] dungeonsRooms = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dungeonsRooms.Length; i++)
            {
                string[] currentRoom = dungeonsRooms[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = currentRoom[0];
                int number = int.Parse(currentRoom[1]);

                switch (command)
                {
                    case "potion":

                        Potion(number);

                        break;
                    case "chest":

                        Chest(number);

                        break;

                    default:

                        int room = i + 1;
                        Attack(room, command, number);

                        break;
                }
            }

            Console.WriteLine($"You've made it!{Environment.NewLine}Bitcoins: {bitCoins}{Environment.NewLine}Health: {health}");
        }

        private static void Attack(int room, string command, int number)
        {
            string monster = command;

            if (health - number <= 0)
            {
                health = 0;

                Console.WriteLine($"You died! Killed by {monster}.");
                Console.WriteLine($"Best room: {room}");
                Environment.Exit(0);
            }
            else
            {
                health -= number;

                Console.WriteLine($"You slayed {monster}.");
            }
        }

        private static int Chest(int number)
        {
            bitCoins += number;
            Console.WriteLine($"You found {number} bitcoins.");
            return bitCoins;
        }

        private static void Potion(int number)
        {
            if (health + number > 100)
            {
                number = 100 - health;
            }

            health += number;

            Console.WriteLine($"You healed for {number} hp.");
            Console.WriteLine($"Current health: {health} hp.");
        }


    }
}
