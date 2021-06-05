using System;
using System.Collections.Generic;
using System.Text;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> reservations = new List<string>();

            bool add = true;

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (input == "PARTY")
                {
                    add = false;
                    continue;
                }

                if (input == "END")
                {
                    break;
                }

                if (add)
                {
                    reservations.Add(input);
                }
                else
                {
                    reservations.Remove(input);
                }
            }

            string result = GetResult(reservations);
            Console.WriteLine(result);
        }

        private static string GetResult(List<string> reservations)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{reservations.Count}");

            if (reservations.Count == 0)
            {
                return sb.ToString().TrimEnd();
            }

            List<string> vipGuests = new List<string>();
            List<string> guests = new List<string>();

            foreach (var guestNo in reservations)
            {
                if (char.IsDigit(guestNo[0]))
                {
                    vipGuests.Add(guestNo);
                }
                else
                {
                    guests.Add(guestNo);
                }
            }

            if (vipGuests.Count > 0)
            {
                foreach (var vipGuest in vipGuests)
                {
                    sb.AppendLine(vipGuest);
                }
            }

            foreach (var guest in guests)
            {
                sb.AppendLine(guest);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
