using System;
using System.Linq;
using System.Text;

namespace Problem1.TheImitationGame
{
    class Program
    {
        private static StringBuilder message;

        static void Main(string[] args)
        {
            message = new StringBuilder();
            message.Append(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] tokens = input.Split('|');

                switch (tokens[0])
                {
                    case "Move":
                        Move(tokens);
                        break;
                    case "Insert":
                        Insert(tokens);
                        break;
                    case "ChangeAll":
                        ChangeAll(tokens);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine($"The decrypted message is: {message.ToString()}");
        }

        private static void ChangeAll(string[] tokens)
        {
            string substring = tokens[1];
            string replacement = tokens[2];

            message.Replace(substring, replacement);
        }

        private static void Insert(string[] tokens)
        {
            int index = int.Parse(tokens[1]);
            string value = tokens[2];

            message.Insert(index, value);
        }

        private static void Move(string[] tokens)
        {
            int numberOfLetters = int.Parse(tokens[1]);

            var firstPart = message.ToString().Take(numberOfLetters);
            var secondPart = message.ToString().Skip(numberOfLetters);

            message = new StringBuilder();
            message.Append(string.Join(string.Empty, secondPart));
            message.Append(string.Join(string.Empty, firstPart));
        }
    }
}
