using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _2.Judge
{
    class Program
    {
        private static Dictionary<string, List<Contest>> usersDB;
        private static Dictionary<string, List<string>> contestsDB;

        static void Main(string[] args)
        {
            usersDB = new Dictionary<string, List<Contest>>();
            contestsDB = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                AddSubmission(username, contest, points);
            }

            string contestsInfo = GetContests();
            string individualStat = GetIndividualStat();
            Console.WriteLine(contestsInfo);
            Console.WriteLine(individualStat);
        }

        private static string GetIndividualStat()
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<string, int> users = usersDB.Select(u => new KeyValuePair<string, int>(u.Key, u.Value.Sum(p => p.Points)))
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            int i = 1;
            sb.AppendLine("Individual standings:");

            foreach (var (username, totalPoints) in users)
            {
                sb.AppendLine($"{i++}. {username} -> {totalPoints}");
            }

            return sb.ToString().TrimEnd();
        }



        private static string GetContests()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var (contestName, users) in contestsDB)
            {
                sb.AppendLine($"{contestName}: {users.Count} participants");
                int i = 1;

                Dictionary<string, Contest> collectionOfUsersContest =
                    GetUsersContest(contestName, users)
                    .OrderByDescending(p => p.Value.Points)
                    .ThenBy(k => k.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var (username, contest) in collectionOfUsersContest)
                {
                    sb.AppendLine($"{i++}. {username} <::> {contest.Points}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static Dictionary<string, Contest> GetUsersContest(string contestName, List<string> users)
        {
            Dictionary<string, Contest> collectionOfUsersContest = new Dictionary<string, Contest>();

            foreach (var (username, contests) in usersDB.Where(x => users.Contains(x.Key)))
            {
                Contest contest = contests.FirstOrDefault(x => x.Name == contestName);

                if (contest is null)
                {
                    Console.WriteLine("Invalid contest!");
                    continue;
                }

                collectionOfUsersContest.Add(username, contest);
            }

            return collectionOfUsersContest;
        }



        private static void AddSubmission(string username, string contestName, int points)
        {
            if (!usersDB.ContainsKey(username))
            {
                usersDB.Add(username, new List<Contest>());
            }

            if (!contestsDB.ContainsKey(contestName))
            {
                contestsDB.Add(contestName, new List<string>());
            }

            Contest contest = new Contest(contestName, points);
            Contest existing = usersDB[username].FirstOrDefault(c => c.Equals(contest));

            if (existing != null && contest.IsGreaterThan(existing))
            {
                usersDB[username].Remove(existing);
                usersDB[username].Add(contest);
            }
            else if (existing == null)
            {
                usersDB[username].Add(contest);
            }

            if (!contestsDB[contestName].Contains(username))
            {
                contestsDB[contestName].Add(username);
            }
        }
    }

    internal class Contest : IComparable<Contest>
    {
        public Contest(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }
        public int Points { get; set; }

        public int CompareTo([AllowNull] Contest other)
        {
            return this.Name.CompareTo(other.Name);
        }

        internal bool IsGreaterThan(Contest existing)
        {
            return this.Points > existing.Points;
        }

        public override bool Equals(object obj)
        {
            Contest other = obj as Contest;

            if (other is null)
            {
                return false;
            }

            if (this.Name == other.Name)
            {
                return true;
            }

            return false;
        }
    }
}
