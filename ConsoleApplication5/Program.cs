using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Donnee;


namespace Metier
{
    class Program
    {
        static void Main()
        {
            MachinePerformance machineInfoPerf = new MachinePerformance();
            MachineInformation machineInfo = new MachineInformation();
            Calculate calcule = new Calculate();
            machineInfo = machineInfoPerf.getMachineInformation();
            machineInfo.infoCPU = calcule.calculMoyenne(machineInfo.listInfoCPU);
            machineInfo.infoRAM = calcule.calculMoyenne(machineInfo.listInfoRAM);
            machineInfo.infoDisk = calcule.calculMoyenne(machineInfo.listInfoDisk);
            Console.WriteLine("Disk : " + machineInfo.infoDisk + @" %; CPU : " + machineInfo.infoCPU + @" %; RAM : " + machineInfo.infoRAM + " MB");
            Console.Read();
        }
    }
}

