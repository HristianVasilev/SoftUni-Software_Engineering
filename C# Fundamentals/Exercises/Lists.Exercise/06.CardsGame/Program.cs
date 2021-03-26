using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (firstHand.Count > 0 && secondHand.Count > 0)
            {
                int firstCard = firstHand[0];
                int secondCard = secondHand[0];

                firstHand.RemoveAt(0);
                secondHand.RemoveAt(0);

                if (firstCard > secondCard)
                {
                    firstHand.Add(firstCard);
                    firstHand.Add(secondCard);
                }
                else if(firstCard < secondCard)
                {
                    secondHand.Add(secondCard);
                    secondHand.Add(firstCard);
                }
            }

            string winner;
            int totalResult;

            if (secondHand.Count == 0)
            {
                winner = "First";
                totalResult = firstHand.Sum();
            }
            else
            {
                winner = "Second";
                totalResult = secondHand.Sum();
            }

            Console.WriteLine($"{winner} player wins! Sum: {totalResult}");
        }
    }
}
