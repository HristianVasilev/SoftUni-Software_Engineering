using System;
using System.Linq;

namespace _1.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var username in usernames)
            {
                if (ValidUsername(username))
                {
                    Console.WriteLine(username);
                }
            }
        }

        private static bool ValidUsername(string username)
        {
            bool betweenRange = username.Length >= 3 && username.Length <= 16;

            if (!betweenRange)
            {
                return false;
            }

            bool containsDifferentFromLettersAndDigits = username.Any(c => !char.IsLetterOrDigit(c));

            if (containsDifferentFromLettersAndDigits)
            {
                char[] diff = username.Where(c => !char.IsLetterOrDigit(c)).ToArray();

                if (diff.Any(c => c != '-' && c != '_'))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
