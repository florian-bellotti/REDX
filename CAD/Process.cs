using Donnee;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD
{
    class Process
    {
        private DataSet ods;
        private MappageMachineInformation map;
        private CADClass cad;
        private String rq_sql;

        public Process()
        {
            this.ods = new DataSet();
            this.map = new MappageMachineInformation();
            this.cad = new CADClass();
            this.rq_sql = "";
        }

        public DataSet afficher(String tableName)
        {
            this.ods.Clear();
            rq_sql = map.selectAll();
            ods = cad.getRows(rq_sql);
            return this.ods;
        }
    }
}
