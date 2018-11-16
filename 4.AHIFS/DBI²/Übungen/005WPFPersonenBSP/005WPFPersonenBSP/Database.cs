using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace _005WPFPersonenBSP
{
    class Database
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
                // Exceptionhandling
                // throw new MyException("Connect-Error ",_e);
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

        public List<Person> get_Person(string comm)
        {
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            List<Person> result = new List<Person>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Person(reader.GetDecimal(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDecimal(3)));
                }
            }

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

        public List<string> get_Headers(string comm)
        {
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            OleDbDataReader reader = command.ExecuteReader();
            List<string> resutl = new List<string>();

            resutl.Add(reader.GetName(0));
            resutl.Add(reader.GetName(1));
            resutl.Add(reader.GetName(2));
            resutl.Add(reader.GetName(3));

            return resutl;
        }

        private void MyExecuteQuery(string comm)
        {
            OleDbCommand command = new OleDbCommand(comm, this.connection);
            command.ExecuteNonQuery();
        }

        
    }
}
