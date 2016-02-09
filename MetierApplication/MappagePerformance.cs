using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Data;

namespace MetierApplication
{
    public class MappagePerformance
    {
        private CADClass cad;
        private DataSet data;

        public MappagePerformance()
        {
            cad = new CADClass();
            data = new DataSet();
        }

        public DataSet selectAll()
        {
            string SQLRequest = "SELECT TOP 1 CPU, RAM, Disk from Performance where Id_machine = (Select Id_machine from Machine where Name_machine = '" + Environment.MachineName + "') ORDER BY Date Desc";
            this.data = cad.getRows(SQLRequest);
            return data;
        }
    }
}
