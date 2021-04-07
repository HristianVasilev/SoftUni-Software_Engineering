using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();

            string input = string.Empty;
            int counter = 0;
            while ((input = Console.ReadLine()) != book)
            {
                if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    return;
                }
                counter++;
            }
            Console.WriteLine($"You checked {counter} books and found it.");
        }
    }
}
