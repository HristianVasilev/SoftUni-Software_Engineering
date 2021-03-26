using System;
using System.Text.RegularExpressions;

namespace _2.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\+359(?<separator>(?: |-))2\1\d{3}\1\d{4}(?!\d)";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            string result = string.Join(", ", matches);
            Console.WriteLine(result);
        }
    }
}
