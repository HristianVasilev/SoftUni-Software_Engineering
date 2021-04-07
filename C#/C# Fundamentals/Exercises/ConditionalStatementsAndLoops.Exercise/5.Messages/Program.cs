using System;
using System.Runtime.ExceptionServices;

namespace _5.Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string two = "abc";
            string three = "def";
            string four = "ghi";
            string five = "jkl";
            string six = "mno";
            string seven = "pqrs";
            string eight = "tuv";
            string nine = "wxyz";
            string zero = " ";

            char sym = '0';
            string message = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string comb = Console.ReadLine();
                for (int j = 0; j < comb.Length; j++)
                {
                    if (j > 0)
                    {
                        char previousSym = sym;
                        sym = comb[j];
                        if (previousSym != sym)
                        {
                            Console.WriteLine("Invalid number!");
                            return;
                        }
                    }
                    else
                    {
                        sym = comb[j];
                    }
                }
                switch (sym)
                {
                    case '2':
                        message += two[comb.Length - 1];
                        break;
                    case '3':
                        message += three[comb.Length - 1];
                        break;
                    case '4':
                        message += four[comb.Length - 1];
                        break;
                    case '5':
                        message += five[comb.Length - 1];
                        break;
                    case '6':
                        message += six[comb.Length - 1];
                        break;
                    case '7':
                        message += seven[comb.Length - 1];
                        break;
                    case '8':
                        message += eight[comb.Length - 1];
                        break;
                    case '9':
                        message += nine[comb.Length - 1];
                        break;
                    case '0':
                        message += zero;
                        break;
                }
            }
            Console.WriteLine(message);
        }
    }
}
