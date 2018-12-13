using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace TCP_Stations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket clientSocket = null;
        public delegate void UpdateTextCallback(string message);
        private static byte[] _buffer = new byte[1024];
        private static MainWindow mainwin;
        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        Random zz = new Random();

        public MainWindow()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 300);
           
            mainwin = this;
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (clientSocket != null)  //evtl vorhandenen Socket schließen
            {
                clientSocket.Close();
                clientSocket.Dispose();
                clientSocket = null;
            }
            //und neuen aufmachen
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(ServerIP.Text, Convert.ToInt16(portnr.Text));
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("mit dem Server verbunden"); });
                clientSocket.Send(Encoding.ASCII.GetBytes(" " + nickname.Text));
            
            }
            catch
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("Server nicht verfügbar"); });
            }
        }

    
        private void updateStatusLine(String s)
        {
            statusLine.Text = s;
        }
       
        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            string s = "~"+nickname.Text;
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            try
            {
                if (clientSocket != null)
                {
                    clientSocket.Send(buffer);
                    clientSocket.Close();
                    clientSocket.Dispose();
                    clientSocket = null;
                }
            }
            catch
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("Abmeldung fehlgeschlagen - ist eine Verbindung zum Server vorhanden?\n"); });
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            String mw;
            mw = Convert.ToString(zz.Next(0, 100));
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine(mw); });
            clientSocket.Send(Encoding.ASCII.GetBytes(" " + mw));
        }

        private void stoppMeasure_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
        }
    }
}


