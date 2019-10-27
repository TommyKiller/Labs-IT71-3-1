using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    public class PositionHeightFormatter : PositionFormatter
    {
        public override void AcceptManager(Manager manager)
        {
            if (start)
            {
                start = false;
                SetDeepthMax(manager);
                while (deepth <= deepth_max)
                {
                    LogManager(manager);
                    deepth++;
                }
            }
            else
            {
                LogManager(manager);
            }

        }

        public override void AcceptWorker(Worker worker)
        {
            if (deepth_current == deepth)
            {
                Console.WriteLine(worker);
            }
        }
        
        private void SetDeepthMax(Manager manager)
        {
            DeepthMeter pointy_stick = new DeepthMeter();
            manager.AcceptFormatter(pointy_stick);
            deepth_max = pointy_stick.GetMaxDeepth();
        }

        private void LogManager(Manager manager)
        {
            if ((deepth_current == deepth) || (manager.Subordinates.Count == 0))
            {
                Console.WriteLine(manager);
            }
            else
            {
                deepth_current++;
                foreach (Position subordinate in manager.Subordinates)
                {
                    subordinate.AcceptFormatter(this);
                }
                deepth_current--;
            }
        }

        private bool start = true;
        private int deepth_current = 0;
        private int deepth = 0;
        private int deepth_max;
    }
}
