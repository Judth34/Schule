using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF_Library
{
    public class DataManager
    {
        List<string> PathList = new List<string>();
        public DataManager(string configPath)
        {
            try
            {
                PathList = FileManager.ReadConfigFile(configPath);
            }
            catch (Exception ex)
            {
                throw new Exception("PLF_Library/DataManager> " + ex.Message, ex);
            }
        }

        public List<int> GetIntNumbers()
        {
            List<int> result = new List<int>();

            try
            {
                // KAA: bessere methodische Trennung inkl. korrekter Benennung erforderlich
                foreach (string path in PathList)
                {
                    foreach (double source in FileManager.ReadBinFile(path))
                    {
                        int currentInt;

                        if (int.TryParse(source.ToString(), out currentInt))
                        {
                            result.Add(currentInt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PLF_Library/DataManager/GetIntNumbers> " + ex.Message, ex);
            } 

            return result;
        }

        // Code beinahe 1:1 Kopie von oben (redundant)
        public List<double> GetDoubleNumbers()
        {
            List<double> result = new List<double>();

            try
            {
                foreach (string path in PathList)
                {
                    foreach (double source in FileManager.ReadBinFile(path))
                    {
                        int currentInt;

                        if (!int.TryParse(source.ToString(), out currentInt))
                        {
                            result.Add(source);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PLF_Library/DataManager/GetDoubleNumbers> " + ex.Message, ex);
            }

            return result;
        }
    }
}
