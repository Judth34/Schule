using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PLF_LIB
{
    public class Loader
    {
        #region Eigenschaften

        public string Filename;

        #endregion

        #region Public-Methods

        public void LoadAllTreesAndLists(out SimpleTree T, out SimpleList L)
        {
            //Tree und Liste erzeugen
            T = new SimpleTree();
            L = new SimpleList();

            //Alle Files laden
            foreach (string path in LoadPaths(Filename))
            {
                if (path != "")
                {
                    LoadTreeAndList(path, ref T, ref L);
                } 
            }
        }

        #endregion

        #region Private-Methods

        private void LoadTreeAndList(string path, ref SimpleTree T, ref SimpleList L)
        {
            //Null-Reference Exception vermeiden
            if (T == null || L == null)
            {
                throw new Exception("Die Liste und der Tree müssen bereits vor dem Laden erzeugt werden!");
            }

            //Laden
            using (BinaryReader BR = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                int counter = 0;
                while (BR.BaseStream.Position < BR.BaseStream.Length)
                {
                    //Int lesen
                    if (counter % 2 == 0)
                    {
                        T.Add(BR.ReadInt32());
                    }

                    //Double lesen
                    else
                    {
                        L.Add(BR.ReadDouble());
                    }
                    counter++;
                }
            }
        }
        private string[] LoadPaths(string path)
        {
            //Zeile(n) einlesen
            string[] AllLines = File.ReadAllLines(path);

            //Splitten
            string [] Filenames = AllLines[0].Split(';');

            //Rückgabe
            return Filenames;
        }

        #endregion
    }
}
