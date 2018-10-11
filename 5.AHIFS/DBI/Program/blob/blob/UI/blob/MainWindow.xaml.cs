using classLibrary;
using Microsoft.Win32;
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


namespace blob
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataAccess da;

        public MainWindow()
        {
            da = new DataAccess();
            InitializeComponent();
        }

        private void btn_load_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a File";
  
            if (openFileDialog1.ShowDialog() == true)
            {
                byte[] array = File.ReadAllBytes(openFileDialog1.FileName);
                DataAccess.Blob blob = new DataAccess.Blob(0,openFileDialog1.FileName,DataAccess.Blob.convert(openFileDialog1.FileName));
                DataAccess.Blob.insert(blob);
                fillListBlobs();
            }
        }

        private void btn_get_blobs_Click(object sender, RoutedEventArgs e)
        {
            fillListBlobs();
        }


        //custom

        private void fillListBlobs()
        {
            this.list_blobs.Items.Clear(); 
            foreach (DataAccess.Blob blob in DataAccess.Blob.get())
            {
                this.list_blobs.Items.Add(blob);
            }
        }

        private void list_blobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String filename = ((DataAccess.Blob)this.list_blobs.SelectedItem).name;
            DataAccess.Converter.Convert.toPdf(filename,DataAccess.defaultResultPath);
            MessageBox.Show("sucessfully saved in: " + DataAccess.defaultResultPath);
        }
    }
}
