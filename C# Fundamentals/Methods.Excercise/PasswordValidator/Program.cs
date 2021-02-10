using System;
using System.Text;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string validator = PasswordValidator(password);
            Console.WriteLine(validator);
        }

        private static string PasswordValidator(string password)
        {
            bool validCountOfCharacters = IsBetweenRange(password, 6, 10);
            bool consistsOnlyLettersAndDigits = CheckTheCharacters(password);
            bool haveAtLeastTwoDigits = CheckIfHaveAtLeastTwoDigits(password);

            if (validCountOfCharacters && consistsOnlyLettersAndDigits && haveAtLeastTwoDigits)
            {
                return "Password is valid";
            }

            StringBuilder sb = new StringBuilder();

            if (!validCountOfCharacters)
            {
                sb.AppendLine("Password must be between 6 and 10 characters");
            }

            if (!consistsOnlyLettersAndDigits)
            {
                sb.AppendLine("Password must consist only of letters and digits");
            }

            if (!haveAtLeastTwoDigits)
            {
                sb.AppendLine("Password must have at least 2 digits");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool CheckIfHaveAtLeastTwoDigits(string password)
        {
            int countOfDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    countOfDigits++;
                }
            }

            if (countOfDigits < 2)
            {
                return false;
            }
            return true;
        }

        private static bool CheckTheCharacters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (!(char.IsDigit(password[i]) || char.IsLetter(password[i])))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsBetweenRange(string password, int lowerlimit, int highestLimit)
        {
            return password.Length >= lowerlimit && password.Length <= highestLimit;
        }
    }
}
