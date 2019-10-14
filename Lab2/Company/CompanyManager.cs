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
        public void SetHead(string position)
        {
            if (Positions.Contains(Positions.Find(item => item.Name == position)))
            {
                Company.Head = Positions.Find(item => item.Name == position);
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
