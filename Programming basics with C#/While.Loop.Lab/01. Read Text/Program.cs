using System;

namespace _01._Read_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop")
            {
                Console.WriteLine(input);
            }
        }
    }
}
