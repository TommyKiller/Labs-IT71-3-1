using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class SalaryFiltrator : Filtrator
    {
        public override void AcceptCompany(Company company)
        {
            Console.Write("\tEnter minimum salary: ");
            int salary = int.Parse(Console.ReadLine());
            
            List<Employee> result = company.Employees.FindAll(employee => employee.Salary >= salary);
            if (result.Count == 0)
            {
                throw new Exception("No matches found!");
            }

            Console.WriteLine("\t\tID\tName\tSalary\tPosition");
            foreach (Employee employee in result)
            {
                Console.WriteLine("\t\t" + employee);
            }
        }
    }
}
