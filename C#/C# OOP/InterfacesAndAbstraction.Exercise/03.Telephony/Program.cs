using System;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] webAdresses = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            CallNumbers(phoneNumbers);
            BrowseWeb(webAdresses);
        }

        private static void BrowseWeb(string[] webAdresses)
        {
            foreach (var url in webAdresses)
            {
                string result;

                try
                {
                    if (url.Any(c => char.IsDigit(c)))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }

                    IBrowsable phone = new Smartphone();
                    result = phone.Browse(url);
                }
                catch (ArgumentException ex)
                {
                    result = ex.Message;
                }

                Console.WriteLine(result);
            }
        }

        private static void CallNumbers(string[] phoneNumbers)
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                string result;

                try
                {

                    if (phoneNumber.Any(c => !char.IsDigit(c)))
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    ICallable phone;

                    if (phoneNumber.Length == 10)
                    {
                        phone = new Smartphone();
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    result = phone.Call(phoneNumber);

                }
                catch (ArgumentException ex)
                {
                    result = ex.Message;
                }

                Console.WriteLine(result);
            }
        }
    }
}
