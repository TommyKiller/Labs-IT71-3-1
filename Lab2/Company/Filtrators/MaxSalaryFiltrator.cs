using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class MaxSalaryFiltrator : Filtrator
    {
        public override void AcceptCompany(Company company)
        {
            int max_salary = 0;

            foreach(Employee employee in company.Employees)
            {
                if (employee.Salary >= max_salary)
                {
                    max_salary = employee.Salary;
                }
            }

            List<Employee> result = company.Employees.FindAll(employee => employee.Salary == max_salary);
            if (result.Count == 0)
            {
                throw new CompanyHasNoEmployeesException(String.Format("{0} has no employees!", company));
            }

            Console.WriteLine("\t\tID\tName\tSalary\tPosition");
            foreach (Employee employee in result)
            {
                Console.WriteLine("\t\t" + employee);
            }
        }
    }
}
