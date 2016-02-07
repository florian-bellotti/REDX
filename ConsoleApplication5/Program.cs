using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;


namespace ConsoleApplication5
{
    class Program
    {
        static void Main()
        {
            MachinePerformance machineInfo = new MachinePerformance();
            machineInfo.getMachineInformation();
            Console.Read();
        }
    }
}

