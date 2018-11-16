using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StraßenNetzLib
{
    public class Database
    {
        private OleDbConnection connection;
        private OleDbTransaction transaction;

        public void Connect()
        {
            try
            {
                String connectionString = "Provider=OraOLEDB.Oracle; Data Source=192.168.128.152/ora11g; User Id = d4a06; Password = d4a; OLEDB.NET = True; ";
                this.connection = new OleDbConnection(connectionString);
                this.connection.Open();
            }
            catch (System.Exception _e) 
            {
                Console.WriteLine(_e.ToString());
            }

        }

        public void setTransactionSerializeable()
        {
            this.transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable);
        }

        public void setTransactionReadComitted()
        {
            this.transaction = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public void Disconnect()
        {
            connection.Close();
        }

        public List<Teilstrecke> getTeilstrecke(string comm)
        {
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            List<Teilstrecke> result = new List<Teilstrecke>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Teilstrecke(reader.GetString(0), new Point(decimal.ToInt32(reader.GetDecimal(1)), decimal.ToInt32(reader.GetDecimal(2))), new Point(decimal.ToInt32(reader.GetDecimal(3)), decimal.ToInt32(reader.GetDecimal(4)))));
                }
            }

            return result;
        }

        public List<Teilstrecke> getAllTeilstrecken()
        {
            string comm = "select * from teilstrecke";
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            List<Teilstrecke> result = new List<Teilstrecke>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Teilstrecke(reader.GetString(0), new Point(decimal.ToInt32(reader.GetDecimal(1)), decimal.ToInt32(reader.GetDecimal(2))), new Point(decimal.ToInt32(reader.GetDecimal(3)), decimal.ToInt32(reader.GetDecimal(4)))));
                }
            }

            return result;
        }

        public List<Abschnitt> getAbschnitte()
        {
            string select = "select * from abschnitt";
            OleDbCommand command = new OleDbCommand(select, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            List<Abschnitt> result = new List<Abschnitt>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Abschnitt(reader.GetString(0), reader.GetString(1)));
                    String o = getAbschnittLength(reader.GetString(0));
                }   
            }

            return result;
        }

        private void MyExecuteQuery(string comm)
        {
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            command.ExecuteNonQuery();
        }

        private string getAbschnittLength(string id)
        {
            string select = "select sum(round(sqrt((xe - xa) * (xe - xa) + (ye - ya) * (ye - ya)))) as länge from netz" +
                            " inner join teilstrecke on teilstrecke.ID = netz.ID_CHILD" + 
                            " inner join abschnitt on abschnitt.ID = netz.ID_PARENT" + 
                            " connect by prior ID_PARENT = ID_CHILD start WITH netz.ID_PARENT = '?'";
            string length = "";
            OleDbCommand command = new OleDbCommand(select.Replace("?", id), this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    length = reader.GetDataTypeName(0);
                }
            }
            return length;
        }
    }
}
