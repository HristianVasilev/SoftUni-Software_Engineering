using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long coolThresHold = CalculateThresHold(input);
            Console.WriteLine($"Cool threshold: {coolThresHold}");
            string emojisInfo = Emojis(input, coolThresHold);
            Console.WriteLine(emojisInfo);
        }

        private static long CalculateThresHold(string input)
        {
            string pattern = @"\d";
            MatchCollection collection = Regex.Matches(input, pattern);

            long result = 1;
            foreach (Match item in collection)
            {
                result *= byte.Parse(item.Value);
            }

            return result;
        }

        private static string Emojis(string input, long coolThresHold)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"(::|\*\*)([A-Z][a-z]{2,})\1";
            MatchCollection collection = Regex.Matches(input, pattern);

            sb.AppendLine(($"{collection.Count} emojis found in the text. The cool ones are:"));

            foreach (Match item in collection)
            {
                string core = item.Groups[2].Value;

                long sum = core.Sum(c => c);

                if (sum > coolThresHold)
                {
                    sb.AppendLine(item.Value);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
