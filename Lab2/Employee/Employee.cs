using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Employee
    {
        public Employee(string name, int salary, Position position)
        {
            Name = name;
            Salary = salary;
            Position = position;
            ID = new EmployeeID(employee_num++);
        }

        public void Appoint(Position position)
        {
            Position = position;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}", ID, Name, Salary, Position);
        }

        public string Name { get; private set; }
        public int Salary { get; private set; }
        public Position Position { get; set; }
        public EmployeeID ID { get; private set; }
        private static int employee_num = 0;
    }
}
