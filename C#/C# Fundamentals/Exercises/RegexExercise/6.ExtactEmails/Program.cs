using System;
using System.Text.RegularExpressions;

namespace _6.ExtactEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<user>(?<=\s)[a-z0-9]+([._-]?[a-z0-9]+)*(?=@))@(?<host>(?<=@)[a-z]+([-]?[a-z]+)*?(\.[a-z]+)+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
