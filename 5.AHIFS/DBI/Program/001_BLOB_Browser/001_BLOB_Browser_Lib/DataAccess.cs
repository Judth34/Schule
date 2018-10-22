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
        private string connectionStringOracle = "Data Source=192.168.128.152/ora11g;PERSIST SECURITY INFO=True;User Id = d5a06; Password = d5a;";
        private byte[] key = Encoding.ASCII.GetBytes("abcdef");
        private byte[] IV = Encoding.ASCII.GetBytes("fedcba");


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

        public void save(Blob blob)
        {
            if (blob == null)
                throw new Exception("Blob is null!!");
            this.convert(blob.filename, blob.bytes);
            System.Diagnostics.Process.Start(blob.filename);
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
            return this.encrypt(bytes);
        }

        public void convert(string filepath, byte[] data)
        {
            if (File.Exists(filepath))
                File.Delete(filepath);
            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            byte[] decrypted = this.decrypt(data);
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
