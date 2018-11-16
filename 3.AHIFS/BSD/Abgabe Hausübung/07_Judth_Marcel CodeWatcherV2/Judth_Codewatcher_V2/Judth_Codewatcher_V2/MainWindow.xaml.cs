using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Codewatcher_V1_Lib;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;

namespace Judth_Codewatcher_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DirectoryExplorer dirExplorer = new DirectoryExplorer();
        string targetFilename = null;
        string FolderPath = null;
        List<string> ExceptionList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SourceFile_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            FolderPath = f.SelectedPath;
        }

        private void btn_TargetFile_Click(object sender, RoutedEventArgs e)
        {
            //Öfnnen eines file dialogs damit der benutzer die quell csv datei auswählen kann
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog Opendlg = new Microsoft.Win32.OpenFileDialog();
            Opendlg.FileName = ""; // Default file name
            Opendlg.DefaultExt = ".*"; // Default file extension
            Opendlg.Filter = "All files (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            bool? result = Opendlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                targetFilename = Opendlg.FileName;
            }
            else
            {
                tblogs.Text = "No file selected!!!";
            }
        }

        private void btn_GenerateHtmlFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                if (FolderPath != null && targetFilename != null)
                {
                    Codewatcher_V1_Lib.TreeNode root = DirectoryExplorer.GetFolderStructure(FolderPath);
                    addListboxItems(root);
                    string htmldoc = createHtmlDoc(root, "");
                    SaveTreeInHtmlFile(htmldoc);
                    tblogs.Text = "Successfully generated!";
                }
                else
                {
                    tblogs.Text = "Enter a filename or enter a targetfile!!!";
                }

                foreach(string s in ExceptionList)
                {
                    tblogs.Text += s;
                }
            }
            catch(Exception ex)
            {
                ExceptionList.Add(ex.Message);
            }
        }

        private string createHtmlDoc(Codewatcher_V1_Lib.TreeNode currentNode, string HtmlDoc)
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
                ExceptionList.Add(ex.Message);
                return null;
            }
            
        }

        private void SaveTreeInHtmlFile(string htmldoc)
        {
            try
            {
                File.WriteAllText(targetFilename, htmldoc);
            }
            catch(Exception ex)
            {
                ExceptionList.Add(ex.Message);
            }
        }

        private void addListboxItems(Codewatcher_V1_Lib.TreeNode currendNode)
        {
            try
            {
                string[] splittedValue = currendNode.value.Split('.');

                if (splittedValue[splittedValue.Length - 1] == "cs") listBox.Items.Add(currendNode.value);
                foreach (Codewatcher_V1_Lib.TreeNode tn in currendNode.ChildNodes)
                {
                    addListboxItems(tn);
                }
            }
            catch(Exception ex)
            {
                ExceptionList.Add(ex.Message);
            }
        }
    }
}
