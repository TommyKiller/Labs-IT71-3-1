using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Company : IFiltratable
    {
        public Company(string name)
        {
            Name = name;
            Head = null;
            Employees = new List<Employee>();
        }
        
        public Employee GetEmployee(EmployeeID id)
        {
            return Employees.Find(employee => employee.ID == id);
        }

        public void AcceptFiltrator(Filtrator filtrator)
        {
            filtrator.AcceptCompany(this);
        }

        public void Hire(Employee employee)
        {
            Employees.Add(employee);
        }

        public void Fire(Employee employee)
        {
            Employees.Remove(employee);
        }

        public void SetHead(Manager manager)
        {
            Head = manager;
        }

        public bool HasHead()
        {
            return !(Head is null);
        }

        public override string ToString()
        {
            return Name;
        }

        public List<Employee> Employees;
        public Position Head { get; private set; }
        public string Name { get; private set; }
    }
}
