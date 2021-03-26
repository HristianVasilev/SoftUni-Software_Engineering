using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Calculate(firstNumber, operation, secondNumber);
        }

        private static void Calculate(int firstNumber, char operation, int secondNumber)
        {
            double result;

            switch (operation)
            {
                case '/':
                    result = Divide(firstNumber, secondNumber);

                    break;
                case '*':
                    result = Multiply(firstNumber, secondNumber);

                    break;
                case '+':
                    result = Sum(firstNumber, secondNumber);

                    break;
                case '-':
                    result = Subtract(firstNumber, secondNumber);

                    break;

                default:
                    throw new InvalidOperationException();
            }

            Console.WriteLine(result);
        }

        private static double Divide(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }

        private static double Subtract(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        private static double Multiply(int firstNumber, int secondNumber)
        {
            return firstNumber * secondNumber;
        }

        private static double Sum(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
