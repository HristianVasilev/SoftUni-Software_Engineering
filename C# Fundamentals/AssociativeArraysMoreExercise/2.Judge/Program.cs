using System;
using System.Collections.Generic;

namespace _2.Judge
{
    class Program
    {
        private static Dictionary<string, List<Contest>> users;
        private static Dictionary<string, List<string>> contests;

        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                AddSubmission(username, contest, points);
            }



        }

        private static void AddSubmission(string username, string contest, int points)
        {
            AddToUsersData(username, contest, points);
            AddToContestsData(username, contest, points);
        }

        private static void AddToUsersData(string username, string contest, int points)
        {
            if (!users.ContainsKey(username))
            {
                users.Add(username, new List<Contest>());
            }
        }
    }

    internal class Contest
    {

    }
}
