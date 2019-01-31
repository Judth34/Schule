using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.IO;
using System.Security.Cryptography;

namespace _001_BLOB_Browser_Lib
{
    public class DataAccess
    {
        private OracleConnection connection;
        private string connectionStringOracle = "Data Source=212.152.179.117/ora11g;PERSIST SECURITY INFO=True;User Id = d5a06; Password = d5a;";
        //private string connectionStringOracle = "Data Source=192.168.128.152/ora11g;PERSIST SECURITY INFO=True;User Id = ctxsys; Password = ctxsys;";
        private byte[] key = Encoding.ASCII.GetBytes("abcdef");
        private byte[] IV = Encoding.ASCII.GetBytes("fedcba");


        public DataAccess()
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

        #region public-mehtods
        public void insert(string filename, string safeFilename, Location loc)
        {
            byte[] bytes = this.convert(filename);
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "insert into archive_06 values(SEQ_ARCHIVE_06.nextVal,:filename,:bytes, :locationid)";
            cmd.Parameters.Add(new OracleParameter("filename", safeFilename));
            cmd.Parameters.Add(new OracleParameter("bytes", bytes));
            cmd.Parameters.Add(new OracleParameter("locationid", loc.id));

            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
        }

        public List<Blob> get()
        {
            List<Blob> result = new List<Blob>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select id, filename, bytes, idLocation from archive_06";
            cmd.Connection = connection;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Blob blob = new Blob(int.Parse(dr["id"].ToString()), Convert.ToString(dr["filename"]), (byte[])dr["bytes"], int.Parse(dr["idLocation"].ToString()));
                    result.Add(blob);
                }
            }
            return result;
        }

        public List<Location> getLocations()
        {
            List<Location> result = new List<Location>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select l.loc_id, l.loc_name, t.X, t.Y from docs_location_A06 l, TABLE(SDO_UTIL.GETVERTICES(l.loc)) t";
            cmd.Connection = connection;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    Location blob = new Location(int.Parse(dr["loc_id"].ToString()), Convert.ToString(dr["loc_name"]), int.Parse(dr["X"].ToString()), int.Parse(dr["Y"].ToString()));
                    result.Add(blob);
                }
            }
            return result;
        }

        public void save(Blob blob, string filename)
        {
            if (blob == null)
                throw new Exception("Blob is null!!");
            this.convert(blob.filename, blob.bytes);
            System.Diagnostics.Process.Start(blob.filename);
        }

        public List<Blob> SearchInDoc(string suchtext)
        {
            List<Blob> result = new List<Blob>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select id, filename, bytes, idLocation from archive_06 where dbms_lob.instr(bytes, utl_raw.cast_to_raw('" + suchtext + "'), 1, 1) > 0;";
            cmd.Connection = connection;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Blob blob = new Blob(int.Parse(dr["id"].ToString()), Convert.ToString(dr["filename"]), (byte[])dr["bytes"], int.Parse(dr["idLocation"].ToString()));
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

        public void convert(string filepath, byte[] data)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(data);
            fs.Close();
            writer.Close();
        }

        private byte[] encrypt(byte[] data)
        {
            byte[] encrypted;
            using (MemoryStream mstream = new MemoryStream())
            {
                using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(mstream, aesProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                    }
                }
                encrypted = mstream.ToArray();
            }
            return encrypted;
        }

        private byte[] decrypt(byte[] bytes)
        {
            var length = bytes.Length;

            using (MemoryStream mStream = new MemoryStream(bytes))
            using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider() { Padding = PaddingMode.None })
            using (CryptoStream cryptoStream = new CryptoStream(mStream, aesProvider.CreateDecryptor(key, IV), CryptoStreamMode.Read))
            {
                cryptoStream.Read(bytes, 0, length);
                return mStream.ToArray().Take(length).ToArray();
            }
        }
        #endregion

        #region inner-class

        public class Location
        {
            public int id { get; set; }
            public string name { get; set; }
            public int xCoo { get; set; }
            public int yCoo { get; set; }

            public Location(string name, int xCoo, int yCoo)
            {
                this.name = name;
                this.xCoo = xCoo;
                this.yCoo = yCoo;
            }

            public Location(int id, string name, int xCoo, int yCoo)
            {
                this.id = id;
                this.name = name;
                this.xCoo = xCoo;
                this.yCoo = yCoo;
            }

            override public string ToString()
            {
                return id + ", location: " + this.name;
            }
        }

        public class Blob
        {
            public int id { get; set; }
            public byte[] bytes { get; set; }
            public string filename { get; set; }
            public int locationId { get; set; }

            public Blob(int id, string filename, byte[] bytes, int locationId)
            {
                this.id = id;
                this.filename = filename;
                this.bytes = bytes;
                this.locationId = locationId;
            }

            override public string ToString()
            {
                return id + ", filename: " + this.filename + ", locationID: " + this.locationId;
            }
        }


        #endregion

    }
}