using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Donnee;
using System.Data;

namespace MetierApplication
{
    /// <summary>
    /// Cette classe permet la gestion dans la base de donnée de la table Performance
    /// </summary>
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

        /// <summary>
        /// permet l'execution de la requete select et retourne la derniere valeur
        /// </summary>
        /// <returns></returns>
        public DataSet selectLast()
        {
            this.data = cad.getRows(mapPerformance.selectLast());
            return data;
        }
    }
}
