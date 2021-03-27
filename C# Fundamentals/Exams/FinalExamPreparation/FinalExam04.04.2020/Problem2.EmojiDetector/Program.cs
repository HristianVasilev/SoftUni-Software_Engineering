using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.EmojiDetector
{
    class Program
    {
        private static StringBuilder sb;

        static void Main(string[] args)
        {
            sb = new StringBuilder();

            string input = Console.ReadLine();

            BigInteger coolThresHold = ThresHold(input);

            List<string> emojis = Emojis(input, coolThresHold);

            GetEmojisResult(emojis);
            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void GetEmojisResult(List<string> emojis)
        {
            if (emojis.Count == 0)
            {
                return;
            }

            foreach (var item in emojis)
            {
                sb.AppendLine(item);
            }
        }

        private static BigInteger ThresHold(string input)
        {
            string pattern = @"\d";
            MatchCollection collection = Regex.Matches(input, pattern);

            BigInteger result = 1;
            foreach (Match item in collection)
            {
                result *= byte.Parse(item.Value);
            }

            sb.AppendLine($"Cool threshold: {result}");
            return result;
        }

        private static List<string> Emojis(string input, BigInteger coolThresHold)
        {
            List<string> emojis = new List<string>();

            string pattern = @"((:|\*){2})([A-Z][a-z]{2,})\1";
            MatchCollection collection = Regex.Matches(input, pattern);

            sb.AppendLine($"{collection.Count} emojis found in the text. The cool ones are:");

            foreach (Match item in collection)
            {
                string core = item.Groups[3].Value;

                BigInteger sum = core.Sum(c => c);

                if (sum >= coolThresHold)
                {
                    emojis.Add(item.Value);
                }
            }

            return emojis;
        }
    }
}
