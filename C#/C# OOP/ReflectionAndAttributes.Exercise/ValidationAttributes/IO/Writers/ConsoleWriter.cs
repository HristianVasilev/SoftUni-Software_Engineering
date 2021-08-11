namespace ValidationAttributes.IO.Writers
{
    using System;

    class ConsoleWriter : IWriter
    {
        public void Write(object text)
        {
            Console.WriteLine(text);
        }
    }
}
