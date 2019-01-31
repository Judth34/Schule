using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_BLOB_Textfiles
{
    class Database
    {
        static private OracleConnection connection;
        //private string connectionStringOracle = "Data Source=212.152.179.117/ora11g;PERSIST SECURITY INFO=True;User Id = d5a06; Password = d5a;";
        private string connectionStringOracle = "Data Source=192.168.128.152/ora11g;PERSIST SECURITY INFO=True;User Id = ctxsys; Password = ctxsys;";


        public Database()
        {
            try
            {
                this.connect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void connect()
        {
            connection = new OracleConnection(this.connectionStringOracle);
            connection.Open();
        }

        internal static void insert(string bytes)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select max(id) as id from archive_06";
            cmd.Connection = connection;
            OracleDataReader dr = cmd.ExecuteReader();
            int idmax = 0;
            if (dr.HasRows)
                idmax = int.Parse(dr["id"].ToString());

        }
    }
}
