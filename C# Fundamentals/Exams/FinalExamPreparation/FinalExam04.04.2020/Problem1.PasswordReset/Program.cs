using System;
using System.Linq;
using System.Text;

namespace Problem1.PasswordReset
{
    class Program
    {

        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "TakeOdd":
                        TakeOdd(tokens, ref password);
                        break;
                    case "Cut":
                        Cut(tokens, ref password);
                        break;
                    case "Substitute":
                        Substitute(tokens, ref password);
                        break;

                    default:
                        throw new NotImplementedException("Invalid command!");
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        private static void Substitute(string[] tokens, ref string password)
        {
            string substring = tokens[1];
            string substitute = tokens[2];

            if (password.Contains(substring))
            {
                while (password.Contains(substring))
                {
                    password = password.Replace(substring, substitute);
                }

                Console.WriteLine(password);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }
        }

        private static void Cut(string[] tokens, ref string password)
        {
            byte index = byte.Parse(tokens[1]);
            byte length = byte.Parse(tokens[2]);

            password = password.Remove(index, length);
            Console.WriteLine(password);
        }

        private static void TakeOdd(string[] tokens, ref string password)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(password[i]);
                }
            }

            password = sb.ToString().Trim();
            Console.WriteLine(password);
        }
    }
}
