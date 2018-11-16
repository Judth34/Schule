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
using CodeWatcherV2;
using CodeWAtcher.Lib;
using System.IO;

namespace _001_Code_Watcher
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

        private void btnGenerateFileV1_Click(object sender, RoutedEventArgs e)
        {
            
            Codewatcher cw = new Codewatcher();
            try
            {
                cw.GenerateNewSite(@"..\..\Data\TemplatePlaceholder.html", @"..\..\Data\Namen.csv");

                String curDir = Directory.GetCurrentDirectory();
                myWebBrowser.Source = new Uri(string.Format("file:///{0}/{1}", curDir, cw.generatedHtmlFilename));

            }
            catch (Exception ex)
            {
                tbLogs.Text = "Fehler: " + ex;
            }
        }

        

        private void btnGenerateFileV2_Click(object sender, RoutedEventArgs e)
        {
            CodeWatcher_v2 cw = new CodeWatcher_v2();
            try
            {
                cw.GenerateNewSite(@"..\..\Data\TemplatePlaceholder1.xml", @"..\..\Data\Namen.csv");

                String curDir = Directory.GetCurrentDirectory();
                myWebBrowser.Source = new Uri(string.Format("file:///{0}/{1}", curDir, cw.generatedHtmlFilename));

            }
            catch (Exception ex)
            {
                tbLogs.Text = "Fehler: " + ex;
            }
        }
    }
}
