using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.MOBAChallenger
{
    class Program
    {
        private static Dictionary<string, List<Position>> playerPool;

        static void Main(string[] args)
        {
            playerPool = new Dictionary<string, List<Position>>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("->"))
                {
                    AddSubmission(command);
                }
                else if (command.Contains("vs"))
                {
                    Duel(command);
                }
            }

            string playersInfo = GetPlayersInfo();
            Console.WriteLine(playersInfo);
        }

        private static string GetPlayersInfo()
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<string, List<Position>> orderedCollection = playerPool
                .OrderByDescending(x => x.Value.Sum(s => s.Skill))
                .ThenBy(x => x.Key)
                .Where(x => x.Value.Count > 0)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var (player, positions) in orderedCollection)
            {
                sb.AppendLine($"{player}: {positions.Sum(x => x.Skill)} skill");
                List<Position> orderedPositions = positions
                    .OrderByDescending(x => x.Skill)
                    .ThenBy(x => x.PositionName)
                    .ToList();

                orderedPositions.ForEach(p => sb.AppendLine(p.ToString()));
            }

            return sb.ToString().TrimEnd();
        }



        private static void Duel(string command)
        {
            string[] commandArgs = command.Split(" vs ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            string player1 = commandArgs[0];
            string player2 = commandArgs[1];

            if (!PlayerExists(player1) || !PlayerExists(player2))
            {
                // Invalid duel!
                return;
            }

            CheckAllCommonPositions(player1, player2);
        }

        private static void CheckAllCommonPositions(string player1, string player2)
        {
            HashSet<Position> equalPositions = new HashSet<Position>();

            List<Position> player_1_Positions = playerPool[player1];
            List<Position> player_2_Positions = playerPool[player2];

            Position commonPosition = player_2_Positions.FirstOrDefault(p => player_1_Positions.Contains(p) && !equalPositions.Contains(p));

            while (commonPosition != null)
            {
                Position position1 = player_1_Positions.First(p => p.Equals(commonPosition));
                Position position2 = player_2_Positions.First(p => p.Equals(commonPosition));

                if (position1.Skill == position2.Skill)
                {
                    equalPositions.Add(commonPosition);
                    commonPosition = player_2_Positions.FirstOrDefault(p => player_1_Positions.Contains(p) && !equalPositions.Contains(p));
                    continue;
                }

                if (position1.Skill > position2.Skill)
                {
                    player_2_Positions.Remove(commonPosition);
                }
                else if (position1.Skill < position2.Skill)
                {
                    player_1_Positions.Remove(commonPosition);
                }

                commonPosition = player_2_Positions.FirstOrDefault(p => player_1_Positions.Contains(p) && !equalPositions.Contains(p));
            }
        }

        private static bool PlayerExists(string player)
        {
            return playerPool.ContainsKey(player);
        }

        private static void AddSubmission(string command)
        {
            string[] commandArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            string player = commandArgs[0];
            string positionName = commandArgs[1];
            int skill = int.Parse(commandArgs[2]);

            if (!playerPool.ContainsKey(player))
            {
                playerPool.Add(player, new List<Position>());
            }

            Position existing = playerPool[player].FirstOrDefault(p => p.PositionName == positionName);

            if (existing is null)
            {
                playerPool[player].Add(new Position(positionName, skill));
                return;
            }

            if (existing.Skill < skill)
            {
                existing.Skill = skill;
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


        public override bool Equals(object obj)
        {
            Position other = obj as Position;

            if (other is null)
            {
                return false;
            }

            if (this.PositionName.CompareTo(other.PositionName) == 0)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"- {this.PositionName} <::> {this.Skill}";
        }
    }
}
