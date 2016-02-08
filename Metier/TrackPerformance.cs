using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Threading;

namespace Metier
{
    public class TrackPerformance
    {
        public MachineInformation machineInfo;
        private MachinePerformance machinePerf;
        private Calculate calculate;
        private List<double> listInfoDisk;
        private List<double> listInfoRAM;
        private List<double> listInfoCPU;

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
        }

        public MachineInformation getAveragePerformance()
        {
            machinePerf = new MachinePerformance();

            while (count <= 15)
            {
                machineInfo = machinePerf.getMachineInformation();
                
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
    }
}