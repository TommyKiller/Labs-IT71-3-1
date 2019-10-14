using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Manager : Position
    {
        public Manager(string name)
            : base(name)
        { }

        public override Position Find(string name)
        {
            if (Name != name)
            {
                Position position = null;
                foreach(Position subordinate in Subordinates)
                {
                    position = subordinate.Find(name);
                }
                return position;
            }
            else
            {
                return this;
            }
        }

        public override void AcceptFormatter(PositionFormatter formatter)
        {
            formatter.AcceptManager(this);
        }

        public HashSet<Position> Subordinates { get; private set; }
    }
}
