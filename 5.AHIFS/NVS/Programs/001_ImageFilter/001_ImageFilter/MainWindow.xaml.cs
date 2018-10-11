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

using _001_ImageFilter_Lib;

namespace _001_ImageFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] colors = { "Red", "Green", "Blue" };
        BitmapImage originalImage;
        ImageFilter imageFilter;

        public MainWindow()
        {
            InitializeComponent();
            this.imageFilter = new ImageFilter();
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
                this.imageFilter.setImage(originalImage);
                this.imgFiltered.Source = null;
            }
        }

        private void cmbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            ImageFilter.colors colorType = ImageFilter.colors.normal;
            ImageFilter.filterTypes filterType = ImageFilter.filterTypes.none;

            if ((bool)rBNormal.IsChecked)
            {
                colorType = ImageFilter.colors.normal;
            }
            else
            {
                if ((bool)rBRed.IsChecked)
                {
                    colorType = ImageFilter.colors.red;
                }
                else
                {
                    if ((bool)rBGreen.IsChecked)
                    {
                        colorType = ImageFilter.colors.green;
                    }
                    else
                    {
                        if ((bool)rBBlue.IsChecked)
                        {
                            colorType = ImageFilter.colors.blue;
                        }
                    }
                }
            }

            WriteableBitmap filteredImage = imageFilter.filterImage(colorType, filterType);
            this.imgFiltered.Source = filteredImage;
        }
    }
}
