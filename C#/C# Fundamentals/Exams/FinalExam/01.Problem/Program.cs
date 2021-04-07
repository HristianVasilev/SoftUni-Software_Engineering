using System;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        private static string text;

        static void Main(string[] args)
        {
            text = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Finish")
                {
                    break;
                }

                switch (tokens[0])
                {
                    case "Replace":
                        Replace(tokens);
                        break;
                    case "Cut":
                        Cut(tokens);
                        break;
                    case "Make":
                        Make(tokens);
                        break;
                    case "Check":
                        Check(tokens);
                        break;
                    case "Sum":
                        Sum(tokens);
                        break;

                    default:
                        throw new NotImplementedException("Invalid command!");
                }
            }
        }

        private static void Sum(string[] tokens)
        {
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            if (!ValidIndex(startIndex) || !ValidIndex(endIndex))
            {
                Console.WriteLine("Invalid indices!");
                return;
            }

            int length = endIndex - startIndex+1;
            var substring = text.Substring(startIndex, length);

            var sum = substring.Sum(x => x);
            Console.WriteLine(sum);
        }

        private static void Check(string[] tokens)
        {
            string str = tokens[1];

            if (text.Contains(str))
            {
                Console.WriteLine($"Message contains {str}");
            }
            else
            {
                Console.WriteLine($"Message doesn't contain {str}");
            }
        }

        private static void Make(string[] tokens)
        {
            string typeOfLetters = tokens[1];

            switch (typeOfLetters)
            {
                case "Upper":
                    text = text.ToUpper();
                    break;
                case "Lower":
                    text = text.ToLower();
                    break;
                default:
                    throw new NotImplementedException("No such type of letters!");
            }

            Console.WriteLine(text);
        }

        private static void Cut(string[] tokens)
        {
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            if (!ValidIndex(startIndex) || !ValidIndex(endIndex))
            {
                Console.WriteLine("Invalid indices!");
                return;
            }

            int count = endIndex - startIndex+1;
            text = text.Remove(startIndex, count);

            Console.WriteLine(text);
        }

        private static bool ValidIndex(int index)
        {
            return index >= 0 && index < text.Length;
        }

        private static void Replace(string[] tokens)
        {
            char currentChar = char.Parse(tokens[1]);
            char newChar = char.Parse(tokens[2]);

            while (text.Contains(currentChar))
            {
                text = text.Replace(currentChar, newChar);
            }

            Console.WriteLine(text);
        }
    }
}
