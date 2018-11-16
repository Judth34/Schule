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
using SessionRaterClient;

namespace Judth_Blaschke_SessionRater
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WindowRating : Window
    {
        public Session SelectedSession { get; set; }
        public WindowRating(Session SelectedSession)
        {
            this.SelectedSession = SelectedSession;

            InitializeComponent();
        }

        private void btnRate_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter a name!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int rating = -1;
                if ((bool)radioButton1.IsChecked)
                    rating = 1;
                else
                    if ((bool)radioButton2.IsChecked)
                    rating = 2;
                else
                    if ((bool)radioButton3.IsChecked)
                    rating = 3;
                else
                    if ((bool)radioButton4.IsChecked)
                    rating = 4;
                else
                    if ((bool)radioButton5.IsChecked)
                    rating = 5;
                
                ((MainWindow)this.Owner).rateSession(SelectedSession, txtName.Text, rating);
                this.Close();
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            Session currentSession = (Session)((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem;

            if (currentSession.Ratings.Count > 0)
                currentSession.CurrentSessionState = SessionState.Evaluated;
            else
                currentSession.CurrentSessionState = SessionState.Created;
            ((MainWindow)this.Owner).updateListBoxSessions();
            Close();
        }
    }
}
