using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] employeeArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = employeeArgs[0];
                decimal salary = decimal.Parse(employeeArgs[1]);
                string department = employeeArgs[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            GetDepartmentWithHighesAvgSalary(ref employees);

        }

        private static void GetDepartmentWithHighesAvgSalary(ref List<Employee> employees)
        {
            var groupedCollection = employees.GroupBy(x => x.Department).OrderByDescending(x => x.Average(s => s.Salary)).ToList();
         
            IGrouping<string,Employee> departmentInfo = groupedCollection.FirstOrDefault();

            if (departmentInfo is null)
            {
                throw new ArgumentNullException();
            }

            var departmentEmployees = departmentInfo.Select(x => x).OrderByDescending(s => s.Salary).ToArray();

            Console.WriteLine($"Highest Average Salary: {departmentInfo.Key}");

            foreach (var employee in departmentEmployees)
            {
                Console.WriteLine(employee);
            }
        }
    }


    class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public string Department { get; private set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Salary:f2}";
        }
    }
}
