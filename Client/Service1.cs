using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Metier;
using System.Globalization;

namespace Client
{
    public partial class ServicePerformance : ServiceBase
    {
        protected Timer t;

        public ServicePerformance()
        {
            InitializeComponent();
        }

        //Lancement du timer au lancement du service
        protected override void OnStart(string[] args)
        {
            t = new Timer(5 * 60 * 1000);
            t.Elapsed += new ElapsedEventHandler(serviceExec);
            t.Start();
        }

        //Arret du timer lors de l'arret du service
        protected override void OnStop()
        {
            t.Stop();
        }

        //permet de récupérer les informations et de les inserer en base de données
        protected void serviceExec(object sender, EventArgs e)
        {
            TrackPerformance trackPerformance = new TrackPerformance();
            ObjectPerformance performance = new ObjectPerformance();
            MachineInformation machineInfo = new MachineInformation();
            machineInfo = trackPerformance.getAveragePerformance();

            //convertion des "," en "." pour l'insertion des doubles dans la base de données
            string stringCPU = machineInfo.infoCPU.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringRAM = machineInfo.infoRAM.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringDisk = machineInfo.infoDisk.ToString(CultureInfo.InvariantCulture.NumberFormat);

            //insertion dans la base de données
            performance.insert(stringCPU, stringRAM, stringDisk);
        }
    }
}