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
//using System.Windows.Forms;

namespace Judth_Codewatcher_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DirectoryExplorer dirExplorer = new DirectoryExplorer();
        string targetFilename = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SourceFile_Click(object sender, RoutedEventArgs e)
        {
            //FolderBrowserDialog f = new FolderBrowserDialog();

            //f.ShowDialog();
            //targetFilename = f.SelectedPath;

            //if(f.SelectedPath == null)
            //{
            //    throw new Exception("No folder selected!!!");
            //}
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
                if (tbSourceFilename != null && targetFilename != null)
                {
                    TreeNode root = DirectoryExplorer.GetFolderStructure(tbSourceFilename.Text);
                    string htmldoc = printTree(root, "");
                    SaveTreeInHtmlFile(htmldoc);
                    tblogs.Text = "Successfully generated!";
                    listBox.Items.Add(root.value);
                    AddNestedList(root);
                }
                else
                {
                    tblogs.Text = "Enter a filename or enter a targetfile!!!";
                }
            }
            catch(Exception ex)
            {
                tblogs.Text = "Error: " + ex;
            }
        }

        private static string printTree(TreeNode currentNode, string HtmlDoc)
        {
            string innerHtml = "";
            
                HtmlDoc += "<li><ul>" + currentNode.value;
                foreach (TreeNode tn in currentNode.ChildNodes)
                {
                    innerHtml = printTree(tn, innerHtml);
                }
                HtmlDoc += innerHtml + "</ul></li>";
            
            return HtmlDoc;
        }

        private void SaveTreeInHtmlFile(string htmldoc)
        {
            try
            {
                File.WriteAllText(targetFilename, htmldoc);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddNestedList(TreeNode currendNode)
        {
            if (currendNode.ValueType == "FILE") listBox.Items.Add(currendNode.value);
            foreach(TreeNode tn in currendNode.ChildNodes)
            {
                AddNestedList(tn);
            }
        }
    }
}
