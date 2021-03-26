using System;
using System.Linq;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = null;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }

            for (int i = 0; i < 4; i++)
            {
                string signPassword = Console.ReadLine();

                if (signPassword == password)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else
                {
                    if (i == 3)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }

        }
    }
}
