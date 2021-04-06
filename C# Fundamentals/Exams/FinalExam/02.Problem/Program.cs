using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            byte n = byte.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"(?<!.)([$%])([A-Z][a-z]{2,})\1: (\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|)(?!.)";

                Match match = Regex.Match(input, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }

                var tag = match.Groups[2].Value;
                char firstDigit = (char)int.Parse(match.Groups[4].Value);
                char secondDigit = (char)int.Parse(match.Groups[5].Value);
                char thirdDigit = (char)int.Parse(match.Groups[6].Value);

                string decryptedMessage = $"{firstDigit}{secondDigit}{thirdDigit}";

                Console.WriteLine($"{tag}: {decryptedMessage}");
            }

        }
    }
}
