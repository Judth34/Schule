using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.IO;

namespace _001_BLOB_Browser_Lib
{
    public class DataAccess
    {
        private OracleConnection connection;
        private string connectionStringOracle = "Data Source=212.152.179.117/ora11g;PERSIST SECURITY INFO=True;User Id = d5a06; Password = d5a;";


        public DataAccess()
        {
            try
            {
                this.connect();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        #region public-mehtods
        public void insert(string filename)
        {
            byte[] bytes = this.convert(filename);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "insert into LARGEOBJECTS values(SEQ_LARGEOBJECTS.nextVal,:filename,:bytes)";
            cmd.Parameters.Add(new OracleParameter("filename", filename));
            cmd.Parameters.Add(new OracleParameter("bytes", bytes));
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public List<Blob> get()
        {
            List<Blob> result = new List<Blob>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select id, filename, data from LARGEOBJECTS";
            cmd.Connection = connection;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Blob blob = new Blob(int.Parse(dr["id"].ToString()), Convert.ToString(dr["filename"]), (byte[])dr["Data"]);
                    result.Add(blob);
                }
            }
            return result;
        }
        #endregion


        #region private-methods
        private void connect()
        {
            this.connection = new OracleConnection(this.connectionStringOracle);
            this.connection.Open();
        }

        public byte[] convert(String filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read); //A stream of bytes that represnts the binary file
            BinaryReader reader = new BinaryReader(fs);  //The reader reads the binary data from the file stream
            byte[] bytes = reader.ReadBytes((int)fs.Length);  //Bytes from the binary reader stored in BlobValue array
            fs.Close();
            reader.Close();
            return bytes;
        }
        #endregion

        #region inner-class
        public class Blob
        {
            public int id { get; set; } 
            public byte[] bytes { get; set; }
            public string filename { get; set; }

            public Blob(int id, string filename, byte[] bytes)
            {
                this.id = id;
                this.filename = filename;
                this.bytes = bytes;
            }

            override public string ToString()
            {
                return id + ", filename: " + this.filename;
            }
        }
        #endregion

    }
}
