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
        string[] colors = { "Red", "Green", "Blue" };
        BitmapImage originalImage;

        public MainWindow()
        {
            InitializeComponent();

            this.cmbFilters.Items.Add(colors);
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
                originalImage = new BitmapImage();
                originalImage.BeginInit();
                originalImage.UriSource = new Uri(filename);
                originalImage.EndInit();
                this.imgOriginal.Source = originalImage;
            }
        }

        private void cmbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            int bytesperpixel = originalImage.Format.BitsPerPixel / 8;
            int stride = originalImage.PixelWidth * bytesperpixel;
            byte[] pixels = new byte[stride * originalImage.PixelHeight];
            originalImage.CopyPixels(pixels, stride, 0);



            byte[] r = new byte[pixels.Length];
            byte[] g = new byte[pixels.Length];
            byte[] b = new byte[pixels.Length];

            for (int i = 0; i < pixels.Length; i = i + bytesperpixel)
            {
                b[i] = pixels[i];
                g[i + 1] = pixels[i + 1];
                r[i + 2] = pixels[i + 2];
                r[i + 3] = pixels[i + 3];
                g[i + 3] = pixels[i + 3];
                b[i + 3] = pixels[i + 3];
            }

            WriteableBitmap filteredImage = new WriteableBitmap((int)originalImage.PixelWidth, (int)originalImage.PixelHeight, originalImage.DpiX, originalImage.DpiY, originalImage.Format, null);
            var rect = new Int32Rect(0, 0, (int)originalImage.PixelWidth, (int)originalImage.PixelHeight);
            if ((bool)rBNormal.IsChecked)
            {
                filteredImage.WritePixels(rect, pixels, stride, 0);
            }
            else
            {
                if ((bool)rBRed.IsChecked)
                {
                    filteredImage.WritePixels(rect, r, stride, 0);
                }
                else
                {
                    if ((bool)rBGreen.IsChecked)
                    {
                        filteredImage.WritePixels(rect, g, stride, 0);
                    }
                    else
                    {
                        if ((bool)rBBlue.IsChecked)
                        {
                            filteredImage.WritePixels(rect, b, stride, 0);
                        }
                    }
                }
            }




            this.imgFiltered.Source = filteredImage;
            System.Diagnostics.Debug.WriteLine("finished!");
        }
    }
}
