using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            char oper = char.Parse(Console.ReadLine().Trim());
            double result = 0;
            string typeOfResult = string.Empty;

            if (n2 == 0 && (oper == '/' || oper == '%'))
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
                return;
            }

            switch (oper)
            {
                case '+':
                case '-':
                case '*':

                    result = Operation(n1, n2, oper);
                    typeOfResult = EvenOrOdd(result);
                    Console.WriteLine($"{n1} {oper} {n2} = {result} - {typeOfResult}");

                    break;

                case '/':

                    result = Operation(n1, n2, oper);
                    Console.WriteLine($"{n1} {oper} {n2} = {result:F2}");

                    break;

                case '%':

                    result = Operation(n1, n2, oper);
                    Console.WriteLine($"{n1} {oper} {n2} = {result}");

                    break;
                default:
                    break;
            }
        }

        private static string EvenOrOdd(double result)
        {
            if (result % 2 == 0)
            {
                return "even";
            }
            else
            {
                return "odd";
            }
        }
        private static double Operation(double n1, int n2, char oper)
        {
            double result = 0;
            if (oper == '+')
            {
                result = n1 + n2;
            }
            else if (oper == '-')
            {
                result = n1 - n2;
            }
            else if (oper == '*')
            {
                result = n1 * n2;
            }
            else if (oper == '/')
            {
                result = n1 / n2;
            }
            else if (oper == '%')
            {
                result = n1 % n2;
            }

            return result;
        }
    }
}
