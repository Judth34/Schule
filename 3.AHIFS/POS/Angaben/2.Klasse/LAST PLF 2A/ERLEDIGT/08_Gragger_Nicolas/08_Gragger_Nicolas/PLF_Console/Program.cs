using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLF_Library;

namespace PLF_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dm;
            SimpleTree st;
            List<double> dl = new List<double>();

            try
            {
                dm = new DataManager(@"config.txt");
                st = new SimpleTree();

                // KAA: ineffizient 
                foreach (int currentInt in dm.GetIntNumbers())
                {
                    st.Add(currentInt);
                }

                foreach (double currentDouble in dm.GetDoubleNumbers())
                {
                    dl.Add(currentDouble);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // AVG des Baumes fehlt 
            Console.WriteLine(dl.Average());
        }
    }
}
