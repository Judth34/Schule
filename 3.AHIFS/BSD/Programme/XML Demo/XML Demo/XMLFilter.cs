using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Demo
{
    class XMLFilter
    {
        #region Eigenschaften
        XmlDocument doc = new XmlDocument();
        #endregion

        #region Konstruktor
        public XMLFilter(string Filename)
        {
            doc.Load(Filename);
        }
        #endregion

        //#region öffentliche-Methoden
        //public XmlNodeList FilterByFilename(string TagName)
        //{
        //    return doc.GetElementsByTagName(TagName);
        //}

        //public string FilterByAttributeName(string AttributeName)
        //{
        //    string result = "";
        //    this.Attributename = AttributeName;

        //    foreach (XmlNode n in Nodes)
        //    {
        //        result += n.Attributes[AttributeName].OuterXml;
        //    }
        //    return result;
        //}

        //public string FilterByAttributeValue(string AttributeValue)
        //{
        //    string result = "";

        //    foreach(XmlNode n in Nodes)
        //    {
        //        if (n.Attributes[Attributename].Value == AttributeValue) result += n.Attributes[Attributename].OuterXml;
        //    }

        //    return result;
        //}
        //#endregion

        public XmlNode Search(string Tagname, string AttributeName, string AttributeValue)
        {
            XmlNodeList list = doc.GetElementsByTagName(Tagname);
            XmlNode node = null;
            bool found = false;
            int i = 0;

            while (i < list.Count || found == false)
            {
                if (list.Item(i).Attributes[AttributeName].Value == AttributeValue)
                {
                    node = list.Item(i);
                    found = true;
                }
                i++;
            }
            return node;
        }
    }
}
