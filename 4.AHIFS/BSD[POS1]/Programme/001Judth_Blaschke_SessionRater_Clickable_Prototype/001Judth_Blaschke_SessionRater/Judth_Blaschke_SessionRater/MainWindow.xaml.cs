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

namespace Judth_Blaschke_SessionRater
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

        private void btn_createSession_Click(object sender, RoutedEventArgs e)
        {
            String thema = txtBox_Thema.Text;
            String vortragender = txtBox_Vortragender.Text;
            String dateSession = date.Text;
            listBox_Sessions.Items.Add("Thema: " + thema + ", von " + vortragender + " am: " + dateSession);
        }


        private void listBox_Sessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listBox_Sessions.SelectedItem != null)
            {
                Window1 window1 = new Window1();
                window1.Show();
            }
        }
    }
}
