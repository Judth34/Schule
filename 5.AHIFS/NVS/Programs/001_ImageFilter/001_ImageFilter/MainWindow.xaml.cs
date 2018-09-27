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

namespace _001_ImageFilter
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

        private void btnFileChooser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\Marcel Judth\Documents\GitHub\Schule\5.AHIFS\NVS\Programs\001_ImageFilter\001_ImageFilter\bin\Debug\Data";
            openFileDialog.Title = "Browse images";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "Image files (*.jpg, *.bmp, *.png) | *.jpg; *.bmp; *.png";
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string filename = openFileDialog.FileName;
                BitmapImage image = new BitmapImage(new Uri(filename, UriKind.Absolute));
                image.EndInit();
                imgOriginal.Source = image;
                int bw = image.PixelWidth;
                int bh = image.PixelHeight;
                int bytesperpixel = image.Format.BitsPerPixel / 8;
                int stride = 
            }
        }
    }
}
