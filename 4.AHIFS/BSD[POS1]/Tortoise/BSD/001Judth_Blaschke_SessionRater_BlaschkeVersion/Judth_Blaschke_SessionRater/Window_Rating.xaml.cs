using SessionRaterModel;
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
        #region fields

        public Session sessionToRate { get; set; }

        #endregion


        public Window1(Session session)
        {
            InitializeComponent();
            this.sessionToRate = session;
            this.sessionToRate.CurrentSessionState = SessionState.InEvaluation;
        }


        #region Event handlers

        private void btnRate_Click(object sender, RoutedEventArgs e)
        {
            if (this.sessionToRate.CurrentSessionState == SessionState.Closed || this.sessionToRate.CurrentSessionState == SessionState.Evaluated)
            {
                MessageBox.Show("Session `" + this.sessionToRate.Title + "` cant be rated!");
                this.Close();
            }
            else {
                this.sessionToRate.CurrentSessionState = SessionState.Evaluated;

                ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem = null;

                MessageBox.Show("Session `" + this.sessionToRate.Title + "` was sucessfully rated!");
                this.Close();
            }
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).listBox_Sessions.SelectedItem = null;
            sessionToRate.CurrentSessionState = SessionState.Created;
            this.Close();
        }

        #endregion


        #region private methods

        private void RateSession()
        {

        }

        #endregion

    }
}
