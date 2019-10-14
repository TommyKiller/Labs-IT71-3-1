using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public abstract class Position : IFormatable
    {
        public Position(string name)
        {
            Name = name;
        }

        public abstract Position Find(string name);
        public abstract void AcceptFormatter(PositionFormatter formatter);

        public string Name { get; protected set; }

        public static bool operator ==(Position left, Position right)
        {
            return left.Name == right.Name;
        }
        public static bool operator !=(Position left, Position right)
        {
            return left.Name != right.Name;
        }
    }
}
