using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CompanyUsers
{
    class Program
    {
        private static Dictionary<string, HashSet<string>> companies;

        static void Main(string[] args)
        {
            companies = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split("->").Select(e => e.Trim()).ToArray();

                string companyName = arguments[0];
                string employeeId = arguments[1];

                AddToDatabase(companyName, employeeId);
            }

            PrintAllFromDatabase();
        }

        private static void PrintAllFromDatabase()
        {
            companies = companies.OrderBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }

        private static void AddToDatabase(string companyName, string employeeId)
        {
            if (!companies.ContainsKey(companyName))
            {
                companies.Add(companyName, new HashSet<string>());
            }

            companies[companyName].Add(employeeId);
        }
    }
}
