using System;
using System.Collections.Generic;
using System.Text;

namespace _05.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            byte n = byte.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            string result = GetResult(names);
            Console.WriteLine(result);
        }

        private static string GetResult(HashSet<string> names)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var name in names)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
