
using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ForceBook
{
    class Program
    {
        private static Dictionary<string, List<string>> teamsInfo;
        private static string forceUser;
        private static string forceSide;

        static void Main(string[] args)
        {
            teamsInfo = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    Register(input);
                }
                else
                {
                    JoinSide(input);
                }
            }

            PrintAllTeamsInfo();
        }

        private static void PrintAllTeamsInfo()
        {
            teamsInfo = teamsInfo.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var team in teamsInfo)
            {
                string forceSide = team.Key;
                List<string> forceUsers = team.Value;
                Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");

                foreach (var user in forceUsers.OrderBy(n => n))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        private static void JoinSide(string input)
        {
            string[] arguments = input.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            forceUser = arguments[0];
            forceSide = arguments[1];

            RemoveIfExists(forceUser);

            Register();
            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }



        private static void Register(string input)
        {
            string[] arguments = input.Split("|", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();

            forceSide = arguments[0];
            forceUser = arguments[1];

            Register();
        }

        private static void Register()
        {
            if (!teamsInfo.ContainsKey(forceSide))
            {
                teamsInfo.Add(forceSide, new List<string>());
            }

            teamsInfo[forceSide].Add(forceUser);
        }



        private static bool RemoveIfExists(string forceUser)
        {
            foreach (var users in teamsInfo.Values)
            {
                if (users.Contains(forceUser))
                {
                    users.Remove(forceUser);
                    return true;
                }
            }

            return false;
        }
    }
}
