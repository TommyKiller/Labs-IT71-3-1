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
        }

        public Position Head { get; set; }
        public string Name { get; private set; }
    }
}
