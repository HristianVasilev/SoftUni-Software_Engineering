using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = int.MaxValue;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                double current = double.Parse(input);
                if (current < min)
                {
                    min = current;
                }
            }
            Console.WriteLine(min);
        }
    }
}
