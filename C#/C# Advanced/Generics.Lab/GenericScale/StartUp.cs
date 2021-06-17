using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(1, 10);
            Console.WriteLine(equalityScale.AreEqual());

            EqualityScale<string> str = new EqualityScale<string>("None", "None");
            Console.WriteLine(str.AreEqual());
        }
    }
}
