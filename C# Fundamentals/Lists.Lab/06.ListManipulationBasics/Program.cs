using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequenceOfNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                int number;
                int index; 

                switch (command)
                {
                    case "Add":

                        number = int.Parse(tokens[1]);
                        sequenceOfNumbers.Add(number);
                            
                        break;
                    case "Remove":

                        number = int.Parse(tokens[1]);
                        sequenceOfNumbers.Remove(number);

                        break;
                    case "RemoveAt":

                        index = int.Parse(tokens[1]);
                        sequenceOfNumbers.RemoveAt(index);

                        break;
                    case "Insert":

                        number = int.Parse(tokens[1]);
                        index = int.Parse(tokens[2]);
                        sequenceOfNumbers.Insert(index, number);

                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }


            Console.WriteLine(string.Join(' ',sequenceOfNumbers));
        }
    }
}
