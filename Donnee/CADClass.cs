using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Donnee
{
    /// <summary>
    /// Cette classe permet la connexion a la base de donnée
    /// </summary>
    public class CADClass
    {
        private String cnx;
        private String SQLRequest;
        private SqlDataAdapter dataAdaptater;
        private SqlConnection connection;
        private SqlCommand command;
        private DataSet data;

        //constructeur
        public CADClass()
        {
            this.cnx = "Data Source=10.10.100.1;Initial Catalog=REDX;User ID=sa;Password=Exia123;MultipleActiveResultSets=True";
            this.SQLRequest = null;
            this.connection = new SqlConnection(this.cnx);
            this.dataAdaptater = null;
            this.command = null;
            this.data = new DataSet();
        }

        //fonction pour requetes d'actions
        public void ActionRows(string SQLRequest)
        {
            this.data = new DataSet();
            this.SQLRequest = SQLRequest;
            this.command = new SqlCommand(this.SQLRequest, this.connection);
            this.dataAdaptater = new SqlDataAdapter(this.command);
            this.dataAdaptater.Fill(this.data, "rows");
        }

        //fonction pour requetes de récupération de données
        public DataSet getRows(string SQLRequest)
        {
            this.data.Clear();
            this.SQLRequest = SQLRequest;
            this.command = new SqlCommand(this.SQLRequest, this.connection);
            this.connection.Open();
            this.dataAdaptater = new SqlDataAdapter(this.command);
            this.dataAdaptater.Fill(this.data, "rows");
            connection.Close();
            return this.data;
        }
    }
}