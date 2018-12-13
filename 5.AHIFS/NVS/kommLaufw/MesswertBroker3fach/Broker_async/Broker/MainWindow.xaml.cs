using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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


namespace TCP_Server_async
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static String Ip = "0.0.0.0";
        private static char DisconnectSymbol = '~'; //Client sendet ~ zum Beenden
        private static MainWindow mainwin;
        private static byte[] _buffer = new byte[1024];
        private static List<Socket> _clientSockets = new List<Socket>();
        private static List<Socket> _subscriberSockets = new List<Socket>();
        private static Socket _serverSocketIn = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Socket _serverSocketOut = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public MainWindow()
        {
            InitializeComponent();
            mainwin = this;
        }

        private static void SetupServer(int PortIn, int PortOut)
        {
            _serverSocketIn.Bind(new IPEndPoint(IPAddress.Parse(Ip), PortIn));
            _serverSocketIn.Listen(1);
            _serverSocketIn.BeginAccept(new AsyncCallback(AcceptCallbackIn), null);

             _serverSocketOut.Bind(new IPEndPoint(IPAddress.Parse(Ip), PortOut));
            _serverSocketOut.Listen(1);
            _serverSocketOut.BeginAccept(new AsyncCallback(AcceptCallbackOut), null);        }

        private static void AcceptCallbackIn(IAsyncResult AR)  //ein Client hat sich angemeldet, Verbindung akzeptieren
        {
            Socket socket = _serverSocketIn.EndAccept(AR);
            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallbackIn), socket); //bereit für nächsten Client
            _serverSocketIn.BeginAccept(new AsyncCallback(AcceptCallbackIn), null);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text= "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
        }

        private static void AcceptCallbackOut(IAsyncResult AR)  //ein Client hat sich angemeldet, Verbindung akzeptieren
        {
            Socket socket = _serverSocketOut.EndAccept(AR);
            _subscriberSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallbackOut), socket); //bereit für nächsten Client
            _serverSocketOut.BeginAccept(new AsyncCallback(AcceptCallbackOut), null);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Subscriber: " + Convert.ToString(_clientSockets.Count); });
        }

        private static void ReceiveCallbackIn(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);
                byte[] dataBuffer = new byte[received];
                Array.Copy(_buffer, dataBuffer, received);
                string text = Encoding.ASCII.GetString(dataBuffer);
                if (text[0].Equals(DisconnectSymbol) && !text.Contains(":"))
                {
                    text = text.Remove(0, 2);
                    //Broadcast(text + " hat sich abgemeldet.\n");
                    _clientSockets.Remove(socket);
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
                    socket.Close();
                    socket.Dispose();
                }
                else if (!text.Contains(":"))
                {
                    text = text.Remove(0, 1);
                }
                else
                {
                    
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = text; });
                    Broadcast(text);
                }
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallbackIn), socket);
            }
            catch
            {
                _clientSockets.Remove(socket);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
                socket.Close();
                socket.Dispose();
            }
        }

        private static void ReceiveCallbackOut(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                int received = socket.EndReceive(AR);
                byte[] dataBuffer = new byte[received];
                Array.Copy(_buffer, dataBuffer, received);
                string text = Encoding.ASCII.GetString(dataBuffer);
                if (text[0].Equals(DisconnectSymbol) && !text.Contains(":"))
                {
                    text = text.Remove(0, 2);
                    //Broadcast(text + " hat sich abgemeldet.\n");
                    _subscriberSockets.Remove(socket);
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Subscriber: " + Convert.ToString(_clientSockets.Count); });
                    socket.Close();
                    socket.Dispose();
                }
                else if (!text.Contains(":"))
                {
                    text = text.Remove(0, 1);
                    //Broadcast(text + " hat sich verbunden.\n");
                }
                else
                {
                    //Broadcast(text);
                }
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallbackOut), socket);
            }
            catch
            {
                _subscriberSockets.Remove(socket);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Subscriber: " + Convert.ToString(_clientSockets.Count); });
                socket.Close();
                socket.Dispose();
            }
        }

        private static void Broadcast(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            foreach (Socket s in _subscriberSockets)
            {
                    s.Send(data);
            }
        }

        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            SetupServer(Convert.ToInt16(portnrIn.Text), Convert.ToInt16(portnrOut.Text));
        }
 }
}
