using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Problem
{
    class User
    {
        public int Likes { get; set; }
        public int Comments { get; set; }
    }

    class Program
    {
        private static Dictionary<string, User> users;

        static void Main(string[] args)
        {
            users = new Dictionary<string, User>();

            string command;
            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] tokens = command.Split(": ");

                switch (tokens[0])
                {
                    case "New follower":
                        NewFollower(tokens);
                        break;
                    case "Like":
                        Like(tokens);
                        break;
                    case "Comment":
                        Comment(tokens);
                        break;
                    case "Blocked":
                        Blocked(tokens);
                        break;
                    default:
                        break;
                }
            }

            PrintAll();
        }

        private static void PrintAll()
        {
            users = users
                .OrderByDescending(x => x.Value.Likes + x.Value.Comments)
                .ThenBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"{users.Count} followers");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: {user.Value.Likes + user.Value.Comments}");
            }
        }

        private static void Blocked(string[] tokens)
        {
            string username = tokens[1];

            bool exists = users.Remove(username);

            if (!exists)
            {
                Console.WriteLine($"{username} doesn't exist.");
            }
        }

        private static void Comment(string[] tokens)
        {
            string username = tokens[1];

            if (!users.ContainsKey(username))
            {
                users.Add(username, new User());
            }

            users[username].Comments++;
        }

        private static void Like(string[] tokens)
        {
            string username = tokens[1];
            int count = int.Parse(tokens[2]);

            if (!users.ContainsKey(username))
            {
                users.Add(username, new User());
            }

            users[username].Likes += count;
        }

        private static void NewFollower(string[] tokens)
        {
            string username = tokens[1];

            if (!users.ContainsKey(username))
            {
                users.Add(username, new User());
            }
        }
    }
}
