using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Data;

namespace Metier
{
    //cette classe permet la gestion dans la base de donnée de la table Performance
    public class ObjectPerformance
    {
        private CADClass cad;
        private DataSet data;
        private MappagePerformance mapPerformance;

        public ObjectPerformance()
        {
            cad = new CADClass();
            data = new DataSet();
            mapPerformance = new MappagePerformance();
        }

        //permet l'execution de la requete d'insert
        public void insert(string CPU, string RAM, string Disk)
        {
            string SQLRequest = mapPerformance.insert(CPU, RAM, Disk);
            cad.ActionRows(SQLRequest);
        }
    }
}
