using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.OleDb;

using System.Data;

namespace classLibrary
{
    class DataAccess
    {

        private string connectionString = "Provider=OraOLEDB.Oracle;Data Source=192.168.128.152/ora11g;User Id=d5a03; Password=d5a;";
        private static OracleConnection;
        private OleDbConnection conn;


        public DataAccess()
        {
            this.connect();

        }

        public void connect()
        {
            using (conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    //MessageBox.Show("erfolgreich");
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void insert(Blob blob)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into blob_file ([filename],[filedata]) values ('" + blob.name + "','" + blob.bytes.ToString() + "')";
            cmd.Connection = this.conn;
            cmd.ExecuteNonQuery();
        }

    }
}
