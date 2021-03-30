using System;
using System.Linq;

namespace Problem1.Secret_Chat
{
    class Program
    {
        private static string message;
        private static bool error;

        static void Main(string[] args)
        {
            message = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] tokens = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                error = false;

                switch (tokens[0])
                {
                    case "InsertSpace":
                        InsertSpace(tokens);
                        break;
                    case "Reverse":
                        Reverse(tokens);
                        break;
                    case "ChangeAll":
                        ChangeAll(tokens);
                        break;

                    default:
                        throw new NotImplementedException("Invalid comamnd!");
                }

                if (!error)
                {
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        private static void ChangeAll(string[] tokens)
        {
            string substring = tokens[1];
            string replacement = tokens[2];

            while (message.Contains(substring))
            {
                message = message.Replace(substring, replacement);
            }
        }

        private static void Reverse(string[] tokens)
        {
            string substring = tokens[1];

            if (!message.Contains(substring))
            {
                Console.WriteLine("error");
                error = true;
                return;
            }

            var index = message.IndexOf(substring);

            message = DeleteSubstring(substring);
            string reversed = string.Join(string.Empty, substring.Reverse());

            message = message + reversed;
        }

        private static string DeleteSubstring(string substring)
        {
            var index = message.IndexOf(substring);

            return message.Remove(index, substring.Length);
        }

        private static void InsertSpace(string[] tokens)
        {
            byte index = byte.Parse(tokens[1]);

            message = message.Insert(index, " ");
        }
    }
}
