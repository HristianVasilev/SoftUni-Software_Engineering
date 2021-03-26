using System;

namespace CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] secondArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string result = string.Empty;

            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    bool areEaqual = secondArray[i] == firstArray[j];
                    if (areEaqual)
                    {
                        result += $"{secondArray[i]} ";
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
