using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Durchschnittsberechnung
{
    public static class Files
    {
        public static string[] GetToReadFilesFromTxtFile(string path)
        {
            StreamReader myReader = null;
            string[] files;
            try
            {
                myReader = new StreamReader(path);
                files = myReader.ReadLine().Split(';');
            }
            catch(FileNotFoundException)
            {
                throw new FileNotFoundException("File wurde nicht gefunden!");
            }
            catch(Exception)
            {
                throw new Exception("Unbekannter Fehler!");
            }
            finally
            {
                myReader.Close();
            }
            return files;
        }

        // KAA: nicht effizient das zweimal zu tun >> das kann man in einem Durchgang erledigen!
        public static BinarySearchTree LoadIntsToBinaryTree(string[] files)
        {
            BinarySearchTree myTree = new BinarySearchTree();
            // KAA: besser wäre es den letzten, leeren Filename wegzufiltern
            for (int idx = 0; idx < (files.Length - 1); idx++)
            {
                using (BinaryReader br = new BinaryReader(File.Open(files[idx], FileMode.Open)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        myTree.Add(br.ReadInt32());
                        br.ReadDouble();
                    }
                }
            }
            return myTree;
        }

        public static SimpleList LoadDoublesToSimpleList(string[] files)
        {
            SimpleList myList = new SimpleList();

            for (int idx = 0; idx < (files.Length - 1); idx++)
            {
                using (BinaryReader br = new BinaryReader(File.Open(files[idx], FileMode.Open)))
                {
                    while (br.BaseStream.Position < br.BaseStream.Length)
                    {
                        br.ReadInt32();
                        myList.Append(br.ReadDouble());
                    }
                }
            }
            return myList;
        }
    }
}
