using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Manager : Position
    {
        public Manager(string name)
            : base(name)
        {
            Subordinates = new HashSet<Position>();
        }

        //
        // Manager interface
        //
        public void RemoveSubordinate(Position position)
        {
            Subordinates.Remove(position);
            position.Supervisor = null;
        }

        public void AddSubordinate(Position position)
        {
            Subordinates.Add(position);
            position.Supervisor = this;
        }

        //
        // Position interface
        //
        public override Position Remove()
        {
            foreach(Position subordinate in Subordinates)
            {
                Supervisor.GetManager().AddSubordinate(subordinate);
            }
            Supervisor.GetManager().RemoveSubordinate(this);
            return this;
        }

        public override Manager GetManager()
        {
            return this;
        }

        public override Position Find(string name)
        {
            if (Name != name)
            {
                Position position = null;
                foreach(Position subordinate in Subordinates)
                {
                    position = subordinate.Find(name);
                    if (!(position is null))
                    {
                        return position;
                    }
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

        //
        // Public members
        //
        public HashSet<Position> Subordinates { get; private set; }
    }
}
