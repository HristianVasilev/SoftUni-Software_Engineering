using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.MorseCodeTranslator
{
    class Program
    {
        private static Dictionary<string, string> morse;

        static void Main(string[] args)
        {
            morse = new Dictionary<string, string>()
            {
                {"A",".-"},
                {"B","-..."},
                {"C","-.-."},
                {"D","-.."},
                {"E","."},
                {"F","..-."},
                {"G","--."},
                {"H","...."},
                {"I",".."},
                {"J",".---"},
                {"K","-.-"},
                {"L",".-.."},
                {"M","--"},
                {"N","-."},
                {"O","---"},
                {"P",".--."},
                {"Q","--.-"},
                {"R",".-."},
                {"S","..."},
                {"T","-"},
                {"U","..-"},
                {"V","...-"},
                {"W",".--"},
                {"X","-..-"},
                {"Y","-.--"},
                {"Z","--.."},
            };

            string[] morseCodeTokens = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var word in morseCodeTokens)
            {
                string translation = Translate(word);
                sb.Append(translation + ' ');
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static string Translate(string word)
        {
            string[] letters = word.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var letter in letters)
            {
                string translatedLetter = morse.First(x => x.Value == letter).Key;
                sb.Append(translatedLetter);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
