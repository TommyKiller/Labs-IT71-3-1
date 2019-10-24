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

        //
        // Interface
        //
        public abstract Position Find(string name);
        public abstract void AcceptFormatter(PositionFormatter formatter);
        public abstract Position Remove();
        public virtual Manager GetManager()
        {
            return null;
        }

        //
        // Public members
        //
        public Position Supervisor { get; set; }
        public string Name { get; protected set; }

        //
        // Static members
        //
        public static bool operator ==(Position left, Position right)
        {
            return left.Name == right.Name;
        }

        public static bool operator !=(Position left, Position right)
        {
            return left.Name != right.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
