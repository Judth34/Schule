using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace CodeWatcherV2
{
    public class CodeWatcher_v2
    {
        public string generatedHtmlFilename { get; private set; }
        private XmlDocument doc = new XmlDocument();

        public CodeWatcher_v2()
        {
            try
            {
                generatedHtmlFilename = @".\Seite.html";
                doc.Load(@"..\..\Data\TemplatePlaceholder1.xml");
            }
            catch(Exception ex)
            {
                throw new Exception("Fehler: " + ex);
            }
        }

        #region öffentliche-Methoden

        public void GenerateNewSite(string PathXMLDoc, string PathNames)
        {
            XmlNode n =  getXmlNodes(PathXMLDoc);
            string[] names =  readNamesFromCsv(PathNames);
            generateNewHtmlDoc(n, names);

        }

        #endregion

        #region private-Methoden
        private XmlNode getXmlNodes(string Filename)
        {
            try
            {
                string tagname = "ul";
                string attributeName = "IsRepeated";
                string attributeValue = "true";
                     
                XmlNodeList list = doc.GetElementsByTagName(tagname);
                XmlNode node = null;
                bool found = false;
                int i = 0;

                while (i < list.Count && found == false)
                {
                    if (list.Item(i).Attributes.Count > 0)
                    {
                        if (list.Item(i).Attributes[attributeName].Value == attributeValue)
                        {
                            node = list.Item(i);
                            found = true;
                        }
                    }
                    i++;
                }
                return node;
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
            catch(Exception ex)
            {
                throw new Exception("Fehler: " + ex);
            }
        }

        private void generateNewHtmlDoc(XmlNode Node, string[] names)
        {
            try
            {
                Node.Attributes.RemoveAll();
                doc.GetElementsByTagName("ul")[0].RemoveChild(Node);

                for (int i = 0; i < names.Length; i++)
                {
                    Node.FirstChild.InnerText = names[i];
                    doc.GetElementsByTagName("ul")[0].AppendChild(Node.CloneNode(true));
                }

                doc.Save(generatedHtmlFilename);
            }
            catch(Exception ex)
            {
                throw new Exception("Fehler: " + ex);
            }
        }

        #endregion
    }
}
