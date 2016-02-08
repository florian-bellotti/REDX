using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;

namespace Metier
{
    public class MappageMachineInformation
    {
        private CADClass cad;

        public void insert(string CPU, string RAM, string Disk)
        {
            DateTime Date = DateTime.Now;
            string SQLRequest = "INSERT INTO Performance([CPU], [RAM], [Disk], [Date], [Id_Machine]) VALUES('" + CPU + "', '" + RAM + "', '" + Disk + "', '" + Date + "', '1'); ";
            cad = new CADClass();
            cad.ActionRows(SQLRequest);
        }
    }
}
