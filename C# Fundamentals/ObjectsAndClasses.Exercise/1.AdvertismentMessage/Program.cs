using System;
using System.Collections.Generic;
using System.Text;

namespace _1.AdvertismentMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = new string[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = new string[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = new string[]
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena", "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities = new string[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            byte numberOfMessages = byte.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfMessages; i++)
            {          
                string message = GetMessage(phrases, events, authors, cities);
                Console.WriteLine(message);
            }
        }

        private static string GetMessage(string[] phrases, string[] events, string[] authors, string[] cities)
        {
            Random rnd = new Random();

            string randomPrase = phrases[rnd.Next(0, phrases.Length)];
            string randomEvent = events[rnd.Next(0, events.Length)];
            string randomAuthor = authors[rnd.Next(0, authors.Length)];
            string randomCity = cities[rnd.Next(0, cities.Length)];

            string message = $"{randomPrase} {randomEvent} {randomAuthor} – {randomCity}";
            return message;
        }
    }
}
