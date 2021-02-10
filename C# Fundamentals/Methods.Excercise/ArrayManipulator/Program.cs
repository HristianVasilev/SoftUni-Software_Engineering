using System;
using System.Linq;
using System.Text;

namespace ArrayManipulator
{
    class Program
    {
        private static int[] array;

        static void Main(string[] args)
        {
            array = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string typeOfdigits;
                int countOfIntegers;

                switch (tokens[0])
                {
                    case "exchange":
                        int index = int.Parse(tokens[1]);
                        Exchange(index);

                        break;
                    case "max":
                        typeOfdigits = tokens[1];
                        Max(typeOfdigits);

                        break;
                    case "min":
                        typeOfdigits = tokens[1];
                        Min(typeOfdigits);

                        break;
                    case "first":
                        countOfIntegers = int.Parse(tokens[1]);
                        typeOfdigits = tokens[2];
                        First(countOfIntegers, typeOfdigits);

                        break;
                    case "last":
                        countOfIntegers = int.Parse(tokens[1]);
                        typeOfdigits = tokens[2];
                        Last(countOfIntegers, typeOfdigits);

                        break;

                    default:
                        throw new InvalidOperationException();
                }

            }

            Console.WriteLine($"[{string.Join(", ", array)}]");
        }


        //Last

        private static void Last(int countOfIntegers, string typeOfdigits)
        {
            if (countOfIntegers > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] arr;
            switch (typeOfdigits)
            {
                case "even":
                    arr = LastEven(countOfIntegers);

                    break;
                case "odd":
                    arr = LastOdd(countOfIntegers);

                    break;
                default:
                    throw new InvalidOperationException();
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static int[] LastOdd(int countOfIntegers)
        {
            int[] result = new int[countOfIntegers];
            byte resultCounter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    continue;
                }

                result[resultCounter++] = array[i];
                if (resultCounter == result.Length)
                {
                    break;
                }
            }

            if (resultCounter != result.Length)
            {
                result = DeleteZeroes(result,resultCounter);
            }

            return result.Reverse().ToArray();
        }

        private static int[] LastEven(int countOfIntegers)
        {
            int[] result = new int[countOfIntegers];
            byte resultCounter = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    continue;
                }

                result[resultCounter++] = array[i];
                if (resultCounter == result.Length)
                {
                    break;
                }
            }


            if (resultCounter != result.Length)
            {
                result = DeleteZeroes(result,resultCounter);
            }

            return result.Reverse().ToArray();
        }



        //First
        private static void First(int countOfIntegers, string typeOfdigits)
        {
            if (countOfIntegers > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            int[] arr;
            switch (typeOfdigits)
            {
                case "even":
                    arr = FirstEven(countOfIntegers);

                    break;
                case "odd":
                    arr = FirstOdd(countOfIntegers);

                    break;
                default:
                    throw new InvalidOperationException();
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static int[] FirstOdd(int countOfIntegers)
        {
            int[] result = new int[countOfIntegers];
            byte resultCounter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    continue;
                }

                result[resultCounter++] = array[i];
                if (resultCounter == result.Length)
                {
                    break;
                }
            }

            if (resultCounter != result.Length)
            {
                result = DeleteZeroes(result,resultCounter);
            }

            return result.ToArray();
        }

        private static int[] FirstEven(int countOfIntegers)
        {
            int[] result = new int[countOfIntegers];
            byte resultCounter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    continue;
                }

                result[resultCounter++] = array[i];
                if (resultCounter == result.Length)
                {
                    break;
                }
            }

            if (resultCounter != result.Length)
            {
                result = DeleteZeroes(result,resultCounter);
            }

            return result.ToArray();
        }

        //Min

        private static void Min(string typeOfdigits)
        {
            int index;

            switch (typeOfdigits)
            {
                case "even":
                    index = MinEvenIndex();

                    break;
                case "odd":
                    index = MinOddIndex();

                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static int MinOddIndex()
        {
            int minValue = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    continue;
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                    index = i;
                }
                else if (array[i] == minValue)
                {
                    index = i;
                }
            }

            return index;
        }

        private static int MinEvenIndex()
        {
            int minValue = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    continue;
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                    index = i;
                }
                else if (array[i] == minValue)
                {
                    index = i;
                }
            }

            return index;
        }



        //Max

        private static void Max(string typeOfdigits)
        {
            int index;

            switch (typeOfdigits)
            {
                case "even":
                    index = MaxEvenIndex();

                    break;
                case "odd":
                    index = MaxOddIndex();

                    break;
                default:
                    throw new InvalidOperationException();
            }

            if (index == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static int MaxOddIndex()
        {
            int maxValue = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    continue;
                }

                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    index = i;
                }
                else if (array[i] == maxValue)
                {
                    index = i;
                }
            }

            return index;
        }

        private static int MaxEvenIndex()
        {
            int maxValue = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    continue;
                }

                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    index = i;
                }
                else if (array[i] == maxValue)
                {
                    index = i;
                }
            }

            return index;
        }


        //Exchange

        private static void Exchange(int index)
        {
            if (index < 0 || index > array.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return;
            }


            int[] tempOne = new int[index + 1];
            for (int i = 0; i <= index; i++)
            {
                tempOne[i] = array[i];
            }

            int[] tempTwo = new int[array.Length - index - 1];
            byte counterForTempTwo = 0;
            for (int i = index + 1; i < array.Length; i++)
            {
                tempTwo[counterForTempTwo++] = array[i];
            }


            //Fill the array
            int j;
            for (j = 0; j < tempTwo.Length; j++)
            {
                array[j] = tempTwo[j];
            }

            byte counterForTempOne = 0;
            for (int i = j; i < array.Length; i++)
            {
                array[i] = tempOne[counterForTempOne++];
            }
        }


        private static int[] DeleteZeroes(int[] arr, int count)
        {
            int[] result = new int[count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arr[i];
            }

            return result;
        }

    }
}
