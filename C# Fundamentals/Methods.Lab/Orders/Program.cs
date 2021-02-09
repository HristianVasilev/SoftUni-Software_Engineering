using System;

namespace Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();

            int count = int.Parse(Console.ReadLine());

            Purchase(product, count);


        }

        private static void Purchase(string product, int count)
        {
            decimal price;

            switch (product)
            {
                case "coffee":
                    price = 1.50m;

                    break;
                case "water":
                    price = 1.00m;

                    break;
                case "coke":
                    price = 1.40m;

                    break;
                case "snacks":
                    price = 2.00m;

                    break;
                default:
                    throw new NotImplementedException();
            }

            Console.WriteLine(count * price);
        }
    }
}
