using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class Worker : Position
    {
        public Worker(string name)
            : base(name)
        { }

        //
        // Position interface
        //
        public override Position Remove()
        {
            Supervisor.GetManager().RemoveSubordinate(this);
            return this;
        }

        public override Position Find(string name)
        {
            if (Name != name)
            {
                return null;
            }
            else
            {
                return this;
            }
        }

        public override void AcceptFormatter(PositionFormatter formatter)
        {
            formatter.AcceptWorker(this);
        }
    }
}
