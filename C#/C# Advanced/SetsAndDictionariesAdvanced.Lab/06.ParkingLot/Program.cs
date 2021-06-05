using System;
using System.Collections.Generic;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                string carNumber = tokens[1];

                switch (direction)
                {
                    case "IN":
                        parkingLot.Add(carNumber);
                        break;
                    case "OUT":
                        parkingLot.Remove(carNumber);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid direction!");
                }
            }

            string result = GetResult(parkingLot);
            Console.WriteLine(result);
        }

        private static string GetResult(HashSet<string> parkingLot)
        {
            if (parkingLot.Count == 0)
            {
                return "Parking Lot is Empty";
            }

            return string.Join(Environment.NewLine, parkingLot);
        }
    }
}
