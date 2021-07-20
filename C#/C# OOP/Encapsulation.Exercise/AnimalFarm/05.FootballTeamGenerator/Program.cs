using _05.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        private static ICollection<Team> teams;

        static void Main(string[] args)
        {
            teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                tokens = tokens.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team team = CreateTeam(tokens);
                            teams.Add(team);
                            break;
                        case "Add":
                            AddPlayer(tokens);
                            break;
                        case "Remove":
                            RemovePlayer(tokens);
                            break;
                        case "Rating":
                            GetRating(tokens);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void GetRating(string[] tokens)
        {
            string teamName = tokens[0];

            Team team = FindTeam(teamName);
            Console.WriteLine($"{team.Name} - {team.Rating}");
        }

        private static void RemovePlayer(string[] tokens)
        {
            string teamName = tokens[0];
            string playerName = tokens[1];

            Team team = FindTeam(teamName);
            team.RemovePlayer(playerName);
        }

        private static void AddPlayer(string[] tokens)
        {
            string teamName = tokens[0];
            Team team = FindTeam(teamName);

            string playerName = tokens[1];
            int endurance = int.Parse(tokens[2]);
            int sprint = int.Parse(tokens[3]);
            int dribble = int.Parse(tokens[4]);
            int passing = int.Parse(tokens[5]);
            int shooting = int.Parse(tokens[6]);

            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            team.AddPlayer(player);
        }

        private static Team FindTeam(string teamName)
        {
            Team team = teams.FirstOrDefault(x => x.Name.Equals(teamName));

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            return team;
        }

        private static Team CreateTeam(string[] arguments)
        {
            string teamName = arguments[0];
            return new Team(teamName); ;
        }
    }
}
