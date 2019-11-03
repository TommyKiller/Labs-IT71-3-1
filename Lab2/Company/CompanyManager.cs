using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab2
{
    public class CompanyManager
    {
        public CompanyManager(Company company)
        {
            Company = company;
            Console.WriteLine("Now managing company: " + Company.Name);
        }

        public void ListPositions(string formatter)
        {
            if (Formatters.ContainsKey(formatter))
            {
                Company.Head.AcceptFormatter(Formatters[formatter]);
            }
            else
            {
                throw new UnknownTypeException("Unknown formatter type!");
            }
        }
        // Managing positions
        public void Get(string filtrator)
        {
            if (Filtrators.ContainsKey(filtrator))
            {
                Company.AcceptFiltrator(Filtrators[filtrator]);
            }
            else
            {
                throw new UnknownTypeException("Unknown filtrator type!");
            }
        }
        public void Appoint(string id, string position)
        {
            Employee man = Company.GetEmployee(new EmployeeID(int.Parse(id)));
            man.Appoint(Find(position));
        }
        public void Fire(string id)
        {
            Employee man = Company.GetEmployee(new EmployeeID(int.Parse(id)));
            Company.Fire(man);
        }
        public void Hire(string name, string salary, string position)
        {
            Regex name_pattern = new Regex("^([A-Za-z]+.?)( [A-Za-z]+.?)*$");
            if (!name_pattern.IsMatch(name))
            {
                throw new FormatException(String.Format("{0} name has incorrect format.", name));
            }
            int int_salary = int.Parse(salary);

            if (int_salary < 0)
            {
                throw new ArgumentOutOfRangeException("Salary can not be leser then 0");
            }

            Company.Hire(new Employee(name, int_salary, Find(position)));
        }
        public void Remove(string name)
        {
            Position result = Find(name);
            if (Company.Head == result)
            {
                throw new CompanyHeadException("You cannot remove head! Use chead to change it.");
            }
            result.Remove();
        }
        public void ChangeHead(string name)
        {
            CheckExistance(name);
            Position NewHead = CreateManager(name);
            Subordinate(Company.Head, NewHead);
            Company.Head.Remove();
            Company.SetHead(NewHead.GetManager());
        }
        public void NewHead(string name)
        {
            if (Company.HasHead())
            {
                throw new CompanyHeadException("Head already exists! Use chead to change head");
            }
            Company.SetHead(CreateManager(name).GetManager());
        }
        public void AddWorker(string name, string supervisor)
        {
            CheckExistance(name);
            Subordinate(CreateWorker(name), Find(supervisor));
        }
        public void AddManager(string name, string supervisor)
        {
            CheckExistance(name);
            Subordinate(CreateManager(name), Find(supervisor));
        }
        private void Subordinate(Position subordinate, Position supervisor)
        {
            if (supervisor.GetManager() is null)
            {
                throw new PositionCanNotHaveSubordinatesException(String.Format("Supervisor position {0} is not a manager position!", supervisor));
            }
            supervisor.GetManager().AddSubordinate(subordinate);
        }
        // Service tools
        private Position Find(string position)
        {
            Position result = Company.Head.Find(position);
            if (result is null)
            {
                throw new PositionDoesNotExistException(String.Format("{0} position does not exist!", position));
            }
            return result;
        }
        private void CheckExistance(string position)
        {
            if (!Company.HasHead())
            {
                throw new CompanyHeadException("Company has no head! Add head first!");
            }
            Position result = Company.Head.Find(position);
            if (!(result is null))
            {
                throw new PositionAlreadyExistsException(String.Format("Position {0} already exists!", position));
            }
        }
        // Factory methods
        private Position CreateManager(string position_name)
        {
            return new Manager(position_name);
        }
        private Position CreateWorker(string position_name)
        {
            return new Worker(position_name);
        }

        private Dictionary<string, PositionFormatter> Formatters = new Dictionary<string, PositionFormatter>
        {
            { "order", new DirectOrderFormatter() },
            { "height", new PositionHeightFormatter() }
        };
        private Dictionary<string, Filtrator> Filtrators = new Dictionary<string, Filtrator>
        {
            { "name", new NameFiltrator() },
            { "position", new PositionFiltrator() },
            { "salary-max", new MaxSalaryFiltrator() },
            { "salary-more-then", new SalaryFiltrator() },
            { "manager", new ManagerFiltrator() }
        };
        private Company Company { get; set; }
    }
}
