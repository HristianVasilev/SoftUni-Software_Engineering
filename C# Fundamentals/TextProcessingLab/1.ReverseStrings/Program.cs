using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.ReverseStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> collection = new Dictionary<string, string>();

            string word;
            while ((word = Console.ReadLine()) != "end")
            {
                string reversedWord = string.Join("", word.Reverse());

                collection.Add(word, reversedWord);
            }

            string result = GetResult(ref collection);
            Console.WriteLine(result);
        }

        private static string GetResult(ref Dictionary<string, string> collection)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var word in collection)
            {
                sb.AppendLine($"{word.Key} = {word.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
