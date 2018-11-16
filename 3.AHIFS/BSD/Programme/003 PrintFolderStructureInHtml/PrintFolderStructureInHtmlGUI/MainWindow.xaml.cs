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
using DirectoryExplorerLib;
using TreeNodeLib;
using System.IO;

namespace PrintFolderStructureInHtmlGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGenerateHtmlFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeNode rootFolder = DirectoryExplorerLib.DirectoryExplorer.GetFolderStructure(tbPath.Text);

                File.WriteAllText(@".\Seite.html", printTree(rootFolder, ""));

                MessageBoxResult msgboxEnde = MessageBox.Show("Html - File sucessfully generated.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBoxResult msgboxEx = MessageBox.Show("Error:" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static string printTree(TreeNode currentNode, string HtmlDoc)
        {
            string innerHtml = "";
            if (currentNode.ValueType == "DIR")
            {
                HtmlDoc += "<li><ul>" + currentNode.value;
                foreach (TreeNode tn in currentNode.ChildNodes)
                {
                    innerHtml = printTree(tn, innerHtml);
                }
                HtmlDoc += innerHtml + "</ul></li>";
            }
            else
            {
                HtmlDoc += "<li>" + currentNode.value + "</li>";
            }
            return HtmlDoc;
        }
    }
}
