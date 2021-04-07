using System;
using System.Linq;
using System.Text;

namespace _3.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input;
            while ((input = Console.ReadLine()) != "find")
            {
                string word = input;

                int counter = 0;

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < word.Length; i++)
                {
                    if (counter == key.Length)
                    {
                        counter = 0;
                    }

                    sb.Append((char)(word[i] - key[counter++]));
                }

                string found = sb.ToString().TrimEnd();

                string type = SelectType(found, '&');
                string coordinates = SelectCoordinates(found, '<', '>');

                Console.WriteLine($"Found {type} at {coordinates}");
            }

        }

        private static string SelectCoordinates(string found, char v1, char v2)
        {
            int first = found.IndexOf(v1);
            int last = found.LastIndexOf(v2);

            StringBuilder sb = new StringBuilder();

            for (int i = first + 1; i < last; i++)
            {
                sb.Append((char)(found[i]));
            }

            return sb.ToString().TrimEnd();
        }

        private static string SelectType(string found, char symbol)
        {
            int firstIndex = found.IndexOf(symbol);
            int secondIndex = found.LastIndexOf(symbol);

            StringBuilder sb = new StringBuilder();

            for (int i = firstIndex + 1; i < secondIndex; i++)
            {
                sb.Append((char)(found[i]));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
