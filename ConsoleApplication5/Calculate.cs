using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Calculate
    {
        public double calculMoyenne(List<double> list)
        {
            double total = 0;

            for (int i = 0; i < list.Count; i++)
            {
                total += list[i];
            }

            return total / list.Count;
        }
    }
}
