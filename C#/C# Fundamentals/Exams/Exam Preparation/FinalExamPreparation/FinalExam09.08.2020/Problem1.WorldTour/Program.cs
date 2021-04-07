using System;

namespace Problem1.WorldTour
{
    class Program
    {
        private static string text;

        static void Main(string[] args)
        {
            text = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] tokens = command.Split(':', StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Add Stop":
                        AddStop(tokens);
                        break;
                    case "Remove Stop":
                        RemoveStop(tokens);
                        break;
                    case "Switch":
                        Switch(tokens);
                        break;
                    default:
                        throw new NotImplementedException("Invalid command!");
                }

                Console.WriteLine(text);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }

        private static void Switch(string[] tokens)
        {
            string oldString = tokens[1];
            string newString = tokens[2];

            if (text.Contains(oldString))
            {
                text = text.Replace(oldString, newString);
            }
        }

        private static void RemoveStop(string[] tokens)
        {
            byte startIndex = byte.Parse(tokens[1]);
            byte endIndex = byte.Parse(tokens[2]);

            if (ValidIndex(startIndex) && ValidIndex(endIndex))
            {
                byte count = (byte)(endIndex - startIndex + 1);
                text = text.Remove(startIndex, count);
            }
        }

        private static void AddStop(string[] tokens)
        {
            byte index = byte.Parse(tokens[1]);

            if (ValidIndex(index))
            {
                string newString = tokens[2];

                text = text.Insert(index, newString);
            }
        }

        private static bool ValidIndex(byte index)
        {
            return index >= 0 && index < text.Length;
        }
    }
}
