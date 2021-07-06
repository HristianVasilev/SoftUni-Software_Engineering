using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stackOfStrings = new StackOfStrings();

            Console.WriteLine(stackOfStrings.IsEmpty());
            stackOfStrings.AddRange(new string[] { "A", "B", "C" });
            Console.WriteLine(stackOfStrings.IsEmpty());
        }
    }
}
