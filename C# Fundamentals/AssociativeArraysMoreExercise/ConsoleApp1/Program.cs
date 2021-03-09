using System;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        private static Dictionary<string, string> contests;

        static void Main(string[] args)
        {
            contests = new Dictionary<string, string>();

            string registerInput;
            while ((registerInput = Console.ReadLine()) != "end of contests")
            {
                string[] inputArgs = registerInput.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = inputArgs[0];
                string passwordForContest = inputArgs[1];

                RegisterContest(contest, passwordForContest);
            }


        }

        private static void RegisterContest(string contest, string passwordForContest)
        {
            if (contests.ContainsKey(contest))
            {
                throw new ArgumentException("There is already a contest with that name!");
            }

            contests.Add(contest, passwordForContest);
        }
    }
}
