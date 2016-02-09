using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;
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
            TrackPerformance trackPerformance = new TrackPerformance();
            ObjectPerformance performance = new ObjectPerformance();
            MachineInformation machineInfo = new MachineInformation();
            machineInfo = trackPerformance.getAveragePerformance();

            //convertion des "," en "." pour l'insertion des doubles dans la base de données
            string stringCPU = machineInfo.infoCPU.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringRAM = machineInfo.infoRAM.ToString(CultureInfo.InvariantCulture.NumberFormat);
            string stringDisk = machineInfo.infoDisk.ToString(CultureInfo.InvariantCulture.NumberFormat);

            //insertion dans la base de données
            performance.insert(stringCPU, stringRAM, stringDisk);
        }
    }
}
