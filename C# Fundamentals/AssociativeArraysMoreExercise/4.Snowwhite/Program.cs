using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Snowwhite
{
    class Program
    {
        private static Dictionary<string, List<Dwarf>> dwarfDB;

        static void Main(string[] args)
        {
            dwarfDB = new Dictionary<string, List<Dwarf>>();

            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] commandArgs = command.Split("<:>", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

                string dwarfName = commandArgs[0];
                string dwarfHatColor = commandArgs[1];
                int dwarfPhysics = int.Parse(commandArgs[2]);

                AddToDb(dwarfName, dwarfHatColor, dwarfPhysics);
            }

            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<string, List<Dwarf>> orderedCollection = dwarfDB
                .OrderByDescending(x => x.Value.Sum(p => p.Physics))
                .ThenByDescending(x => x.Value.Count)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var (color, dwarfs) in orderedCollection)
            {
                foreach (var dwarf in dwarfs)
                {
                    sb.AppendLine($"({color}) {dwarf.Name} <-> {dwarf.Physics}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void AddToDb(string dwarfName, string dwarfHatColor, int dwarfPhysics)
        {
            if (!dwarfDB.ContainsKey(dwarfHatColor))
            {
                dwarfDB.Add(dwarfHatColor, new List<Dwarf>());           
            }

            Dwarf existentDwarft = dwarfDB[dwarfHatColor].FirstOrDefault(x => x.Name == dwarfName);

            if (existentDwarft is null)
            {
                dwarfDB[dwarfHatColor].Add(new Dwarf(dwarfName, dwarfPhysics));
                return;
            }

            if (existentDwarft.Physics < dwarfPhysics)
            {
                existentDwarft.Physics = dwarfPhysics;
            }
        }
    }

    internal class Dwarf
    {
        public Dwarf(string name, int physics)
        {
            this.Name = name;
            this.Physics = physics;
        }

        public string Name { get; }
        public int Physics { get; set; }
    }
}
