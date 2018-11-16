using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Geben Sie den Namen des XML-Files an: ");
                string xmlFile = Console.ReadLine();
                XMLFilter xml = new XMLFilter(xmlFile);

                Console.Write("Geben Sie den Namen des zu suchenden XML-Elements an: ");
                string xmlElementName = Console.ReadLine();

                // kann auch mit Enter bestätigt werden, dann muss nicht nach dem 
                // Attributsnamen gesucht werden
                Console.Write("Attributsname: ");
                string attributeName = Console.ReadLine();


                // kann auch mit Enter bestätigt werden, dann muss nicht nach dem 
                // Attributswert für das obige Attribut gesucht werden
                Console.Write("Attributswert: ");
                string attributeValue = Console.ReadLine();

                XmlNode node = xml.Search(xmlElementName, attributeName, attributeValue);
                Console.WriteLine(node.InnerText);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Fehler" + ex);
            }

        }
    }
}
