using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Threading;
using System.Diagnostics;

namespace Metier
{
    /// <summary>
    /// Cette classe s'occupe des performances de la machine
    /// </summary>
    public class TrackPerformance
    {
        private MachineInformation machineInfo;
        private Calculate calculate;
        private List<double> listInfoDisk;
        private List<double> listInfoRAM;
        private List<double> listInfoCPU;
        private PerformanceCounter counterDisk;
        private PerformanceCounter counterCPU;
        private PerformanceCounter counterRAM;

        private int count;

        public TrackPerformance()
        {
            calculate = new Calculate();
            listInfoCPU = new List<double>();
            listInfoDisk = new List<double>();
            listInfoRAM = new List<double>();
            machineInfo.infoCPU = 0;
            machineInfo.infoDisk = 0;
            machineInfo.infoRAM = 0;
            count = 0;
            counterDisk = new PerformanceCounter("PhysicalDisk", @"% Disk Time", @"_Total");    //sup de 90%
            counterCPU = new PerformanceCounter("Processor", @"% Processor Time", @"_Total");   //85%
            counterRAM = new PerformanceCounter("Memory", "Available MBytes");                  //moins de 50MB
        }

        //retourne la moyenne des performances de la machine des 30 dernieres secondes 
        public MachineInformation getAveragePerformance()
        {
            while (count <= 30)
            {
                machineInfo = getMachineInformation();

                //mise en place des informations dans des listes
                listInfoCPU.Add(machineInfo.infoCPU);
                listInfoDisk.Add(machineInfo.infoDisk);
                listInfoRAM.Add(machineInfo.infoRAM);

                count++;
                Thread.Sleep(1000);
            }

            //Calcul des moyennes
            machineInfo.infoCPU = calculate.calculMoyenne(listInfoCPU);
            machineInfo.infoRAM = calculate.calculMoyenne(listInfoRAM);
            machineInfo.infoDisk = calculate.calculMoyenne(listInfoDisk);

            return machineInfo;
        }

        //retourne les informations de la machine (RAM, CPU, Disque)
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