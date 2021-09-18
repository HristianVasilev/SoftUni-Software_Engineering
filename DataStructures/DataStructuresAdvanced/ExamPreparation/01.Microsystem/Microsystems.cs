namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        private Dictionary<int, Computer> computers;
        private Dictionary<Brand, SortedSet<int>> computersByBrand;
        private Dictionary<double, SortedSet<int>> computersByScreenSize;
        private Dictionary<string, SortedSet<int>> computersByColor;
        private Dictionary<double, SortedSet<int>> computersByPrice;


        public Microsystems()
        {
            this.computers = new Dictionary<int, Computer>();
            this.computersByBrand = new Dictionary<Brand, SortedSet<int>>();
            this.computersByScreenSize = new Dictionary<double, SortedSet<int>>();
            this.computersByColor = new Dictionary<string, SortedSet<int>>();
            this.computersByPrice = new Dictionary<double, SortedSet<int>>();
        }


        public void CreateComputer(Computer computer)
        {
            if (!this.computers.ContainsKey(computer.Number))
            {
                this.Add(computer);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool Contains(int number)
        {
            return this.computers.ContainsKey(number);
        }

        public int Count()
        {
            return this.computers.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!this.Contains(number))
            {
                throw new ArgumentException();
            }

            return this.computers[number];
        }

        public void Remove(int number)
        {
            Computer computer = this.GetComputer(number);

            this.Remove(computer);
        }

        public void RemoveWithBrand(Brand brand)
        {
            if(!this.computersByBrand.ContainsKey(brand))
            {
                throw new ArgumentException();
            }

            int[] computerNumbers = this.computersByBrand[brand].ToArray();

            for (int i = 0; i < computerNumbers.Length; i++)
            {
                this.Remove(computerNumbers[i]);
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            Computer computer = this.GetComputer(number);

            if (ram > computer.RAM)
            {
                computer.RAM = ram;
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            if (!this.computersByBrand.ContainsKey(brand)) return Enumerable.Empty<Computer>();

            IEnumerable<Computer> filteredComputers = this.GetAllFromKey(this.computersByBrand[brand]);

            return filteredComputers.OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            if (!this.computersByScreenSize.ContainsKey(screenSize)) return Enumerable.Empty<Computer>();

            IEnumerable<Computer> filteredComputers
                = this.GetAllFromKey(this.computersByScreenSize[screenSize]);

            return filteredComputers.OrderByDescending(x => x.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            if (!this.computersByColor.ContainsKey(color)) return Enumerable.Empty<Computer>();

            IEnumerable<Computer> filteredComputers
               = this.GetAllFromKey(this.computersByColor[color]);

            return filteredComputers.OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            IEnumerable<int> computerNumbers = this.computersByPrice
                .Where(k => k.Key >= minPrice && k.Key <= maxPrice).SelectMany(x => x.Value);

            IEnumerable<Computer> filteredComputers = this.GetAllFromKey(computerNumbers);
            return filteredComputers.OrderByDescending(x => x.Price);
        }




        // Private

        private void Add(Computer computer)
        {
            int computerNumber = computer.Number;
            Brand brand = computer.Brand;
            double screenSize = computer.ScreenSize;
            string color = computer.Color;
            double price = computer.Price;

            this.computers.Add(computerNumber, computer);
            this.AddToDictionary(computerNumber, brand, ref computersByBrand);
            this.AddToDictionary(computerNumber, screenSize, ref computersByScreenSize);
            this.AddToDictionary(computerNumber, color, ref computersByColor);
            this.AddToDictionary(computerNumber, price, ref computersByPrice);
        }

        private void AddToDictionary<TKey>(int computerNumber, TKey key, ref Dictionary<TKey, SortedSet<int>> dictionary)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new SortedSet<int>());
            }

            dictionary[key].Add(computerNumber);
        }




        private void Remove(Computer computer)
        {
            this.computers.Remove(computer.Number);
            this.RemoveFromDictionary(computer.Number, computer.Brand, ref computersByBrand);
            this.RemoveFromDictionary(computer.Number, computer.ScreenSize, ref computersByScreenSize);
            this.RemoveFromDictionary(computer.Number, computer.Color, ref computersByColor);
            this.RemoveFromDictionary(computer.Number, computer.Price, ref computersByPrice);
        }

        private void RemoveFromDictionary<TKey>(int computerNumber, TKey key, ref Dictionary<TKey, SortedSet<int>> dictionary)
        {
            dictionary[key].Remove(computerNumber);
        }



        private IEnumerable<Computer> GetAllFromKey(IEnumerable<int> computerNumbers)
        {
            ICollection<Computer> filteredComputers = new List<Computer>();

            foreach (var number in computerNumbers)
            {
                Computer computer = this.computers[number];
                filteredComputers.Add(computer);
            }

            return filteredComputers;
        }
    }
}
