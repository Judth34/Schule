using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SessionRaterModel;
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

        public MainWindow(){
            InitializeComponent();
        }


        #region Event handlers

        private void btn_createSession_Click(object sender, RoutedEventArgs e){
            string title = txtBox_Thema.Text;
            string speaker = txtBox_Vortragender.Text;
            string dateSession = date.Text;

            try
            {
                //create Session
                Session session = createSession(title, speaker, dateSession);
                //add Session to Listbox
                addSessionToListbox(session);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("An error occured: " + Ex.Message);
            }


                //SessionManager.RateSession(firstSession.Id, "User1", 3);
                //listBox_Sessions.Items.Add("Thema: " + thema + ", von " + vortragender + " am: " + dateSession);


        }

        private void listBox_Sessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void mntm_rate_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session session = GetSelectedSessionFromListbox();
                if (checkifSessionCanBeEvaluated(session))
                {
                    Window1 w1 = new Window1(session);
                    w1.Show();
                }
                else
                {
                    MessageBox.Show("session cant be rated!");
                }
                
            }
            catch(Exception Ex)
            {
                MessageBox.Show("an error occured: " + Ex.Message);
            }
            
        }

        private void mntm_close_Session_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session session = GetSelectedSessionFromListbox();
                closeSession(session);
                MessageBox.Show("Session sucessfully closed");
            }
            catch (Exception Ex)
            {
                MessageBox.Show("an error occured: " + Ex.Message);
            }
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Session session = GetSelectedSessionFromListbox();
                MessageBox.Show(session.ToString());
            }
            catch (Exception Ex)
            {
                MessageBox.Show("an error occured: " + Ex.Message);
            }
        }

        #endregion



        #region private methods

        private Session createSession(string title,string speaker,string date)
        {
            //check params
            if (title == "" || speaker == "" || date == "" || title == null || speaker == null || date == null)
            {
                throw new Exception("input missing");
            }
            //add Session
            return SessionManager.createSession(title, speaker);

        }

        private void addSessionToListbox(Session session)
        {
            listBox_Sessions.Items.Add(session);
        }

        private Session GetSelectedSessionFromListbox()
        {
            //ceck if an item is selected
            if (listBox_Sessions.SelectedItem == null)
                throw new Exception("no Item selected!");
            return (Session)listBox_Sessions.SelectedItem;
            
        }

        private bool checkifSessionCanBeEvaluated(Session session)
        {
            if (session.CurrentSessionState != SessionState.Created)
                throw new Exception("session cant be rated!");
            return true;
        }

        private void closeSession(Session session)
        {
            if (session.CurrentSessionState == SessionState.Closed)
                throw new Exception("Session is already Closed!");
            session.CurrentSessionState = SessionState.Closed;
        }

        #endregion


    }
}
