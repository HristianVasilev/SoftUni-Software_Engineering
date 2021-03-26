using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            Calculate(command, firstNumber, secondNumber);
        }

        private static void Calculate(string command, int firstNumber, int secondNumber)
        {
            double result;
            switch (command)
            {
                case "add":
                    result = Sum(firstNumber, secondNumber);

                    break;
                case "multiply":
                    result = Multiply(firstNumber, secondNumber);

                    break;
                case "subtract":
                    result = Subtract(firstNumber, secondNumber);

                    break;
                case "divide":
                    result = Divide(firstNumber, secondNumber);

                    break;
                default:
                    throw new NotImplementedException();
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
