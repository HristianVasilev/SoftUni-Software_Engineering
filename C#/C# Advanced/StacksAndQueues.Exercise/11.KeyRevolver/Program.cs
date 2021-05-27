using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            byte priceOfBullet = byte.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            Queue<int> locks = new Queue<int>(Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse));

            int inteligenceValue = int.Parse(Console.ReadLine());

            byte usedBullets = 0;
            Shoot(gunBarrelSize, ref usedBullets, ref bullets, ref locks);

            string output = GetOutput(priceOfBullet, bullets, locks, inteligenceValue, usedBullets);
            Console.WriteLine(output);
        }

        private static string GetOutput(byte priceOfBullet, Stack<int> bullets, Queue<int> locks, int inteligenceValue, byte usedBullets)
        {
            if (locks.Count > 0)
            {
                return $"Couldn't get through. Locks left: {locks.Count}";
            }

            int moneyEarned = inteligenceValue - usedBullets * priceOfBullet;
            return $"{bullets.Count} bullets left. Earned ${moneyEarned}";
        }

        private static void Shoot(int gunBarrelSize, ref byte usedBullets, ref Stack<int> bullets, ref Queue<int> locks)
        {
            byte bulletsInBarrel = (byte)gunBarrelSize;

            while (bullets.Count > 0 && locks.Count>0)
            {
                int bullet = bullets.Pop();
                int @lock = locks.Peek();

                bulletsInBarrel--;
                usedBullets++;

                if (bullet <= @lock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsInBarrel == 0 && bullets.Count > 0)
                {
                    bulletsInBarrel = Math.Min((byte)gunBarrelSize, (byte)bullets.Count);
                    Console.WriteLine("Reloading!");
                }
            }
        }
    }
}
