namespace ValidationAttributes.IO.Readers
{
    using System;

    class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
