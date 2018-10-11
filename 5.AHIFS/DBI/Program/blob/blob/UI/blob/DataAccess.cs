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
using Oracle.DataAccess.Client;
using System.IO;

namespace classLibrary
{
    class DataAccess
    {

        private const String connectionString = "Data Source=192.168.128.152:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d5a03;Password=d5a";
        public const String defaultResultPath = "./result";
        private static OracleConnection connection;


        public DataAccess()
        {
            try
            {
                this.connect();
            }
            catch(Exception error)
            {
                throw error;
            }
        }

        public void connect()
        {
            try
            {
                DataAccess.connection = new OracleConnection(connectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }   
        }

       
        public class Blob
        {
            public byte[] bytes { get; set; }
            public string name { get; set; }
            public int id { get; set; }


            public Blob(int id, string name,byte[] bytes)
            {
                this.id = id;
                this.bytes = bytes;
                this.name = name;
            }

            public override string ToString()
            {
                return "Blob: " + id + " " + name;
            }

            //static
            public static List<Blob> get()
            {
                List<Blob> blobs = new List<Blob>();
                OracleCommand command = new OracleCommand();
                command.CommandText = "select id,filename, filedata from blob_file";
                command.Connection = connection;
                
                OracleDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Blob blob = new Blob(1, Convert.ToString(dr["filename"]), new byte[100]);
                        blobs.Add(blob);
                    }
                }
                return blobs;
            }

            public static void insert(Blob blob)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = "insert into blob_file values(null,:filename,:bytes)";
                cmd.Parameters.Add(new OracleParameter("filename", blob.name));             
                cmd.Parameters.Add(new OracleParameter("bytes", blob.bytes));
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            
            public static byte[] convert(String filepath)
            {
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read); //A stream of bytes that represnts the binary file
                BinaryReader reader = new BinaryReader(fs);  //The reader reads the binary data from the file stream
                byte[] bytes = reader.ReadBytes((int)fs.Length);  //Bytes from the binary reader stored in BlobValue array
                MessageBox.Show(bytes.Length.ToString());
                fs.Close();
                reader.Close();
                return bytes;
            }
            
        }

        public static class Converter
        {
            public static class Convert
            {
                public static void toTxt(String filename, String resultPath)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select filedata from blob_file where filename = :filename";
                    cmd.Parameters.Add(new OracleParameter("filename", filename));
                    
                    OracleDataReader reader = cmd.ExecuteReader();

                    long CurrentIndex = 0;
                    int BufferSize = 10;
                    long BytesReturned;
                    byte[] Blob = new byte[BufferSize];
                    resultPath = resultPath + ".txt";

                    while (reader.Read())
                    {
                        FileStream fs = new FileStream(resultPath, FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(fs);
                        CurrentIndex = 0;


                        BytesReturned = reader.GetBytes(0, CurrentIndex, Blob, 0, BufferSize);

                        while (BytesReturned == BufferSize)

                        {
                            writer.Write(Blob);

                            writer.Flush();
                            CurrentIndex += BufferSize;

                            BytesReturned = reader.GetBytes(0, CurrentIndex, Blob, 0, BufferSize);

                        }
                        writer.Write(Blob, 0, (int)BytesReturned);

                        writer.Flush(); writer.Close();
                        fs.Close();
                        Blob = new byte[BufferSize];
                    }

                    reader.Close();
                }

                public static void toPdf(String filename, String resultPath)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "select filedata from blob_file where filename = :filename";
                    cmd.Parameters.Add(new OracleParameter("filename", filename));

                    OracleDataReader reader = cmd.ExecuteReader();

                    long CurrentIndex = 0;
                    int BufferSize = 10;
                    long BytesReturned;
                    byte[] Blob = new byte[BufferSize];
                    resultPath = resultPath + ".pdf";

                    while (reader.Read())
                    {
                        FileStream fs = new FileStream(resultPath, FileMode.OpenOrCreate, FileAccess.Write);
                        BinaryWriter writer = new BinaryWriter(fs);
                        CurrentIndex = 0;


                        BytesReturned = reader.GetBytes(0, CurrentIndex, Blob, 0, BufferSize);

                        while (BytesReturned == BufferSize)

                        {
                            writer.Write(Blob);

                            writer.Flush();
                            CurrentIndex += BufferSize;

                            BytesReturned = reader.GetBytes(0, CurrentIndex, Blob, 0, BufferSize);

                        }
                        writer.Write(Blob, 0, (int)BytesReturned);

                        writer.Flush(); writer.Close();
                        fs.Close();
                        Blob = new byte[BufferSize];
                    }

                    reader.Close();
                }

            }

            public static String getExtension(string filename)
            {
                String[] result = filename.Split('.');
                return result[result.Length - 1];
            }

        }
    }
}
