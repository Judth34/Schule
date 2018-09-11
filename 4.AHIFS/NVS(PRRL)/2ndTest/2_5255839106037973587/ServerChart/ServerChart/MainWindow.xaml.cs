﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ServerChart
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
        private static List<Socket> _messtationSockets = new List<Socket>();
        private static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Socket _serverSocket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            mainwin = this;
        }

        private static void SetupServer(int Port)
        {
            _serverSocket.Bind(new IPEndPoint(IPAddress.Parse(Ip), Port));
            _serverSocket.Listen(1);
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private static void SetupServer2(int Port)
        {
            _serverSocket2.Bind(new IPEndPoint(IPAddress.Parse(Ip), Port));
            _serverSocket2.Listen(1);
            _serverSocket2.BeginAccept(new AsyncCallback(AcceptCallback2), null);
        }



        private static void AcceptCallback(IAsyncResult AR)  //ein Client hat sich angemeldet, Verbindung akzeptieren
        {
            Socket socket = _serverSocket.EndAccept(AR);
            _clientSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket); //bereit für nächsten Client
            _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
        }

        private static void AcceptCallback2(IAsyncResult AR)  //ein Client hat sich angemeldet, Verbindung akzeptieren
        {
            Console.WriteLine("Ich bin hier");
            Socket socket = _serverSocket2.EndAccept(AR);
            _messtationSockets.Add(socket);
            socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback2), socket); //bereit für nächsten Client
            _serverSocket2.BeginAccept(new AsyncCallback(AcceptCallback2), null);
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_messtationSockets.Count); });
        }

        private static void ReceiveCallback(IAsyncResult AR)
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
                    Broadcast(text + " hat sich abgemeldet.\n", socket);
                    _clientSockets.Remove(socket);
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
                    socket.Close();
                    socket.Dispose();
                }
                else if (!text.Contains(":"))
                {
                    text = text.Remove(0, 1);
                  //  Broadcast(text + " hat sich verbunden.\n", socket);
                }
                else
                {
                    Broadcast(text, socket);
                }
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch
            {
                _clientSockets.Remove(socket);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
                socket.Close();
                socket.Dispose();
            }
        }

        private static void ReceiveCallback2(IAsyncResult AR)
        {
            Console.WriteLine("Ich bin hier2");
            Socket socket = (Socket)AR.AsyncState;
            try
            {
                Console.WriteLine("Ich bin hier3");
                int received = socket.EndReceive(AR);
                byte[] dataBuffer = new byte[received];
                Array.Copy(_buffer, dataBuffer, received);
                string text = Encoding.ASCII.GetString(dataBuffer);
                Console.WriteLine("ich bin hier 5 " + text);
                /*
                if (text[0].Equals(DisconnectSymbol) && !text.Contains(":"))
                {
                    text = text.Remove(0, 2);
                  //  Broadcast(text + " hat sich abgemeldet.\n", socket);
                    _messtationSockets.Remove(socket);
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_messtationSockets.Count); });
                    socket.Close();
                    socket.Dispose();
                }
                else if (!text.Contains(":"))
                {
                    text = text.Remove(0, 1);
                    //  Broadcast(text + " hat sich verbunden.\n", socket);
                }
                else
                {*/
                    Console.WriteLine("Ich bin hier4");
                    Console.WriteLine(text);
                    BroadcastChart(text);
                
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback2), socket);
            }
            catch
            {
                _clientSockets.Remove(socket);
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate () { mainwin.ServerInfo.Text = "Anzahl verbundener Clients: " + Convert.ToString(_clientSockets.Count); });
                socket.Close();
                socket.Dispose();
            }
        }

        private static void Broadcast(string text, Socket sender)
        {
            foreach (Socket s in _clientSockets)
            {
                if (s != sender)
                {
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    s.Send(data);
                }
            }
        }

        private static void BroadcastChart(string text)
        {
            foreach (Socket s in _clientSockets)
            {
               
                    byte[] data = Encoding.ASCII.GetBytes(text);
                    s.Send(data);
                
            }
        }

        private static void sendData()
        {
            int dat = rnd.Next(1, 500);
            mainwin.ServerInfo.Text = dat.ToString();
            BroadcastChart(dat.ToString());

        }


        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            SetupServer(Convert.ToInt16(portnr.Text));
           // sendData();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Boolean start = false;

            while (start == false)
            {
                sendData();
                int milliseconds = 200;
                Thread.Sleep(milliseconds);
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SetupServer2(Convert.ToInt16(textBox.Text));
        }
    }
}
