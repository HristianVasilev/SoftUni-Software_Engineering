using System;
using System.Linq;

namespace _1.ExtractPersonInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            byte count = byte.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] stringLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = stringLine
                    .First(x => x.Any(c => c == '@') && x.Any(c => c == '|'))
                    .Trim(new char[] { '@', '|' });
                
                string age = stringLine
                    .First(x => x.Any(c => c == '#') && x.Any(c => c == '*'))
                    .Trim(new char[] { '#', '*' });

                Console.WriteLine($"{name} is {age} years old.");
            }
        }

    }
}
