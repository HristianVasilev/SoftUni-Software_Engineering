using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.Ranking
{
    class Contest
    {
        public Contest(string contestName, int points)
        {
            this.ContestName = contestName;
            this.Points = points;
        }

        public string ContestName { get; }
        public int Points { get; private set; }

        public void UpdatePoints(int points)
        {
            if (points > this.Points)
            {
                this.Points = points;
            }
        }
    }

    class Program
    {
        private static Dictionary<string, string> contestValidation;
        private static Dictionary<string, List<Contest>> students;

        static void Main(string[] args)
        {
            contestValidation = new Dictionary<string, string>();
            students = new Dictionary<string, List<Contest>>();

            string contestInput;
            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = contestInput.Split(':', StringSplitOptions.RemoveEmptyEntries);

                string contest = tokens[0];
                string password = tokens[1];

                RegisterTheContest(contest, password);
            }

            string sumbissionInput;
            while ((sumbissionInput = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = sumbissionInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                RegisterStudent(contest, password, username, points);
            }

            string result = GetResult();
            Console.WriteLine(result);
        }

        private static string GetResult()
        {
            StringBuilder sb = new StringBuilder();

            var bestCandidate = students
                .OrderByDescending(s => s.Value.Sum(p => p.Points))
                .FirstOrDefault();

            sb.AppendLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Sum(p => p.Points)} points.");
            sb.AppendLine($"Ranking:");

            students = students.OrderBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var student in students)
            {
                sb.AppendLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(p => p.Points))
                {
                    sb.AppendLine($"#  {contest.ContestName} -> {contest.Points}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        private static void RegisterStudent(string contestName, string password, string username, int points)
        {
            if (!CorrectPassword(contestName, password))
            {
                return;
            }

            if (!students.ContainsKey(username))
            {
                students.Add(username, new List<Contest>());
            }

            Contest contest = students[username].FirstOrDefault(x => x.ContestName == contestName);

            if (contest == null)
            {
                students[username].Add(new Contest(contestName, points));
            }
            else
            {
                contest.UpdatePoints(points);
            }
        }

        private static bool CorrectPassword(string contest, string password)
        {
            if (!contestValidation.ContainsKey(contest) || contestValidation[contest] != password)
            {
                return false;
            }

            return true;
        }

        private static void RegisterTheContest(string contest, string password)
        {
            if (!contestValidation.ContainsKey(contest))
            {
                contestValidation.Add(contest, password);
            }
        }
    }
}
