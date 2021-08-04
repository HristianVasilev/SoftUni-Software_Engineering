using _01.Inventory;
using _01.Inventory.Interfaces;
using _01.Inventory.Models;
using _02.LegionSystem.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> priorityQueue = new PriorityQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                priorityQueue.Add(i);
            }

            List<int> result = new List<int>();
            while (priorityQueue.Size != 0)
            {
                result.Add(priorityQueue.Dequeue());
            }

            Console.WriteLine(string.Join(", ",result));
        }

        private static Inventory FillInventory(ref Inventory inventory, ref IWeapon savedWeapon)
        {

            ConstructorInfo[] constructors = new ConstructorInfo[]
{
               GetConstructorInfo(typeof(Pistol)),
               GetConstructorInfo(typeof(Shotgun)),
               GetConstructorInfo(typeof(Minigun)),
               GetConstructorInfo(typeof(Sniper)),
               GetConstructorInfo(typeof(RocketLauncher)),
               GetConstructorInfo(typeof(Cannon)),
};
            Random rnd = new Random();
            int boundIndex = rnd.Next(20);

            for (int i = 0; i < 20; i++)
            {
                var rndConstructor = constructors[rnd.Next(constructors.Length)];
                var rndAmmunition = rnd.Next(500);
                var rndMaxCapacity = rndAmmunition + rnd.Next(100);
                IWeapon rndWeapon = (IWeapon)rndConstructor
                    .Invoke(new object[] { i, rndMaxCapacity, rndAmmunition });
                if (i == boundIndex)
                {
                    savedWeapon = rndWeapon;
                }

                inventory.Add(rndWeapon);
            }

            return inventory;
        }

        private static ConstructorInfo GetConstructorInfo(Type eType)
        {
            return eType.GetConstructor(new Type[] { typeof(int), typeof(int), typeof(int) });
        }
    }
}
