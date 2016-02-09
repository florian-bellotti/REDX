using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Data;

namespace Metier
{
    public class MappageMachineInformation
    {
        private CADClass cad;
        private DataSet data;

        public MappageMachineInformation()
        {
            cad = new CADClass();
            data = new DataSet();
        }

        public void insert(string CPU, string RAM, string Disk)
        {
            DateTime Date = DateTime.Now;
            string SQLRequest = "INSERT INTO Performance([CPU], [RAM], [Disk], [Date], [Id_Machine]) VALUES('" + CPU + "', '" + RAM + "', '" + Disk + "', '" + Date + "', (Select Id_machine from Machine where Name_machine = '" + Environment.MachineName + "')); ";
            cad = new CADClass();
            cad.ActionRows(SQLRequest);
        }
    }
}
