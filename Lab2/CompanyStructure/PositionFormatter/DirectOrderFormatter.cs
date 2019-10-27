using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class DirectOrderFormatter : PositionFormatter
    {
        public override void AcceptManager(Manager manager)
        {
            Console.WriteLine(manager + ":");
            foreach (Position position in manager.Subordinates)
            {
                position.AcceptFormatter(this);
            }
        }

        public override void AcceptWorker(Worker worker)
        {
            Console.WriteLine(worker);
        }
    }
}
