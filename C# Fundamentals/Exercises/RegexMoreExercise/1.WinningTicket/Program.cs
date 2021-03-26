using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftHalf = string.Join(string.Empty, ticket.Take(10));
                string rightHalf = string.Join(string.Empty, ticket.TakeLast(10));

                string leftMatch = Match(leftHalf);
                string rightMatch = Match(rightHalf);

                string validation = ValidateTicket(ticket, leftMatch, rightMatch);
                Console.WriteLine(validation);
            }
        }

        private static string ValidateTicket(string ticket, string leftMatch, string rightMatch)
        {
            if (leftMatch == string.Empty || rightMatch == string.Empty || leftMatch.Length != rightMatch.Length)
            {
                return $"ticket \"{ticket}\" - no match";
            }

            char symbol = leftMatch[0];
            int countTimes = leftMatch.Length;

            if (countTimes >= 6 && countTimes <= 9)
            {
                return $"ticket \"{ticket}\" - {countTimes}{symbol}";
            }
            else if (countTimes == 10)
            {
                return $"ticket \"{ticket}\" - {countTimes}{symbol} Jackpot!";
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private static string Match(string input)
        {
            string pattern = @"[@#$^]{6,10}";
            Match match = Regex.Match(input, pattern);

            return match.Value;
        }
    }
}
