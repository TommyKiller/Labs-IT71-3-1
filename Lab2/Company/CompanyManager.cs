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
                throw new Exception("Unknown formatter type!");
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
                throw new Exception("Unknown filtrator type!");
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
            Regex regex = new Regex("^([A-Za-z]+).?( [A-Za-z].?)*$");
            if (!regex.IsMatch(name))
            {
                throw new Exception("Wrong name style!");
            }

            Company.Hire(new Employee(name, int.Parse(salary), Find(position)));
        }
        public void Remove(string name)
        {
            Position result = Find(name);
            if (Company.Head == result)
            {
                throw new Exception("You cannot remove head! Use chead to change it.");
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
                throw new Exception("Head already exists! Use chead to change head");
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
                throw new Exception(String.Format("Supervisor position {0} is not a manager position!", supervisor));
            }
            supervisor.GetManager().AddSubordinate(subordinate);
        }
        // Service tools
        private Position Find(string name)
        {
            Position result = Company.Head.Find(name);
            if (result is null)
            {
                throw new Exception("Such a position does not exist!");
            }
            return result;
        }
        private void CheckExistance(string name)
        {
            if (!Company.HasHead())
            {
                throw new Exception("Add head of the copmany first!");
            }
            Position result = Company.Head.Find(name);
            if (!(result is null))
            {
                throw new Exception(String.Format("Position {0} already exists!", name));
            }
        }
        // Factory methods
        private Position CreateManager(string name)
        {
            return new Manager(name);
        }
        private Position CreateWorker(string name)
        {
            return new Worker(name);
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
