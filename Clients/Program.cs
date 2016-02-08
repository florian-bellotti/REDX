using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
using Donnee;
using System.Globalization;

namespace Clients
{
    class Program
    {
        /*static MappageMachineInformation mapMachineInfo;
        static TrackPerformance trackPerformance;
        static MachineInformation machineInfo;*/

        static void Main(string[] args)
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
