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

namespace TCP_Subscriber
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Socket subscriberSocket = null;
        public delegate void UpdateTextCallback(string message);
        private static byte[] _buffer = new byte[1024];
        private static MainWindow mainwin;
        Polyline pg = new Polyline();
        double[] mw = new double[500];
        int anzahl = -1;
        Point Punkt = new Point();

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 500; i++) mw[i] = 0;
            anzahl = 499;
            mainwin = this;
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (subscriberSocket != null)  //evtl vorhandenen Socket schließen
            {
                subscriberSocket.Close();
                subscriberSocket.Dispose();
                subscriberSocket = null;
            }
            //und neuen aufmachen
            try
            {
                subscriberSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                subscriberSocket.Connect(ServerIP.Text, Convert.ToInt16(portnr.Text));
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("mit dem Server verbunden"); });
                subscriberSocket.Send(Encoding.ASCII.GetBytes(" " + nickname.Text));
                subscriberSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), subscriberSocket);
            }
            catch
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("Server nicht verfügbar"); });
            }
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
           Socket socket = (Socket)AR.AsyncState;
           try
           {
                int received = socket.EndReceive(AR);
                byte[] dataBuffer = new byte[received];
                Array.Copy(_buffer, dataBuffer, received);
                string text = Encoding.ASCII.GetString(dataBuffer);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { UpdateChart(Convert.ToInt32(text)); });
                //auf die nächsten Zeichen warten
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch
            {
                socket.Close();
                socket.Dispose();
            }
        }

        private void updateStatusLine(String s)
        {
            statusLine.Text = s;
        }
        private void UpdateChart(int wert)
        {
            PointCollection Punkte = new PointCollection();
            
            pg.Stroke = System.Windows.Media.Brushes.Black;
            pg.StrokeThickness = 1;

            anzahl++;
            
            if (anzahl >= 500)
            {
                for (int i = 0; i < 499; i++)
                {
                    mw[i] = mw[i + 1];
                    Punkt.X = i;
                    Punkt.Y = mw[i] ;
                    Punkte.Add(Punkt);
                }
                anzahl = 499;
            }
            zb.Children.Clear();
            mw[anzahl] = wert;
           
            statusLine.Text = String.Format("{0:###.00}", wert);
            Punkt.X = anzahl;
            Punkt.Y =mw[anzahl];
            Punkte.Add(Punkt);

            pg.Points = Punkte;
            zb.Children.Add(pg);
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            string s = "~"+nickname.Text;
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            try
            {
                if (subscriberSocket != null)
                {
                    subscriberSocket.Send(buffer);
                    subscriberSocket.Close();
                    subscriberSocket.Dispose();
                    subscriberSocket = null;
                }
            }
            catch
            {
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { updateStatusLine("Abmeldung fehlgeschlagen - ist eine Verbindung zum Server vorhanden?\n"); });
            }
        }

    }
}


