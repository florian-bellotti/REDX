using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnee
{
    public class MachinePerformance
    {
        public MachineInformation machineInfo;
        private PerformanceCounter counterDisk;
        private PerformanceCounter counterCPU;
        private PerformanceCounter counterRAM;               


        public MachinePerformance()
        {
            machineInfo.infoCPU = 0;
            machineInfo.infoDisk = 0;
            machineInfo.infoRAM = 0;
            counterDisk = new PerformanceCounter("PhysicalDisk", @"% Disk Time", @"_Total");    //sup de 90%
            counterCPU = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");   //85%
            counterRAM = new PerformanceCounter("Memory", "Available MBytes");                  //moins de 50MB
        }

        public MachineInformation getMachineInformation()
        {
            //On récupère les info et on les met dans des listes
            machineInfo.infoDisk = counterDisk.NextValue();
            machineInfo.infoCPU = counterCPU.NextValue();
            machineInfo.infoRAM = counterRAM.NextValue();

            return machineInfo;
        }
    }
}
