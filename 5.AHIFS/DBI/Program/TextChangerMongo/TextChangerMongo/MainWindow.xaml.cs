using System;
using System.Collections.Generic;
using System.IO;
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
using Data;

namespace TextChangerMongo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                Data.Database.Connect();
                setListContent();
            }
            catch(Exception ex)
            {

            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Text | *.txt";

                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    string path = dlg.FileName;
                    string filename = dlg.SafeFileName;
                    string content = System.IO.File.ReadAllText(path);
                    Data.File newFile = new Data.File(filename, content);

                    Data.Database.InsertFile(newFile);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void setListContent()
        {
            listFiles.Items.Clear();
            List<Data.File> allFiles = Database.getAllFiles();
            foreach(Data.File f in allFiles)
            {
                listFiles.Items.Add(f);
            }
        }

        private void listFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.File currentFile = (Data.File)listFiles.SelectedItem;

            txtFileContent.Text = currentFile.fileContent;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if ((Data.File)listFiles.SelectedItem == null)
            {
                MessageBox.Show("You have to selecta File");
            }
            try
            {
                Data.File currentFile = (Data.File)listFiles.SelectedItem;
                String newText = txtFileContent.Text;

                Data.Database.updateFileContent(currentFile, newText);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            listFound.Items.Clear();
            List<Data.File> allFiles = Database.findText(txtSearch.Text);

            foreach (Data.File f in allFiles)
            {
                listFound.Items.Add(f);
            }
        }

        private void listFound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Data.File currentFile = (Data.File)listFound.SelectedItem;

            txtFileContent.Text = currentFile.fileContent;
        }
    }
}
