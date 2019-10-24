using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Company
    {
        public Company(string name)
        {
            Name = name;
            Head = null;
        }

        public void SetHead(Manager manager)
        {
            Head = manager;
        }

        public bool HasHead()
        {
            return !(Head is null);
        }

        public Position Head { get; private set; }
        public string Name { get; private set; }
    }
}
