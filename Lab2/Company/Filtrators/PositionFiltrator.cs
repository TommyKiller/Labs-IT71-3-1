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
                throw new PositionDoesNotExistException(String.Format("{0} position does not exist!", position));
            }

            List<Employee> result = company.Employees.FindAll(employee => employee.Position == result_position);
            if (result.Count == 0)
            {
                throw new NoMatchesFoundException();
            }

            Console.WriteLine("\t\tID\tName\tSalary\tPosition");
            foreach (Employee employee in result)
            {
                Console.WriteLine("\t\t" + employee);
            }
        }
    }
}
