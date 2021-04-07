using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            byte digit = byte.Parse(Console.ReadLine());

            if (digit == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<int> array = new List<int>();
            NubmerToArray(number, array);

            while (array[0] == 0)
            {
                array.RemoveAt(0);
            }

            int balance = 0;

            List<int> product = new List<int>();


            for (int i = array.Count - 1; i >= 0; i--)
            {
                product.Add(((array[i] * digit) + balance) % 10);

                balance = (array[i] * digit + balance) / 10;
            }

            if (balance > 0)
            {
                product.Add(balance);
            }
            product.Reverse();
            Console.WriteLine(String.Join("", product));

        }

        private static void NubmerToArray(string number, List<int> list)
        {
            for (int i = 0; i < number.Length; i++)
            {
                list.Add(int.Parse((number[i]).ToString()));
            }
        }
    }
}
