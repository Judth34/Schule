using PupilSorterLIB;
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

namespace PupilSorterGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CSVPupilSorter myPupilsorter;

        public CSVPupilSorter.SchuelerSortBy Auswahl;

        public MainWindow()
        {
            InitializeComponent();
            myPupilsorter = new CSVPupilSorter();
        }

        private void btnLoadSourceFile_Click(object sender, RoutedEventArgs e)
        {
            //Öfnnen eines file dialogs damit der benutzer die quell csv datei auswählen kann
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog Opendlg = new Microsoft.Win32.OpenFileDialog();
            Opendlg.FileName = "BasisFuerSchuelerlisteExport"; // Default file name
            Opendlg.DefaultExt = ".csv"; // Default file extension
            Opendlg.Filter = "Comma seperated values (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            bool? result = Opendlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = Opendlg.FileName;
                tblogs.Text = filename;
                myPupilsorter.SourceFile = filename;
            }
            else
            {
                tblogs.Text = "No file selected";
            }
        }

        private void btnGenerateSortedFile_Click(object sender, RoutedEventArgs e)
        {
            string targetname = "";
            Microsoft.Win32.SaveFileDialog Opendlg = new Microsoft.Win32.SaveFileDialog();
            Opendlg.FileName = "BasisFuerSchuelerlisteExportSortiert"; // Default file name
            Opendlg.DefaultExt = ".csv"; // Default file extension
            Opendlg.Filter = "Comma seperated values (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            bool? result = Opendlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                targetname = Opendlg.FileName;
                tblogs.Text = targetname;
                myPupilsorter.TargetFile = targetname;
            }
            
                myPupilsorter.GenerateSortedFile(Auswahl);
                tblogs.Text = "Das File wurde erstell und sortiert";
            }

        private void btnVorname_Checked(object sender, RoutedEventArgs e)
        {
            Auswahl = CSVPupilSorter.SchuelerSortBy.Firstname;
        }

        private void btnName_Checked(object sender, RoutedEventArgs e)
        {
            Auswahl = CSVPupilSorter.SchuelerSortBy.Name;
        }

        private void btnKlasse_Checked(object sender, RoutedEventArgs e)
        {
            Auswahl = CSVPupilSorter.SchuelerSortBy.Klasse;
        }
    }
}
