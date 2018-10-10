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
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(filename);
                image.EndInit();
                int bytesperpixel = image.Format.BitsPerPixel / 8;
                int stride = image.PixelWidth * bytesperpixel;
                byte[] pixels = new byte[stride * image.PixelHeight];
                image.CopyPixels(pixels, stride, 0);

                

                byte[] r = new byte[pixels.Length];
                byte[] g = new byte[pixels.Length];
                byte[] b = new byte[pixels.Length];
                int counter = 0;

                for (int i = 0; i < pixels.Length; i = i + 3)
                {
                    r[counter] = pixels[i];
                    g[counter] = pixels[i + 1];
                    b[counter] = pixels[i + 2];
                    counter++;
                }

                WriteableBitmap image2 = new WriteableBitmap((int)image.PixelWidth, (int)image.PixelHeight, image.DpiX, image.DpiY, image.Format, null);
                var rect = new Int32Rect(0, 0, (int)image.PixelWidth, (int)image.PixelHeight);
                image2.WritePixels(rect, r, stride, 0);
                this.imgOriginal.Source = image2;

                System.Diagnostics.Debug.WriteLine("finished!");
            }
        }
    }
}
