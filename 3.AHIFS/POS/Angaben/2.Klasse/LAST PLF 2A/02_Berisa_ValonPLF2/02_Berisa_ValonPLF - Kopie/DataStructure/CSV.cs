using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Berisa_ValonPLF
{
    public class CSV
    {
        public string Filename { get; private set; }
        public CSV(string Filename)
        {
            this.Filename = Filename;
        }
        public string[] LoadCSV()
        {
            string[] binaryFileNames = File.ReadAllLines(Filename);       
            return Splitter(binaryFileNames); 
        }    
        private string[] Splitter(string[] binaryFileNames)
        {
            string[] Split = null;
            return binaryFileNames[0].Split(';'); ;
        }
        
    }
}
