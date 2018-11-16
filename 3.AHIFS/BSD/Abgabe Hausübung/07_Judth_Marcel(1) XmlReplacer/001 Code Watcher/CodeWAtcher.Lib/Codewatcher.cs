using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeWAtcher.Lib
{
    public class Codewatcher
    {
        public string generatedHtmlFilename { get; private set; }

        public Codewatcher()
        {
            generatedHtmlFilename = @".\Seite.html";
        }

        #region öffentliche-Methoden

        public void GenerateNewSite(string PathText, string PathNames)
        {
            string s = readTextfile(PathText);
            string[] names = readNamesFromCsv(PathNames);
            string text = changeNames(names, s);
            saveReplacedHtmlDoc(text);

        }
        #endregion

        #region private-Methoden
        private string readTextfile(string Path)
        {
            string[] allLines = null;
            string text = null;
            try
            {
                allLines = File.ReadAllLines(Path);
                for (int i = 0; i < allLines.Length; i++)
                {
                    text += allLines[i];
                }
                return text;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("File not found!!!");
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler:" + ex);
            }

        }

        private string[] readNamesFromCsv(string path)
        {
            try
            {
                string[] names = File.ReadAllLines(path);
                return names;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("File not found!!!");
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler: " + ex);
            }
        }

        private string changeNames(string[] names, string text)
        {
            string placeholder = "{FullPupilName:";

            for (int i = 0; i < names.Length; i++)
            {
                text = text.Replace(placeholder + i + "}", names[i]);
            }
            return text;
        }

        private void saveReplacedHtmlDoc(string text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(generatedHtmlFilename);
                sw.Write(text);
                sw.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("File not found!!!");
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler: " + ex);
            }
        }
        #endregion
    }
}
