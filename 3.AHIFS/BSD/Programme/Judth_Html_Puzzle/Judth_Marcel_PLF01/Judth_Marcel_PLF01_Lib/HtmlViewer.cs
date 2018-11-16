using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Judth_Marcel_PLF01_Lib
{
    public class HtmlViewer
    {
        static public List<string> GetHtmlTags(string path, bool withTabs)
        {
            try
            {
                XmlNode root = loadXML(path);
                TreeNode resultRoot = generateTree(root);
                return generateList(resultRoot, new List<string>(), "", withTabs);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region private-Methoden
        static private XmlNode loadXML(string filename)
        {
            XmlNode root = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                root = doc.DocumentElement;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in " + ex.ToString());
            }
            return root;
        }

        static private List<string> generateList(TreeNode currentElement, List<string> result, string tab, bool withTab)
        {
            string value = "";
            if (withTab) value = tab;
            value += currentElement.ValueType;

            result.Add(value);

            foreach (TreeNode child in currentElement.ChildNodes)
            {
                generateList(child, result, tab + " ", withTab);
            }
            return result;
        }

        static private TreeNode generateTree(XmlNode currentElement)
        {
            TreeNode result = new TreeNode(currentElement.Name);

            foreach (XmlNode n in currentElement.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element) result.Append(generateTree(n));
            }

            return result;
        }
        #endregion
    }
}
