using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Metier
{
    public class ThreadCPU
    {
        private Check ch;
        private ObserverCPU obs;
        public void run()
        {
            ch = new Check();
            obs = new ObserverCPU();
            ch.ajouterObs(obs);
            while(true)
            {
                this.ch.notifierObs();
                Thread.Sleep(600000);
            } 
        }
    };
}
