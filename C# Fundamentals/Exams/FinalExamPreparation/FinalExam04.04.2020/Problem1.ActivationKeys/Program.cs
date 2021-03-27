using System;
using System.Linq;

namespace Problem1.ActivationKeys
{
    class Program
    {
        private static string activationKey;

        static void Main(string[] args)
        {
            activationKey = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Contains":
                        Contains(tokens);
                        break;
                    case "Flip":
                        Flip(tokens);
                        break;
                    case "Slice":
                        Slice(tokens);
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {string.Join(string.Empty, activationKey)}");
        }

        private static void Slice(string[] tokens)
        {
            int startIndex = int.Parse(tokens[1]);
            int endIndex = int.Parse(tokens[2]);

            string leftPart = activationKey.Substring(0, startIndex);
            string rightPart = activationKey.Substring(endIndex, activationKey.Length - endIndex);

            activationKey = leftPart + rightPart;
            Console.WriteLine(activationKey);
        }

        private static void Flip(string[] tokens)
        {
            string action = tokens[1];
            int startIndex = int.Parse(tokens[2]);
            int endIndex = int.Parse(tokens[3]);

            string leftPart = activationKey.Substring(0, startIndex);
            string middlePart = activationKey.Substring(startIndex, endIndex - startIndex);
            string rightPart = activationKey.Substring(endIndex, activationKey.Length - endIndex);

            if (action == "Upper")
            {
                middlePart = middlePart.ToUpper();
            }
            else if (action == "Lower")
            {
                middlePart = middlePart.ToLower();
            }

            activationKey = leftPart + middlePart + rightPart;
            Console.WriteLine(activationKey);
        }

        private static void Contains(string[] tokens)
        {
            string substring = tokens[1];

            if (activationKey.Contains(substring))
            {
                Console.WriteLine($"{activationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }
    }
}
