using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class CompanyManager
    {
        public CompanyManager(Company company)
        {
            Company = company;
            Console.WriteLine("Now managing company: " + Company.Name);
        }

        public void ListPositions(string mode)
        {
            if (Formatters.ContainsKey(mode))
            {
                Company.Head.AcceptFormatter(Formatters[mode]);
            }
            else
            {
                throw new Exception("Unknown formatter type!");
            }
        }
        public void AddManager(string name)
        {
            if (Positions.Contains(Positions.Find(item => item.Name == name)))
            {
                throw new Exception("Position already exists!");
            }
            Positions.Add(new Manager(name));
        }
        public void AddWorker(string name)
        {
            if (Positions.Contains(Positions.Find(item => item.Name == name)))
            {
                throw new Exception("Position already exists!");
            }
            Positions.Add(new Worker(name));
        }
        public void AddHead(string position)
        {
            AddManager(position);
            if (Company.Head == null)
            {
                SetHead(position);
            }
            else
            {
                ChangeHead(position);
            }
        }
        public void SetHead(string position)
        {
            Position manager = Positions.Find(item => item.Name == position);
            if (Positions.Contains(manager))
            {
                if (manager is Manager)
                {
                    Company.Head = Positions.Find(item => item.Name == position);
                }
                else
                {
                    throw new Exception("Only a manager could head the company!");
                }
            }
            else
            {
                throw new Exception("Such a position doesn`t exist!");
            }
        }
        public void ChangeHead(string position)
        {
            Position manager = Positions.Find(item => item.Name == position);
            if (Positions.Contains(manager))
            {
                if (manager is Manager)
                {
                    Company.Head = Positions.Find(item => item.Name == position);
                    // Add Subordinate;
                }
                else
                {
                    throw new Exception("Only a manager could head the company!");
                }
            }
            else
            {
                throw new Exception("Such a position doesn`t exist!");
            }
        }

        private Dictionary<string, PositionFormatter> Formatters = new Dictionary<string, PositionFormatter>
        {
            { "order", new DirectOrderFormatter() },
            { "height", new PositionHeightFormatter() }
        };
        private Company Company { get; set; }
        public List<Position> Positions = new List<Position>();
    }
}
