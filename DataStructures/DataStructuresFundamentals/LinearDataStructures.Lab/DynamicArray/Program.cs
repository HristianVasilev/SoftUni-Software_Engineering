using System;
using System.Collections.Generic;

namespace DynamicArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            DynamicArr<int> dynamicArr = new DynamicArr<int>();

            dynamicArr.Add(5);
            dynamicArr.Add(4);
            dynamicArr.Add(3);
            dynamicArr.Add(2);
            dynamicArr.Add(1);

            //IEnumerable<int> collection = new int[] { 10, 20, 30 };

            //dynamicArr.AddRange(collection);

            //Console.WriteLine($"Array count: {dynamicArr.Count}");
            //Console.WriteLine($"Array capacity: {dynamicArr.Capacity}");
            //Console.WriteLine($"Dynamic array is: {string.Join(", ", dynamicArr)}");

            //dynamicArr.Clear();

            //Console.WriteLine($"Array count: {dynamicArr.Count}");
            //Console.WriteLine($"Array capacity: {dynamicArr.Capacity}");
            //Console.WriteLine($"Dynamic array is: {string.Join(", ", dynamicArr)}");

            Console.WriteLine(dynamicArr.Exists(x => x == 0));

        }
    }
}
