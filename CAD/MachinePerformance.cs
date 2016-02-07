using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Donnee
{
    public class MachinePerformance
    {
        public MachineInformation machineInfo;

        public MachinePerformance()
        {
            machineInfo.infoCPU = 0;
            machineInfo.infoDisk = 0;
            machineInfo.infoRAM = 0;
            machineInfo.listInfoCPU = new List<double>();
            machineInfo.listInfoDisk = new List<double>();
            machineInfo.listInfoRAM = new List<double>();
        }

        public MachineInformation getMachineInformation()
        {
            int count = 0;

            //récupération des informations de la machine (disque, CPU, RAM)
            PerformanceCounter counterDisk = new PerformanceCounter("PhysicalDisk", @"% Disk Time", @"_Total");    //sup de 90%
            PerformanceCounter counterCPU = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");   //85%
            PerformanceCounter counterRAM = new PerformanceCounter("Memory", "Available MBytes");                  //moins de 50MB

            //Calculate calcule = new Calculate();

            while (count <= 15)
            {
                //On récupère les info et on les met dans des listes
                machineInfo.listInfoDisk.Add(counterDisk.NextValue());
                machineInfo.listInfoCPU.Add(counterCPU.NextValue());
                machineInfo.listInfoRAM.Add(counterRAM.NextValue());

                count++;
                Thread.Sleep(1000);
            }

            return machineInfo;
        }
    }
}
