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
using System.Windows.Forms;
using Judth_Marcel_PLF01_Lib;


namespace Judth_Marcel_PLF01_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sourceFilePath;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnLoadSourceFile_Click(object sender, RoutedEventArgs e)
        {
            //Alles wieder auf null setzten
            tblogs.Text = "";
            tbselectedFile.Text = "";
            sourceFilePath = null;
            myListBox.Items.Clear();

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
                sourceFilePath = Opendlg.FileName;
                tbselectedFile.Text = sourceFilePath;
            }
            else
            {
                tblogs.Text = "No file selected!!!";
            }
        }

        private void btnPrintInListbox_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myListBox.Items.Clear();
                List<string> result = HtmlViewer.GetHtmlTags(sourceFilePath, true);

                foreach(string value in result)
                {
                    myListBox.Items.Add(value);
                }
                tblogs.Text = "Sucessfully added!!";
            }
            catch(Exception ex)
            {
                tblogs.Text = ex.ToString();
            }
        }
    }
}
