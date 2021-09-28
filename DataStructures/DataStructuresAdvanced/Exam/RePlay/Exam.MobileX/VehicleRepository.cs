using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
    public class VehicleRepository : IVehicleRepository
    {
        private Dictionary<string, Vehicle> vehicles;
        private Dictionary<string, ISet<string>> sellersVehicles;
        private Dictionary<string, string> vehicleSeller;
        private Dictionary<string, ISet<string>> vehiclesByBrand;


        public VehicleRepository()
        {
            this.vehicles = new Dictionary<string, Vehicle>();
            this.sellersVehicles = new Dictionary<string, ISet<string>>();
            this.vehicleSeller = new Dictionary<string, string>();
            this.vehiclesByBrand = new Dictionary<string, ISet<string>>();
        }


        public int Count => this.vehicles.Count;


        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (this.Contains(vehicle))
                throw new ArgumentException();

            this.vehicles.Add(vehicle.Id, vehicle);
            this.vehicleSeller.Add(vehicle.Id, sellerName);

            if (!this.ContainsSeller(sellerName))
                this.sellersVehicles.Add(sellerName, new SortedSet<string>());

            this.sellersVehicles[sellerName].Add(vehicle.Id);

            if (!this.vehiclesByBrand.ContainsKey(vehicle.Brand))
                this.vehiclesByBrand.Add(vehicle.Brand, new SortedSet<string>());

            this.vehiclesByBrand[vehicle.Brand].Add(vehicle.Id);
        }

        public bool Contains(Vehicle vehicle)
        {
            return this.vehicles.ContainsKey(vehicle.Id);
        }

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
        {
            IOrderedEnumerable<string> w = keywords.OrderBy(x => x);

            IEnumerable<Vehicle> vehicles = this.vehicles.Values
                .Where(vehicle => w.Contains(vehicle.Brand)
                    || w.Contains(vehicle.Model)
                    || w.Contains(vehicle.Location)
                    || w.Contains(vehicle.Color));

            if (vehicles.Count() == 0)
                return Enumerable.Empty<Vehicle>();

            ICollection<Vehicle> vipVehicles = new List<Vehicle>();
            ICollection<Vehicle> noVipVehicles = new List<Vehicle>();

            foreach (var vehicle in vehicles)
            {
                if (vehicle.IsVIP)
                {
                    vipVehicles.Add(vehicle);
                }
                else
                {
                    noVipVehicles.Add(vehicle);
                }
            }

            List<Vehicle> result = new List<Vehicle>();

            result.AddRange(vipVehicles.OrderBy(v => v.Price));
            result.AddRange(noVipVehicles.OrderBy(v => v.Price));

            return result;
        }

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.ContainsSeller(sellerName))
                throw new ArgumentException();

            var keys = this.vehicles.Keys.Intersect(this.sellersVehicles[sellerName]);
            var vehicles = keys.Select(k => this.vehicles[k]);

            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
        {
            IEnumerable<Vehicle> vehicles = this.vehicles.Values
                .Where(v => v.Price >= lowerBound && v.Price <= upperBound);

            if (vehicles.Count() == 0)
                return Enumerable.Empty<Vehicle>();

            return vehicles.OrderByDescending(v => v.Horsepower);
        }

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (vehiclesByBrand.Count == 0)
                throw new ArgumentException();

            Dictionary<string, List<Vehicle>> groupedVehicles
                = new Dictionary<string, List<Vehicle>>();

            foreach (var kvp in this.vehiclesByBrand)
            {
                string key = kvp.Key;
                List<Vehicle> value = kvp.Value
                    .Select(k => this.vehicles[k])
                    .OrderBy(v => v.Price)
                    .ToList();

                groupedVehicles.Add(key, value);
            }

            return groupedVehicles;
        }

        public void RemoveVehicle(string vehicleId)
        {
            Vehicle vehicle = this.GetVehicle(vehicleId);

            this.vehicles.Remove(vehicleId);
            string sellerName = this.vehicleSeller[vehicleId];
            this.sellersVehicles[sellerName].Remove(vehicleId);
            this.vehicleSeller.Remove(vehicleId);
            this.vehiclesByBrand[vehicle.Brand].Remove(vehicleId);
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
        {
            var orderedVehicles = this.vehicles.Values
                .OrderByDescending(v => v.Horsepower)
                .ThenBy(v => v.Price)
                .ThenBy(v => this.vehicleSeller[v.Id]);

            return orderedVehicles;
        }

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.ContainsSeller(sellerName))
                throw new ArgumentException();

            IEnumerable<Vehicle> vehicles = this.sellersVehicles[sellerName]
                .Select(id => this.vehicles[id]);

            Vehicle cheapestVehicle = vehicles.First();
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Price < cheapestVehicle.Price)
                {
                    cheapestVehicle = vehicle;
                }
            }

            this.RemoveVehicle(cheapestVehicle.Id);
            return cheapestVehicle;
        }

        // Private


        private bool ContainsSeller(string sellerName)
        {
            return this.sellersVehicles.ContainsKey(sellerName);
        }

        private IEnumerable<Vehicle> GetVehiclesFromKeys(IEnumerable<string> keys)
        {
            ICollection<Vehicle> vehicles = new List<Vehicle>();

            foreach (var key in keys)
            {
                vehicles.Add(this.vehicles[key]);
            }

            return vehicles;
        }

        private Vehicle GetVehicle(string vehicleId)
        {
            Vehicle vehicle;
            try
            {
                vehicle = this.vehicles[vehicleId];
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }

            return vehicle;
        }


    }
}
