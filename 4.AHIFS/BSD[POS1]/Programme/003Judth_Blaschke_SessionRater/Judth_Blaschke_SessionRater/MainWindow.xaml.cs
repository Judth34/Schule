using SessionRaterClient;
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

        public void rateSession(Session selectedSession, string RatingEvaluator, int RatingValue)
        {
            try
            {
                SessionManager.RateSession(selectedSession.Id, RatingEvaluator, RatingValue);
                listBox_Sessions.SelectedItem = null;
                updateListBoxSessions();
            }catch(Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        #region private Methods

        private void btn_createSession_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session newSession = SessionManager.CreateSession(txtBox_Title.Text, txtBox_Speaker.Text);
                updateListBoxSessions();
            }
            catch(Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        private void rate_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session currentSession = ((Session)listBox_Sessions.SelectedItem);
                if (!itemIsSelected())
                {
                    showMessageBoxError("Please select a session!");
                }
                else
                {
                    if (currentSession.CurrentSessionState == SessionState.Closed || currentSession.CurrentSessionState == SessionState.InEvaluation)
                        showMessageBoxError("This session can not be rated at the moment!");
                    else
                    {
                        currentSession.CurrentSessionState = SessionState.InEvaluation;
                        WindowRating window1 = new WindowRating(currentSession);
                        updateListBoxSessions();
                        listBox_Sessions.SelectedItem = currentSession;
                        window1.Owner = this;
                        window1.Show();
                    }
                }
            }catch(Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        private void delete_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!itemIsSelected())
                {
                    showMessageBoxError("Please select a session!");
                }
                else
                {
                    Session selectedSession = (Session)listBox_Sessions.SelectedItem;
                    SessionManager.Delete(selectedSession.Id);
                    updateListBoxSessions();
                    listBox_Sessions.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        private void close_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session selectedSession = (Session)listBox_Sessions.SelectedItem;
                SessionManager.CloseSession(selectedSession);
                listBox_Sessions.SelectedItem = null;
                updateListBoxSessions();
            }catch(Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        public void updateListBoxSessions()
        {
            try
            {
                listBox_Sessions.Items.Clear();
                foreach (Session s in SessionManager.Get())
                    listBox_Sessions.Items.Add(s);
            }catch(Exception ex)
            {
                showMessageBoxError(ex.Message);
            }
        }

        private bool itemIsSelected()
        {
            return listBox_Sessions.SelectedItem != null;
        }
        
        private void showMessageBoxError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion
    }
}
