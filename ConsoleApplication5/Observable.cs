using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    interface Observable
    {
        void ajouterObs(Observer o);
        void supprimerObs(Observer o);
        void notifierObs();
        int[] getAllStates();

    }
}
