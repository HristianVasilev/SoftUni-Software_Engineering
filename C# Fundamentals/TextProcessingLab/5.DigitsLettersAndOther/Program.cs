using System;
using System.Linq;

namespace _5.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string mandzha = Console.ReadLine();

            string digits = string.Join("", mandzha.Where(c => char.IsDigit(c)));
            string letters = string.Join("", mandzha.Where(c => char.IsLetter(c)));
            string chars = string.Join("", mandzha.Where(c => !char.IsDigit(c) && !char.IsLetter(c)));

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(chars);
        }
    }
}
