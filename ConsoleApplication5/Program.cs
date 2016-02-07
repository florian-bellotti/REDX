using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Donnee;
using System.Data;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Globalization;

namespace Metier
{
    class Program
    {
        static void Main()
        {
            G g = new G();
            g.execution();
        }
    }
    
    class G
    {
        private DataSet data;
        private MappageMachineInformation mapMachineinformation;
        private CADClass cad;
        private string SQLRequest;

        public G()
        {
            this.data = new DataSet();
            this.mapMachineinformation = new MappageMachineInformation();
            this.cad = new CADClass();
            this.SQLRequest = "";
        }

        public void execution()
        {
            MachinePerformance machineInfoPerf = new MachinePerformance();
            MachineInformation machineInfo = new MachineInformation();
            Calculate calcule = new Calculate();
            machineInfo = machineInfoPerf.getMachineInformation();

            machineInfo.infoCPU = calcule.calculMoyenne(machineInfo.listInfoCPU);
            machineInfo.infoRAM = calcule.calculMoyenne(machineInfo.listInfoRAM);
            machineInfo.infoDisk = calcule.calculMoyenne(machineInfo.listInfoDisk);

            string stringCPU = machineInfo.infoCPU.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringRAM = machineInfo.infoRAM.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringDisk = machineInfo.infoDisk.ToString(CultureInfo.InvariantCulture.NumberFormat);

            insert_MachineInformation(stringCPU, stringRAM, stringDisk);
        }

        public void insert_MachineInformation(string GPU, string RAM, string Disk)
        {
            this.SQLRequest = mapMachineinformation.insert(GPU, RAM, Disk);
            cad.ActionRows(this.SQLRequest);
        }
    }
}

