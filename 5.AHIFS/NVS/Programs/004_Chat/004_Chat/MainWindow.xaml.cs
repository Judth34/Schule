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
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace _004_Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MqttClient client;
        string clientId;

        public MainWindow()
        {
            InitializeComponent();
            client = new MqttClient("iot.eclipse.org");
            clientId = Guid.NewGuid().ToString();

            client.MqttMsgPublishReceived += mqttMsgReceived;
            client.Connect(clientId);
            client.Subscribe(new string[] { "htlvillach/5AHIF" }, new byte[] { 1 });
        }

        private void mqttMsgReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string ReceivedMessage = Encoding.UTF8.GetString(e.Message);
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate ()
            {
                txtSubscriped.Text = txtSubscriped.Text + "\n" + ReceivedMessage;
            });
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string meldung = txtNickName.Text + ": " + txtMessage.Text;

            client.Publish("htlvillach/5AHIF", Encoding.UTF8.GetBytes(meldung));
        }
    }
}
