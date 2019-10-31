using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class NameFiltrator : Filtrator
    {
        public override void AcceptCompany(Company company)
        {
            Console.Write("\tEnter a name: ");
            string name = Console.ReadLine();

            List<Employee> result = company.Employees.FindAll(employee => employee.Name == name);
            if (result.Count == 0)
            {
                throw new Exception("No matches found!");
            }

            Console.WriteLine("\t\tID\tName\tSalary\tPosition");
            foreach(Employee employee in result)
            {
                Console.WriteLine("\t\t" + employee);
            }
        }
    }
}
