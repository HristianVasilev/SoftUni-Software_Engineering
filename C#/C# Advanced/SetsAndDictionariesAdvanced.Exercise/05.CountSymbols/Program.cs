using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> stat = new Dictionary<char, int>();

            string text = Console.ReadLine();

            AnalyzeText(text, ref stat);

            string result = GetResult(stat);
            Console.WriteLine(result);
        }

        private static string GetResult(Dictionary<char, int> stat)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in stat.OrderBy(x => x.Key))
            {
                sb.AppendLine($"{symbol.Key}: {symbol.Value} time/s");
            }

            return sb.ToString().TrimEnd();
        }

        private static void AnalyzeText(string text, ref Dictionary<char, int> stat)
        {
            for (int i = 0; i < text.Length; i++)
            {
                char currentSymbol = text[i];

                if (!stat.ContainsKey(currentSymbol))
                {
                    stat.Add(currentSymbol, 0);
                }

                stat[currentSymbol]++;
            }
        }
    }
}
