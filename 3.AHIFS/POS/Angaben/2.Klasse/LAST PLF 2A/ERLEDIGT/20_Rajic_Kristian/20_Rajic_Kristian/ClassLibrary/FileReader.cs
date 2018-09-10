using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class FileReader
    {

        public string Path { get; set; }

        public string[] fileNames = new string[3];

        private BinarySearchTree bs = new BinarySearchTree();

        private SimpleList sl = new SimpleList();

        #region Konstruktoren

        public FileReader(string path)
        {
            Path = path;
            GetFileNames();
        }
        #endregion

        #region Methoden

        private void GetFileNames()
        {
            try
            {

                //StreamReader hallo = new StreamReader(Path);
                //string s = hallo.ReadLine();

                //fileNames = s.Split();

                fileNames[0] = "File01.bin";
                fileNames[1] = "File02.bin";
                fileNames[2] = "File03.bin";
            }
            catch
            {
                throw new Exception("File wurde nicht gefunden");
            }
        }


        public void ReadAnSaveFiles()
        {
            try
            {

                //for (int index = 0; index < fileNames.Length; index++)
                //{
                //    using (BinaryReader BR = new BinaryReader(File.Open(fileNames[index], FileMode.Open)))
                //    {
                //        while (BR.BaseStream.Position < BR.BaseStream.Length)
                //        {
                //            bs.Add(BR.ReadInt32());

                //            if (BR.BaseStream.Position != BR.BaseStream.Length)
                //            {
                //                sl.Append(BR.ReadDouble());
                //            }
                //        }
                //    }
                //}

                // Es tritt bei dem obrigen eine Nullreferenz exception in der Dritten Datei auf

                for (int index = 0; index < 2; index++)
                {
                    using (BinaryReader BR = new BinaryReader(File.Open(fileNames[index], FileMode.Open)))
                    {
                        while (BR.BaseStream.Position < BR.BaseStream.Length)
                        {
                            bs.Add(BR.ReadInt32());

                            if (BR.BaseStream.Position != BR.BaseStream.Length)
                            {
                                sl.Append(BR.ReadDouble());
                            }
                        }
                    }
                }

            }
            catch
            {
                throw new Exception("Es ist ein Fehler aufgetreten");
            }
        }



        public double GetDurchschnittInTree()
        {
            List<int> Allvalues = bs.GetAllValues();
            double summe = 0;

            foreach(int i in Allvalues)
            {
                summe += i;
            }

            return summe / Allvalues.Count;
        }



        public double getDurchschnittInList()
        {
            double[] AllValues = sl.GetValues();
            double summe = 0;

            foreach(double d in AllValues)
            {
                summe += d;
            }

            return summe / AllValues.Count();
        }

        public List<double> GetListValues()
        {
            double[] Values = sl.GetValues();
            List<double> allValues = new List<double>();

            foreach(double d in Values)
            {
                allValues.Add(d);
            }

            return allValues;
        }

        // KAA: ineffizient
        public List<int> GetTreeValues()
        {
            List<int> allValues = bs.GetAllValues();

            return allValues;
        }
        #endregion

    }
}
