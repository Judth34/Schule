using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using PersonenLib;
using System.Windows;

namespace StraßenNetzLib
{
    public class Database
    {
        private OracleTransaction transaction;
        private OracleConnection connection;


        public Database()   
        {
            this.Connect();
        }

        #region general
        private void Connect()
        {
            try
            {
                string connectionStringOracle = "Data Source=192.168.128.152/ora11g;PERSIST SECURITY INFO=True;User Id = d4a06; Password = d4a;";
                this.connection = new OracleConnection(connectionStringOracle);
                this.connection.Open();
            }
            catch (System.Exception _e) 
            {
                throw new Exception(_e.ToString());
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
            this.connection.Clone();
        }

        private void MyExecuteQuery(string comm)
        {
            OracleCommand command = new OracleCommand(comm, this.connection);
            command.ExecuteNonQuery();
        }
        #endregion

        #region Teilstrecken-commands

        public List<Teilstrecke> getTeilstrecke(string comm)
        {
            OracleCommand command = new OracleCommand(comm, this.connection);
            OracleDataReader reader = command.ExecuteReader();
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
            OracleCommand command = new OracleCommand(comm, this.connection);
            OracleDataReader reader = command.ExecuteReader();
            List<Teilstrecke> result = new List<Teilstrecke>();
            if (reader.HasRows)
                while (reader.Read())
                    result.Add(new Teilstrecke(reader.GetString(0), new Point(decimal.ToInt32(reader.GetDecimal(1)), decimal.ToInt32(reader.GetDecimal(2))), new Point(decimal.ToInt32(reader.GetDecimal(3)), decimal.ToInt32(reader.GetDecimal(4)))));

            return result;
        }

        #endregion

        #region Abschnitte-commands
        public List<Abschnitt> getAbschnitte()
        {
            string select = "select * from abschnitt";
            OracleCommand command = new OracleCommand(select, this.connection);
            OracleDataReader reader = command.ExecuteReader();
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
        #endregion

        #region Zuteilung-commands
        public List<Zuteilung> getZuteilungen()
        {
            string select = "select * from zuteilung";
            OracleCommand command = new OracleCommand(select, this.connection);
            OracleDataReader reader = command.ExecuteReader();
            List<Zuteilung> result = new List<Zuteilung>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Zuteilung(reader.GetDecimal(0), reader.GetString(1)));
                }
            }

            return result;
        }

        public void addZuteilung(Zuteilung z)
        {
            string comm = "insert into Zuteilung values(" + z.person + ", ' " + z.abschnitt + "')";
            this.MyExecuteQuery(comm);
        }

        private string getAbschnittLength(string id)
        {
            string select = "select sum(round(sqrt((xe - xa) * (xe - xa) + (ye - ya) * (ye - ya)))) as länge from netz" +
                            " inner join teilstrecke on teilstrecke.ID = netz.ID_CHILD" + 
                            " inner join abschnitt on abschnitt.ID = netz.ID_PARENT" + 
                            " connect by prior ID_PARENT = ID_CHILD start WITH netz.ID_PARENT = '?'";
            string length = "";
            OracleCommand command = new OracleCommand(select.Replace("?", id), this.connection);
            OracleDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    length = reader.GetDataTypeName(0);
                }
            }
            return length;
        }
        #endregion

        #region Person-commands
        public List<Person> get_Person(string comm)
        {
            OracleCommand command = new OracleCommand(comm, this.connection);
            OracleDataReader reader = command.ExecuteReader();
            List<Person> result = new List<Person>();
            if (reader.HasRows)
                while (reader.Read())
                    result.Add(new Person(reader.GetDecimal(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDecimal(3)));

            return result;
        }

        public void update_Person(string comm)
        {
            this.MyExecuteQuery(comm);
        }

        public void delete_Person(string comm)
        {
            this.MyExecuteQuery(comm);
        }

        public void insert_Person(string comm)
        {
            this.MyExecuteQuery(comm);
        }
        #endregion
    }
}
