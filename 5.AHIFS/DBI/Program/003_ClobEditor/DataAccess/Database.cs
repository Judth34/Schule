using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Database
    {
        const string TABLE = "ctxsys.documents_18";
        OracleConnection connection;
        OracleDependency dependency;
        OracleTransaction transaction;


        public void connect()
        {
            try
            {
                connection = new OracleConnection("Data Source=192.168.128.152:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d5a18;Password=d5a");
                connection.Open();
            }
            catch (OracleException e)
            {
                connection = new OracleConnection("Data Source=212.152.179.117:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d5a18;Password=d5a");
                connection.Open();
            }

            // create dependency
            OracleCommand command = new OracleCommand("select * from " + TABLE + "", connection);
            dependency = new OracleDependency(command);
            dependency.QueryBasedNotification = false;
            command.Notification.IsNotifiedOnce = false;

            //dependency.OnChange += new OnChangeEventHandler();
            command.ExecuteNonQuery();
        }


        public List<string> loadFiles()
        {
            List<string> filenames = new List<string>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT filename FROM " + TABLE + "";
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
                filenames.Add(reader.GetString(0));
            return filenames;
        }

        public string LoadContent(string filename)
        {
            string content = "";
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT text FROM " + TABLE + " WHERE filename = :filename";
            command.Parameters.Add(new OracleParameter(":filename", filename));
            OracleDataReader reader = command.ExecuteReader();

            if (reader.Read())
                content = reader.GetString(0);


            return content;
        }

        public void addFile(string filename, string content)
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO " + TABLE + " VALUES(:filename, :filedata)";
            command.Parameters.Add(new OracleParameter(":filename", OracleDbType.Varchar2, filename, ParameterDirection.Input));
            command.Parameters.Add(new OracleParameter(":filedata", OracleDbType.Clob, content, ParameterDirection.Input));
            command.ExecuteNonQuery();
        }

        public void edit(string listboxString)
        {
            transaction = connection.BeginTransaction(IsolationLevel.Serializable);


            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM " + TABLE + " WHERE filename = :fn FOR UPDATE NOWAIT";
            command.Parameters.Add(":fn", listboxString);
            command.Transaction = transaction;
            command.ExecuteNonQuery();
        }

        public void rollback()
        {
            transaction.Rollback();
        }

        public void save(string filename, string content)
        {
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE " + TABLE + " SET text = :content WHERE filename = :filename";
            command.Parameters.Add(new OracleParameter(":content", OracleDbType.Clob, content, ParameterDirection.Input));
            command.Parameters.Add(new OracleParameter(":filename", OracleDbType.Varchar2, filename, ParameterDirection.Input));
            command.Transaction = transaction;
            command.ExecuteNonQuery();

            transaction.Commit();
        }

        public List<string> filterFiles(string search)
        {
            List<string> filenames = new List<string>();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT filename FROM " + TABLE + " WHERE CONTAINS(text, :searchstr, 1) > 0";
            command.Parameters.Add(new OracleParameter(":searchstr", search));

            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
                filenames.Add(reader.GetString(0));
            return filenames;
        }

        public void synchIdx()
        {
            OracleCommand cmd = connection.CreateCommand();
            //cmd.Transaction = transaction;
            cmd.CommandText = "ctx_ddl.sync_index";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("indexnameparam", "DOCS_IDX_18");
            cmd.Parameters.Add("indexsizeparam", "2M");
            cmd.ExecuteNonQuery();
        }
    }
}
