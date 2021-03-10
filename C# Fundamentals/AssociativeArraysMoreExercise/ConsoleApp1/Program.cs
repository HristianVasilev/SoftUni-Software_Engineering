using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Ranking
{
    class Program
    {
        private static Dictionary<string, string> register;
        private static Dictionary<string, List<Contest>> users;

        static void Main(string[] args)
        {
            register = new Dictionary<string, string>();
            users = new Dictionary<string, List<Contest>>();

            string registerInput;
            while ((registerInput = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = registerInput.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contestName = inputArgs[0];
                string passwordForContest = inputArgs[1];

                RegisterContest(contestName, passwordForContest);
            }

            string submissionInput;
            while ((submissionInput = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionArgs = submissionInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contestName = submissionArgs[0];
                string password = submissionArgs[1];
                string username = submissionArgs[2];
                int points = int.Parse(submissionArgs[3]);

                AddSubmission(contestName, password, username, points);
            }

            string result = TakeResults();
            Console.WriteLine(result);
        }

        private static string TakeResults()
        {
            KeyValuePair<string, int> bestUser = FindBestUser();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Best candidate is {bestUser.Key} with total {bestUser.Value} points.");
            sb.AppendLine("Ranking:");

            foreach (var (usename, contests) in users.OrderBy(x => x.Key))
            {
                sb.AppendLine($"{usename}");
                contests.OrderByDescending(x => x.Points).ToList().ForEach(c => sb.AppendLine($"#  {c.Name} -> {c.Points}"));
            }

            return sb.ToString().TrimEnd();
        }

        private static KeyValuePair<string, int> FindBestUser()
        {
            int maxTotalPoints = users.Max(u => u.Value.Sum(p => p.Points));
            string bestUser_name = users.First(u => u.Value.Sum(p => p.Points) == maxTotalPoints).Key;

            return new KeyValuePair<string, int>(bestUser_name, maxTotalPoints);
        }

        private static void AddSubmission(string contestName, string password, string username, int points)
        {
            if (!ValidContest(contestName, password))
            {
                return;
            }

            if (!users.ContainsKey(username))
            {
                users.Add(username, new List<Contest>());
            }

            Contest contest = new Contest(contestName, points);

            Contest xx = users[username].FirstOrDefault(c => c.Equals(contest));

            Contest existentContest = users[username].FirstOrDefault(c => c.Name == contestName);

            if (existentContest != null && existentContest.Points < points)
            {
                existentContest = new Contest(contestName, points);
            }
            else if (existentContest is null)
            {
                users[username].Add(new Contest(contestName, points));
            }
        }

        private static bool ValidContest(string contestName, string password)
        {
            if (!register.ContainsKey(contestName))
            {
                return false;
            }

            return register[contestName] == password;
        }

        private static void RegisterContest(string contestName, string password)
        {
            if (register.ContainsKey(contestName))
            {
                throw new ArgumentException("There is already a contest with that name!");
            }

            register.Add(contestName, password);
        }
    }
    class Contest :  IComparable<Contest>
    {
        public Contest(string contestName, int points)
        {
            this.Name = contestName;
            this.Points = points;
        }

        public string Name { get; }
        public int Points { get; set; }

     

        public int CompareTo([AllowNull] Contest other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            if (this.CompareTo(obj as Contest) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
