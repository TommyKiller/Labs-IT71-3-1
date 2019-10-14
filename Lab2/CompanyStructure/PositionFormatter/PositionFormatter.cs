using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public abstract class PositionFormatter
    {
        public abstract void AcceptManager(Manager manager);
        public abstract void AcceptWorker(Worker worker);
    }
}
