using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();

                switch (action)
                {
                    case "Chat":
                        Chat(ref chat, commandArgs);

                        break;
                    case "Delete":
                        Delete(ref chat, commandArgs);

                        break;
                    case "Edit":
                        Edit(ref chat, commandArgs);

                        break;
                    case "Pin":
                        Pin(ref chat, commandArgs);

                        break;
                    case "Spam":
                        Spam(ref chat, commandArgs);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            PrintChatHistory(ref chat);
        }

        private static void PrintChatHistory(ref List<string> chat)
        {
            Console.WriteLine(string.Join(Environment.NewLine, chat));
        }

        private static void Spam(ref List<string> chat, string[] commandArgs)
        {
            for (int i = 0; i < commandArgs.Length; i++)
            {
                string message = commandArgs[i];
                chat.Add(message);
            }
        }

        private static void Pin(ref List<string> chat, string[] commandArgs)
        {
            string message = commandArgs[0];

            bool isRemoved = chat.Remove(message);

            if (isRemoved)
            {
                chat.Add(message);
            }
        }

        private static void Edit(ref List<string> chat, string[] commandArgs)
        {
            string messageToEdit = commandArgs[0];
            string editedVersion = commandArgs[1];

            int indexOfMessage = chat.IndexOf(messageToEdit);
            chat[indexOfMessage] = editedVersion;
        }

        private static void Delete(ref List<string> chat, string[] commandArgs)
        {
            string messageToDelete = commandArgs[0];

            chat.Remove(messageToDelete);
        }

        private static void Chat(ref List<string> chat, string[] commandArgs)
        {
            string message = commandArgs[0];

            chat.Add(message);
        }
    }
}
