using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Codewatcher_V1_Lib
{
    public class Codewatcher
    {
        #region Eigenschaften
        public string sourceFolderPath { get; set; }
        public string targetFilePath { get; set; }
        private string templatePath = @"..\..\..\Codewatcher_V1_Lib\Template\Template.html";
        List<string> ExceptionList = new List<string>();
        #endregion


        #region öffentliche Methoden
        public List<string> GenerateHtmlFile()
        {
            TreeNode root = DirectoryExplorer.GetFolderStructure(sourceFolderPath);
            string htmldoc = createHtmlDoc(root, "");
            createCompleteHtmlDoc(htmldoc);
            //try
            //{
            //    File.WriteAllText(targetFilePath, htmldoc);
            //}
            //catch(Exception ex)
            //{
            //    ExceptionList.Add(ex.ToString());
            //}
            return ExceptionList;
        }
        #endregion

        #region private-Methoden
        private string createHtmlDoc(TreeNode currentNode, string HtmlDoc)
        {
            try
            {
                string innerHtml = "";
                string[] splittedPath = currentNode.value.Split('.');
                int length = splittedPath.Length;

                HtmlDoc += "<li><ul>" + currentNode.value;

                if (splittedPath[splittedPath.Length - 1] == "cs")
                {
                    string code = File.ReadAllText(currentNode.value);
                    HtmlDoc += "<li><pre><code>" + code + "</code></pre></li>";
                }


                foreach (Codewatcher_V1_Lib.TreeNode tn in currentNode.ChildNodes)
                {
                    innerHtml = createHtmlDoc(tn, innerHtml);
                }
                HtmlDoc += innerHtml + "</ul></li>";

                return HtmlDoc;
            }
            catch (Exception ex)
            {
                ExceptionList.Add(ex.ToString());
                return null;
            }

        }

        private void createCompleteHtmlDoc(string HtmlDoc)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(templatePath);

                XmlNode pathTn = doc.GetElementsByTagName("h2")[0];
                XmlNode dataTn = doc.GetElementsByTagName("ul")[0];

                pathTn.InnerText = sourceFolderPath;
                dataTn.InnerText = targetFilePath;
                doc.Save(targetFilePath);
            }
            catch(Exception ex)
            {
                ExceptionList.Add(ex.ToString());
            }
        }
        #endregion
    }
}
