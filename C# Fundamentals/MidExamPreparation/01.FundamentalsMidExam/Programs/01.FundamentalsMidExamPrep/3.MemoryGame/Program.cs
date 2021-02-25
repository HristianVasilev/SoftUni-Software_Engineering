using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = new List<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            byte moves = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int indexOne = int.Parse(commandArgs[0]);
                int indexTwo = int.Parse(commandArgs[1]);

                moves++;

                if ((indexOne < 0 || indexTwo < 0) || (indexOne == indexTwo))
                {
                    InvalidIndex(ref sequence, moves);
                    continue;
                }

                if (sequence[indexOne] != sequence[indexTwo])
                {
                    Console.WriteLine("Try again!");
                    continue;
                }



                if (sequence[indexOne] == sequence[indexTwo])
                {
                    MatchingElements(ref sequence, indexOne, indexTwo);
                }

                if (sequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    return;
                }
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(' ', sequence));
            return;
        }

        private static void MatchingElements(ref List<string> sequence, int indexOne, int indexTwo)
        {
            string element = sequence[indexOne];

            sequence.Remove(element);
            sequence.Remove(element);

            Console.WriteLine($"Congrats! You have found matching elements - {element}!");
        }

        private static void InvalidIndex(ref List<string> sequence, int moves)
        {
            int middleIndex = sequence.Count / 2;

            string item = $"-{moves}a";
            IEnumerable<string> collection = new string[] { item, item };

            sequence.InsertRange(middleIndex, collection);
            Console.WriteLine("Invalid input! Adding additional elements to the board");
        }
    }
}
