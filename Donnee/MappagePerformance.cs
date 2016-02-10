using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnee
{
    /// <summary>
    /// Cette classe retourne les requetes concernant la table Performance
    /// </summary>
    public class MappagePerformance
    {
        //retourne la requete permettant de récuperer le dernier enregistrement de la table Performance
        public string selectLast()
        {
            return "SELECT TOP 1 CPU, RAM, Disk from Performance where Id_machine = (Select Id_machine from Machine where Name_machine = '" + Environment.MachineName + "') ORDER BY Date Desc";
        }

        //retourne la requete permet de faire un nouvel enregistrement
        public string insert(string CPU, string RAM, string Disk)
        {
            return " INSERT INTO Performance([CPU], [RAM], [Disk], [Id_Machine]) VALUES('" + CPU + "', '" + RAM + "', '" + Disk + "', (Select Id_machine from Machine where Name_machine = '" + Environment.MachineName + "')); ";
        }
    }
}