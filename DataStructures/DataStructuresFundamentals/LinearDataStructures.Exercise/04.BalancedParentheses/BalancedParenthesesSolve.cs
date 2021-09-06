namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (parentheses.Length % 2 != 0)
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                char symbol = parentheses[i];

                switch (symbol)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(symbol);

                        break;
                    case ')':
                    case ']':
                    case '}':

                        char lastSymbol = stack.Pop();
                        bool matches = Matches(lastSymbol, symbol);

                        if (!matches)
                        {
                            return false;
                        }

                        break;
                    default:
                        throw new ArgumentException("Invalid type of paranthess!");
                }
            }

            return true;
        }

        private bool Matches(char leftSymbol, char rightSymbol)
        {
            bool option1 = leftSymbol == '(' && rightSymbol == ')';
            bool option2 = leftSymbol == '[' && rightSymbol == ']';
            bool option3 = leftSymbol == '{' && rightSymbol == '}';

            return option1 || option2 || option3;
        }
    }
}
