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
        Codewatcher codeWatcher = new Codewatcher();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_SourceFile_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            codeWatcher.sourceFolderPath = f.SelectedPath;
            tbPathInfo.Text = "Source Folder: " + codeWatcher.sourceFolderPath + "\nTarget File: " + codeWatcher.targetFilePath;
            if(f.SelectedPath != null)
            {
                btn_SourceFile.Background = Brushes.LightGreen;
            }
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
                codeWatcher.targetFilePath = Opendlg.FileName;
                tbPathInfo.Text = "Source Folder: " + codeWatcher.sourceFolderPath + "\nTarget File: " + codeWatcher.targetFilePath;
                btn_TargetFile.Background = Brushes.LightGreen;
            }
            else
            {
                tblogs.Text = "No file selected!!!";
                btn_TargetFile.Background = Brushes.OrangeRed;
            }
        }

        private void btn_GenerateHtmlFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Clear();
                tblogs.Text = "";
                if (codeWatcher.sourceFolderPath != null && codeWatcher.targetFilePath != null)
                {
                    List<string> exceptionList =  codeWatcher.GenerateHtmlFile();
                    foreach(string ex in exceptionList)
                    {
                        tblogs.Text += ex;
                    }
                    if(exceptionList.Count == 0) tblogs.Text = "Successfully generated!";
                }
                else
                {
                    tblogs.Text = "Enter a filename or enter a targetfile!!!";
                }

                
            }
            catch(Exception ex)
            {
                tblogs.Text = ex.ToString();
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
                tblogs.Text = ex.ToString();
            }
        }
    }
}
