using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Queue<char> leftPart = new Queue<char>(input.ToCharArray().Take(input.Length / 2));
            Stack<char> rightPart = new Stack<char>(input.ToCharArray().TakeLast(input.Length / 2));

            string output = CompareParts(leftPart, rightPart);
            Console.WriteLine(output);
        }

        private static string CompareParts(Queue<char> leftPart, Stack<char> rightPart)
        {
            while (leftPart.Count > 0 && rightPart.Count > 0)
            {
                char currentLeftPart = leftPart.Dequeue();
                char currentRightPart = rightPart.Pop();

                bool bigBrackets = currentLeftPart == '{' && currentRightPart == '}';
                bool middleBrackets = currentLeftPart == '[' && currentRightPart == ']';
                bool smallBrackets = currentLeftPart == '(' && currentRightPart == ')';

                bool balance = bigBrackets || middleBrackets || smallBrackets;

                if (!balance)
                {
                    return "NO";
                }
            }

            return "YES";
        }
    }
}
