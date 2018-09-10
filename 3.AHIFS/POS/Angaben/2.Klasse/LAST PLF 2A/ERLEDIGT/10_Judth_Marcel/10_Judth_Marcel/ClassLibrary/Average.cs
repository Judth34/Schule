using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary
{
    public class Average
    {
        // KAA: Code-Struktur wenig nachvollziehbar !!
        public string Filename { get; set; }
        private Binarytree b = new Binarytree();
        private List<double> l = new List<double>();


        public Average(string NewFilename)
        {
            Filename = NewFilename;
        }


        public double[] CalculateAverage()
        {

            try
            {
                string[] lines = File.ReadAllLines(Filename);

                for(int idx = 0; idx < lines.Length; idx++)
                {
                    string[] line = lines[idx].Split(';');

                    for (int i = 0; i < line.Length; i++)
                    {
                        openFileAndSaveInTreeAndList(line[i]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return average();
        }


        private double[] average()
        {
            double[] average = new double[2];

            int alltreeValue = b.PreOrder();
            double allListValues = 0;

            for(int idx = 0; idx < l.Count; idx++)
            {
                allListValues += l[idx];
            }

            average[0] = alltreeValue / l.Count;
            average[1] = allListValues / l.Count;

            return average;
        }
       private void openFileAndSaveInTreeAndList(string filename)
        {
            try
            {
                // KAA: durch die schlechte Benennung der Variablen wird hier die config Datei 3x eingelesen!!!
                using (BinaryReader br = new BinaryReader(File.Open(Filename, FileMode.Open)))
                {
                    // KAA: wieso weniger 12??
                    while (br.BaseStream.Position < br.BaseStream.Length - 12)
                    {
                        b.Add(br.ReadInt32());
                        l.Add(br.ReadDouble());
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
