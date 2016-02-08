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
using Donnee;
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

        protected override void OnStart(string[] args)
        {
            t = new Timer(5*60*1000);
            t.Elapsed += new ElapsedEventHandler(serviceExec);
            t.Start();
        }

        protected override void OnStop()
        {
            t.Stop();
        }

        protected void serviceExec(object sender, EventArgs e)
        {
            MachineInformation machineInfo = new MachineInformation();
            TrackPerformance trackPerformance = new TrackPerformance();

            machineInfo = trackPerformance.getAveragePerformance();

            string stringCPU = machineInfo.infoCPU.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringRAM = machineInfo.infoRAM.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringDisk = machineInfo.infoDisk.ToString(CultureInfo.InvariantCulture.NumberFormat);

            MappageMachineInformation mapMachineInfo = new MappageMachineInformation();
            mapMachineInfo.insert(stringCPU, stringRAM, stringDisk);
        }
    }
}
