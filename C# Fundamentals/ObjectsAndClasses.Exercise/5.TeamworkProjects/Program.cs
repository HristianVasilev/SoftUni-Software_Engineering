using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.TeamworkProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int countOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamArgs = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

                string creator = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Any(t => t.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(creator, teamName);
                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries);

                string user = joinArgs[0];
                string teamName = joinArgs[1];

                Team team = teams.FirstOrDefault(t => t.TeamName == teamName);

                if (team is null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(t => t.Creator == user || t.Users.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                team.JoinUser(user);
            }

            string output = GetTeamsInfo(ref teams);
            Console.WriteLine(output); ;
        }

        private static string GetTeamsInfo(ref List<Team> teams)
        {
            StringBuilder sb = new StringBuilder();

            var validTeams = teams.Where(t => t.Users.Count > 0).OrderByDescending(t => t.Users.Count).ThenBy(t => t.TeamName).ToList();

            foreach (var team in validTeams)
            {
                sb.AppendLine(team.ToString());
            }

            var invalidTeams = teams.Where(t => t.Users.Count == 0).OrderBy(t => t.TeamName).ToList();

            sb.AppendLine("Teams to disband:");
            invalidTeams.ForEach(t => sb.AppendLine(t.TeamName));

            return sb.ToString().TrimEnd();
        }
    }

    class Team
    {
        private readonly List<string> users;

        public Team(string creator, string teamName)
        {
            this.Creator = creator;
            this.TeamName = teamName;
            this.users = new List<string>();
        }

        public string Creator { get; private set; }
        public string TeamName { get; private set; }

        public List<string> Users => this.users;

        public void JoinUser(string user)
        {
            this.users.Add(user);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.TeamName}");
            sb.AppendLine($"- {this.Creator}");

            foreach (var user in this.Users.OrderBy(u => u))
            {
                sb.AppendLine($"-- {user}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
