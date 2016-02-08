using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class ObserverCPU : Observer
    {
        public void actualiser(Observable o)
        {
            int[] tabValeurCpu = o.getAllStates();
            Console.WriteLine("Cpu : " + tabValeurCpu[0]);
            Console.WriteLine("Ram : " + tabValeurCpu[1]);
            Console.WriteLine("Espace disque : " + tabValeurCpu[2]);

        }
    }
}
