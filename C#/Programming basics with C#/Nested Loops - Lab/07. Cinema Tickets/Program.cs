using System;

namespace _07._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            byte students = 0;
            byte standard = 0;
            byte kid = 0;
            byte counter = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Finish")
            {
                string movie = input;
                byte seats = byte.Parse(Console.ReadLine());
                byte capacity = seats;

                string command = string.Empty;
                while (capacity > 0)
                {
                    command = Console.ReadLine();
                    if (command == "End" || command == "Finish")
                    {
                        break;
                    }
                    counter++;
                    capacity--;

                    switch (command)
                    {
                        case "student":
                            students++;
                            break;
                        case "standard":
                            standard++;
                            break;
                        case "kid":
                            kid++;
                            break;
                    }
                }
                Console.WriteLine($"{movie} - {((seats - capacity) * 1.0 / seats * 100):f2}% full.");
                if (command == "Finish")
                {
                    break;
                }
            }
            Console.WriteLine($"Total tickets: {counter}");
            Console.WriteLine($"{(students * 1.0 / counter * 100):f2}% student tickets.");
            Console.WriteLine($"{(standard * 1.0 / counter * 100):f2}% standard tickets.");
            Console.WriteLine($"{(kid * 1.0 / counter * 100):f2}% kids tickets.");
        }
    }
}
