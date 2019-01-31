using Microsoft.Win32;
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

namespace _002_BLOB_Textfiles
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"C:";
                openFileDialog.Title = "Browse images";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                var result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    Database.insert(openFileDialog.FileName, );
                    this.lblMessage.Text = "succesfully inserted!";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadFiles_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
