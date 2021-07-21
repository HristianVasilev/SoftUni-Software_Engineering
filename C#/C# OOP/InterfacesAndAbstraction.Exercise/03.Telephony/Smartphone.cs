using System;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            return $"Calling... {phoneNumber}";
        }
    }
}
