using System;

namespace Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string output = null;

            if (n >=0 && n <=2)
            {
                output = "baby";
            }
            else if (n > 2 && n <= 13)
            {
                output = "child";
            }
            else if (n > 13 && n <= 19)
            {
                output = "teenager";
            }
            else if (n > 19 && n <= 65)
            {
                output = "adult";
            }
            else if (n > 65 )
            {
                output = "elder";
            }

            Console.WriteLine(output);
        }
    }
}
