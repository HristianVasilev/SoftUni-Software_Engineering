using System;
using System.Collections.Generic;

namespace _3.MOBAChallenger
{
    class Program
    {
        private static Dictionary<string, List<Position>> playerPool;

        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("->"))
                {
                    AddSubmission(command);
                }
                else if (command.Contains("vs"))
                {

                }
            }
        }

        private static void AddSubmission(string command)
        {
            string[] commandArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries);

            string player = commandArgs[0];
            string position = commandArgs[1];
            int skill = int.Parse(commandArgs[2]);

            if (!playerPool.ContainsKey(player))
            {
                playerPool.Add(player, new List<Position>());
            }


        }
    }

    internal class Position
    {
        public Position(string positionName, int skill)
        {
            this.PositionName = positionName;
            this.Skill = skill;
        }

        public string PositionName { get; set; }
        public int Skill { get; set; }

    }
}
