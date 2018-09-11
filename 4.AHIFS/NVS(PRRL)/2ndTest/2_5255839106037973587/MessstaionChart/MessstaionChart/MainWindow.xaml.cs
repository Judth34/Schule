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

namespace MessstaionChart
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
        private static Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            mainwin = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1; i--)
            {


                int dat = rnd.Next(1, 500);
                string s = dat.ToString();
                try
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(s);
                    Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { clientSocket.Send(buffer); });
                    Console.WriteLine(s);
                    SendeDaten.Clear();
                }
                catch
                {
                    SendeDaten.Clear();
                    // Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { UpdateText("Sendefehler - ist eine Verbindung zum Server vorhanden?\n"); });
                }
                int milliseconds = 200;
                Thread.Sleep(milliseconds);
            }
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
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { /*UpdateText("mit dem Server verbunden");*/ });
                clientSocket.Send(Encoding.ASCII.GetBytes(" " + nickname.Text));
                clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
            }
            catch
            {
               // Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { UpdateText("Server nicht verfügbar"); });
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
              //  Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { UpdateText(text); });
                //auf die nächsten Zeichen warten
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch
            {
                socket.Close();
                socket.Dispose();
            }
        }

      

        private void btnSenden_Click(object sender, RoutedEventArgs e)
        {


          
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            byte[] buffer = Encoding.ASCII.GetBytes("~");
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
                //Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { UpdateText("Abmeldung fehlgeschlagen - ist eine Verbindung zum Server vorhanden?\n"); });
            }
        }

      
    }
}
