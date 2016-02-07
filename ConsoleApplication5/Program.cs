using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

public class TestPerfCounter
{
    static PerformanceCounter counterDisk;
    static PerformanceCounter counterRAM;
    static PerformanceCounter counterCPU;
    static double infoDisk;
    static double infoRAM;
    static double infoCPU;

    public static void Main()
    {
         infoDisk = 0;
         infoRAM = 0;
         infoCPU = 0;
        List<double> listInfoDisk = new List<double>();
        List<double> listInfoRAM = new List<double>();
        List<double> listInfoCPU = new List<double>();
        counterDisk = new PerformanceCounter("PhysicalDisk", @"% Disk Time", @"_Total"); //sup de 90%
        counterCPU = new PerformanceCounter("Processor", @"% Processor Time", @"_Total"); //85%
        counterRAM = new PerformanceCounter("Memory", "Available MBytes"); //moins de 50MB
        int count = 0;                      //Compteur

        while (count<=30)
        {
            //On récupère les info et on les met dans des listes
            listInfoDisk.Add(counterDisk.NextValue());
            listInfoCPU.Add(counterCPU.NextValue());
            listInfoRAM.Add(counterRAM.NextValue());

            //on calcule la moyenne de chaque liste
            infoCPU = calculMoyenne(listInfoCPU);
            infoRAM = calculMoyenne(listInfoRAM);
            infoDisk = calculMoyenne(listInfoDisk);

            Console.WriteLine(count);
            count++;
            Thread.Sleep(1000);
           
        }

        Console.WriteLine("Disk : " + infoDisk + @" %; CPU : " + infoCPU + @" %; RAM : " + infoRAM + " MB");
        Console.Read();
    }

    static double calculMoyenne(List<double> liste)
    {
        double total = 0;

        for (int i = 0; i < liste.Count; i++)
        {
            total += liste[i];
        }

        return total / liste.Count;
    }
}

