using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnee
{
    public class MappageMachineInformation
    {
        public string insert(string CPU, string RAM, string Disk)
        {
            //test commit
            DateTime Date = DateTime.Now;
            return "INSERT INTO MachineInformation([CPU], [RAM], [Disk], [Date], [Id_Machine]) VALUES('" +  CPU + "', '" + RAM + "', '" + Disk + "', '" + Date + "', '1'); ";
        }
    }
}
