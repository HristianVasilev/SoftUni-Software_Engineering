using System;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetSum = int.Parse(Console.ReadLine());
            string names = Console.ReadLine();

            Func<string, int, string> getFirstName = (namesInput, targetSum) =>
            {
                string[] names = namesInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Func<string, int> sumOfCharacters = name =>
                {
                    int sum = 0;

                    for (int i = 0; i < name.Length; i++)
                    {
                        sum += name[i];
                    }

                    return sum;
                };

                foreach (string name in names)
                {
                    int sum = sumOfCharacters(name);

                    if (sum >= targetSum)
                    {
                        return name;
                    }
                }

                return null;
            };

            string firstName = getFirstName(names, targetSum);
            if (firstName != null)
            {
                Console.WriteLine(firstName);
            }
        }
    }
}
