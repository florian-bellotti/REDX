using System;
using System.Threading;
using System.Diagnostics;

public class TestPerfCounter
{
    static PerformanceCounter counterDisk;
    static PerformanceCounter counterRAM;
    static PerformanceCounter counterCPU;


    public static void Main()
    {
        double infoDisk;
        double infoRAM;
        double infoCPU;
    counterDisk = new PerformanceCounter("PhysicalDisk", @"% Disk Time", @"_Total"); //sup de 90%
        counterCPU = new PerformanceCounter("Processor", @"% Processor Time", @"_Total"); //85%
        counterRAM = new PerformanceCounter("Memory", "Available MBytes"); //moins de 50MB
        while (true)
        {
            infoDisk = counterDisk.NextValue();
            infoCPU = counterCPU.NextValue();
            infoRAM = counterRAM.NextValue();
            Console.WriteLine("Disk : " + infoDisk + @" %; CPU : " + infoCPU + @" %; RAM : " + infoRAM + " MB");
            if ((infoDisk >= 90) || (infoRAM <= 50) || (infoCPU >= 85))
            {
                Console.WriteLine("Erreur !!");
            }
            Thread.Sleep(1000);
            Console.WriteLine(@"-------------------------------------");
        }
    }
}