using System;
using System.Linq;

namespace _2.ArrayModifier
{
    class Program
    {


        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int index1;
                int index2;

                switch (commandArgs[0])
                {
                    case "swap":
                        index1 = int.Parse(commandArgs[1]);
                        index2 = int.Parse(commandArgs[2]);
                        Swap(ref arr, index1, index2);

                        break;
                    case "multiply":
                        index1 = int.Parse(commandArgs[1]);
                        index2 = int.Parse(commandArgs[2]);
                        Multiply(ref arr, index1, index2);

                        break;
                    case "decrease":
                        Decrease(ref arr);

                            break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            Console.WriteLine(string.Join(", ",arr));
        }

        private static void Decrease(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] -= 1;
            }
        }

        private static void Multiply(ref int[] arr, int index1, int index2)
        {
            arr[index1] *= arr[index2];
        }

        private static void Swap(ref int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}
