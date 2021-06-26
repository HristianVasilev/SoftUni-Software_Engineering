using System;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string createCommand = Console.ReadLine();
            ListyIterator<string> listy = Create(createCommand);

            try
            {
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                        case "Print":
                            listy.Print();
                            break;
                        case "PrintAll":
                            listy.PrintAll();
                            break;

                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintAll(ListyIterator<string> listy)
        {
            foreach (var item in listy)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        private static ListyIterator<string> Create(string createCommand)
        {
            string[] tokens = createCommand.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] != "Create")
            {
                throw new InvalidOperationException("Invalid command!");
            }

            string[] items = tokens.Skip(1).ToArray();

            return new ListyIterator<string>(items);
        }

    }
}
