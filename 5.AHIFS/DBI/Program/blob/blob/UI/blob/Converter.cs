using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blob
{
    public static class Converter
    {
        public static class Convert
        {
            public static void toTextFile(OracleConnection connection, String filename, String resultPath)
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

    }
}
