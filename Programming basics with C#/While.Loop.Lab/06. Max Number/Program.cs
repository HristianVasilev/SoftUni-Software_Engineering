using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = int.MinValue;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Stop")
            {
                int current = int.Parse(input);
                if (current>max)
                {
                    max = current;
                }
            }
            Console.WriteLine(max);
        }
    }
}
