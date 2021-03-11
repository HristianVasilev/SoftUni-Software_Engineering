using System;
using System.Text;

namespace _2.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StringBuilder sb = new StringBuilder();

            foreach (var item in array)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    sb.Append(item);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
