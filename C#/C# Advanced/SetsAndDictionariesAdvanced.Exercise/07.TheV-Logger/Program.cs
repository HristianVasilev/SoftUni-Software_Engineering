using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.TheV_Logger
{
    class VloggerStatistics
    {
        public VloggerStatistics()
        {
            this.Followers = new HashSet<string>();
            this.Following = new HashSet<string>();
        }

        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }

    class Program
    {
        private static Dictionary<string, VloggerStatistics> statistics;

        static void Main(string[] args)
        {
            statistics = new Dictionary<string, VloggerStatistics>();

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string vloggername = tokens[0];
                string action = tokens[1];

                switch (action)
                {
                    case "joined":
                        AddVlogger(vloggername);
                        break;
                    case "followed":
                        string followedVlogger = tokens[2];
                        Follow(vloggername, followedVlogger);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid command!");
                }
            }

            string stat = GetStatistics();
            Console.WriteLine(stat);
        }

        private static string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            int registeredVloggers = statistics.Count;

            sb.AppendLine($"The V-Logger has a total of {registeredVloggers} vloggers in its logs.");

            if (registeredVloggers == 0)
            {
                return sb.ToString().TrimEnd();
            }

            statistics = statistics
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(k => k.Key, v => v.Value);

            KeyValuePair<string, VloggerStatistics> mostFamousVlogger = statistics.FirstOrDefault();

            sb.AppendLine($"1. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Following.Count} following");

            if (mostFamousVlogger.Value.Followers.Count > 0)
            {
                foreach (var follower in mostFamousVlogger.Value.Followers.OrderBy(x => x))
                {
                    sb.AppendLine($"*  {follower}");
                }
            }

            int no = 2;

            foreach (var vlogger in statistics.Skip(1))
            {
                sb.AppendLine($"{no++}. {vlogger.Key} : {vlogger.Value.Followers.Count} followers, {vlogger.Value.Following.Count} following");
            }

            return sb.ToString().TrimEnd();
        }

        private static void Follow(string vloggername, string followedVlogger)
        {
            if (!statistics.ContainsKey(vloggername) || !statistics.ContainsKey(followedVlogger) || vloggername == followedVlogger)
            {
                return;
            }

            statistics[vloggername].Following.Add(followedVlogger);
            statistics[followedVlogger].Followers.Add(vloggername);
        }

        private static void AddVlogger(string vloggername)
        {
            if (!statistics.ContainsKey(vloggername))
            {
                statistics.Add(vloggername, new VloggerStatistics());
            }
        }
    }
}
