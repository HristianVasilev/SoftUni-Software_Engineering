using System;
using System.Collections.Generic;

namespace Exam.MobileX
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehicleRepository vehicleRepository = new VehicleRepository();

            Vehicle vehicle1 = new Vehicle("aaa", "bb", "mm", "LL", "Black", 50, 1000, true);
            Vehicle vehicle2 = new Vehicle("aa", "bb", "mm", "LL", "Black", 50, 500, true);
            Vehicle vehicle3 = new Vehicle("a", "bb", "mm", "LL", "Black", 50, 800, false);
            Vehicle vehicle4 = new Vehicle("abb", "bb", "mm", "LL", "Black", 50, 300, false);

            vehicleRepository.AddVehicleForSale(vehicle1, "Pesho");
            vehicleRepository.AddVehicleForSale(vehicle2, "Pesho");
            vehicleRepository.AddVehicleForSale(vehicle3, "Pen4o");
            vehicleRepository.AddVehicleForSale(vehicle4, "Misho");

            List<string> keywords = new List<string>(new string[] { "aaa", "bb", "mm", "LL", "Black" });

            var collection = vehicleRepository.GetVehicles(keywords);
            foreach (var v  in collection)
            {
                Console.WriteLine($"{v.Price} - {v.IsVIP}");
            }

            vehicleRepository.GetVehiclesBySeller("Pesho");
        }
    }
}
