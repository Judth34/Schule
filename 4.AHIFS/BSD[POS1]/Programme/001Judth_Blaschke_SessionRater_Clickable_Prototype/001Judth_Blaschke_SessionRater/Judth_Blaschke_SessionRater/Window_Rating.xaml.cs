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
using System.Windows.Shapes;

namespace Judth_Blaschke_SessionRater
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void btnRate_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).listBox_RatedSessions.Items.Add(
                ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem
                );

            ((MainWindow)Application.Current.MainWindow).listBox_Sessions.Items.Remove(
                    ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem

            );
            ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem = null;
            this.Close();
            
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem = null;
            this.Close();
        }
    }
}
