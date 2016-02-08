using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Metier;
using System.Threading;

namespace GestionInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadCPU t1 = new ThreadCPU();
            Thread oThread = new Thread(new ThreadStart(t1.run));
            oThread.Start();
            Console.WriteLine("Appuyer sur une touche pour quitter");
            Console.ReadLine();
            oThread.Abort();
            oThread.Join();
            Console.WriteLine("Vous pouvez maintenant quitter l'application");
        }
    }
}
