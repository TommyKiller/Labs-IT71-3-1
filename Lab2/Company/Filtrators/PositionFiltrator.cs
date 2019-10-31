using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class PositionFiltrator : Filtrator
    {
        public override void AcceptCompany(Company company)
        {
            Console.Write("\tEnter a position: ");
            string position = Console.ReadLine();

            Position result_position = company.Head.Find(position);
            if (result_position is null)
            {
                throw new Exception("Such a position does not exist!");
            }

            List<Employee> result = company.Employees.FindAll(employee => employee.Position == result_position);
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
