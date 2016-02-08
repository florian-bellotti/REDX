using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Check : Observable
    {
        private List<Observer> listeDesObservers;
        private int cpu;
        public int Cpu
        {
            get
            {
                return this.cpu;
            }
        }
        private int ram;
        public int Ram
        {
            get
            {
                return this.ram;
            }
        }
        private int disque;
        public int Disque
        {
            get
            {
                return this.disque;
            }
        }

        public void ajouterObs(Observer o)
        {
            if(!this.listeDesObservers.Contains(o))
            {
                this.listeDesObservers.Add(o);
            }
        }
        public void supprimerObs(Observer o)
        {
            this.listeDesObservers.Remove(o);
        }
        public void notifierObs()
        {
            foreach(Observer obs in this.listeDesObservers )
            {
                obs.actualiser(this);
            }
        }
        public int[] getAllStates()
        {
            int[] tab = new int[3];
            tab[0] = cpu;
            tab[1] = ram;
            tab[2] = disque;
            return tab;
        }
    }
}
