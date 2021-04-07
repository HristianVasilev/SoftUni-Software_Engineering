using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkipRope
{
    class Program
    {
        private static List<int> numbers;
        private static List<string> nonNumbers;

        static void Main(string[] args)
        {
            numbers = new List<int>();
            nonNumbers = new List<string>();

            string input = Console.ReadLine();

            numbers = input.ToCharArray().Where(x => char.IsDigit(x)).Select(x => int.Parse(x.ToString())).ToList();
            nonNumbers = input.ToCharArray().Where(x => !char.IsDigit(x)).Select(x => x.ToString()).ToList();

            string output = TakeAndSkip();
            Console.WriteLine(output);
        }

        private static string TakeAndSkip()
        {
            List<int> takeList = GetEven(true);
            List<int> skipList = GetEven(false);

            int length = Math.Max(takeList.Count, skipList.Count);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int take = takeList[i];
                int skip = skipList[i];

                string takePart = string.Join("", nonNumbers.Take(take));

                sb.Append(takePart);

                int countOfRemove = Math.Min(take + skip, nonNumbers.Count);
                nonNumbers.RemoveRange(0, countOfRemove);
            }

            return sb.ToString().TrimEnd();
        }

        private static List<int> GetEven(bool v)
        {
            List<int> resultList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0 && v)
                {
                    resultList.Add(numbers[i]);
                }
                else if (i % 2 != 0 && !v)
                {
                    resultList.Add(numbers[i]);
                }
            }

            return resultList;
        }
    }
}
