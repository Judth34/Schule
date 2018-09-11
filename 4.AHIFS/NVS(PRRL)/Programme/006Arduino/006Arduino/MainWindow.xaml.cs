using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace _006Arduino
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

        private void btnEin_Click(object sender, RoutedEventArgs e)
        {
            SerialPort sp = new SerialPort("COM5");
            sp.Open();
            sp.Write("1");
            sp.Close();
        }

        private void btnAus_Click(object sender, RoutedEventArgs e)
        {
            SerialPort sp = new SerialPort("COM5");
            sp.Open();
            sp.Write("0");
            sp.Close();
        }
    }
}
