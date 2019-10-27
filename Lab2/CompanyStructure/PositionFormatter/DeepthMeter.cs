using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class DeepthMeter : PositionFormatter
    {
        public override void AcceptManager(Manager manager)
        {
            if (manager.Subordinates.Count == 0)
            {
                deepth.Add(deepth_current);
            }
            else
            {
                deepth_current++;
                foreach(Position subordinate in manager.Subordinates)
                {
                    subordinate.AcceptFormatter(this);
                }
                deepth_current--;
            }
        }

        public override void AcceptWorker(Worker worker)
        {
            deepth.Add(deepth_current);
        }

        public int GetMaxDeepth()
        {
            int deepth_max = 0;
            foreach(int point in deepth)
            {
                if (deepth_max < point)
                {
                    deepth_max = point;
                }
            }
            return deepth_max;
        }

        private int deepth_current = 0;
        private List<int> deepth = new List<int>();
    }
}
