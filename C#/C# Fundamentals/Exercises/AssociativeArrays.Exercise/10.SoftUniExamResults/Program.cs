using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _10.SoftUniExamResults
{
    class Program
    {
        private static Dictionary<string, User> exams;

        static void Main(string[] args)
        {
            exams = new Dictionary<string, User>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string username = tokens[0];

                if (tokens.Contains("banned"))
                {
                    BannUser(username);
                    continue;
                }

                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                AddResult(username, language, points);
            }

            string results = GetResults();
            string submissions = GetSubmissions();

            Console.WriteLine(results);
            Console.WriteLine(submissions);
        }

        private static string GetSubmissions()
        {
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            foreach (var student in exams.Values)
            {
                var thisStudentLanguages = student.Languages.Select(x => x.LanguageName);

                foreach (var language in thisStudentLanguages)
                {
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    var countOfResults = student.Languages.First(l => l.Equals(language)).Results.Count;

                    submissions[language] += countOfResults;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(v => v.Value))
            {
                sb.AppendLine($"{submission.Key} - {submission.Value}");
            }

            return sb.ToString().TrimEnd();
        }

        private static string GetResults()
        {
            var activeUsers = exams
                .Where(u => u.Value.Active)
                .OrderByDescending(p => p.Value.Languages.Sum(x => x.Results.Max()))
                .ThenBy(k => k.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Results:");
            foreach (var user in activeUsers)
            {
                sb.AppendLine($"{user.Key} | {user.Value.Languages.Sum(x => x.Results.Max())}");
            }

            return sb.ToString().TrimEnd();
        }



        private static void AddResult(string username, string language, int points)
        {
            if (!exams.ContainsKey(username))
            {
                exams.Add(username, new User(username));
            }

            bool languageExists = exams[username].Languages.Any(l => l.Equals(language));

            if (!languageExists)
            {
                exams[username].Languages.Add(new Language(language));
            }

            exams[username].Languages.First(l => l.Equals(language)).Results.Add(points);
        }

        private static void BannUser(string username)
        {
            if (!exams.ContainsKey(username))
            {
                throw new ArgumentException("User doesn't exists!");
            }

            exams[username].Bann();
        }
    }

    class User
    {
        public User(string username)
        {
            this.Username = username;
            this.Languages = new List<Language>();
            this.Active = true;
        }

        public string Username { get; set; }

        public List<Language> Languages { get; set; }

        public bool Active { get; set; }

        public void Bann()
        {
            this.Active = false;
        }
    }

    class Language : IEquatable<string>
    {
        public Language(string languageName)
        {
            this.LanguageName = languageName;
            this.Results = new List<int>();
        }

        public string LanguageName { get; set; }
        public List<int> Results { get; set; }

        public bool Equals([AllowNull] string other)
        {
            return LanguageName.Equals(other);
        }
    }
}
