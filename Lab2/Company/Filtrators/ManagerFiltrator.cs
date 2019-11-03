using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class ManagerFiltrator : Filtrator
    {
        public override void AcceptCompany(Company company)
        {
            Console.Write("\tInput employee id: ");
            int id = int.Parse(Console.ReadLine());

            Employee manager = company.GetEmployee(new EmployeeID(id));
            if (manager.Position.GetManager() is null)
            {
                throw new PositionHasNoSubordinatesException(String.Format("{0} has no subordinates", manager));
            }

            List<Employee> result = company.Employees.FindAll(employee => manager.Position.GetManager().Subordinates.Contains(employee.Position));
            if (result.Count == 0)
            {
                throw new PositionHasNoSubordinatesException(String.Format("{0} has no subordinates", manager));
            }

            Console.WriteLine("\t\tID\tName\tSalary\tPosition");
            foreach (Employee employee in result)
            {
                Console.WriteLine("\t\t" + employee);
            }
        }
    }
}
