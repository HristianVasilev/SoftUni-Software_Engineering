using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> childs = new List<string>();

            int key = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string message = Decrypt(input, key);

                string pattern = @"(@(?<name>[A-Za-z]+)[^@!:>-]*!(?<behaviour>[GN])!)";
                Match match = Regex.Match(message, pattern);

                string name = match.Groups["name"].Value;
                string behaviour = match.Groups["behaviour"].Value;

                if (behaviour == "G")
                {
                    childs.Add(name);
                }
            }

            string result = string.Join(Environment.NewLine, childs);
            Console.WriteLine(result);
        }

        private static string Decrypt(string input, int key)
        {
            var decripted = input.Select(x => (char)(x - key));
            return string.Join(string.Empty, decripted);
        }
    }
}
