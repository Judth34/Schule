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
using uPLibrary.Networking.M2Mqtt;

namespace _003_WertVomBroker
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

            client.Connect(clientId);
            client.Subscribe(new string[] { "villach/5AHIF/Temparatur" }, new byte[] { 1 });
        }

        private void btnLuefterEin_Click(object sender, RoutedEventArgs e)
        {
            client.Publish("villach/5AHIF/judthm/Luefter", Encoding.UTF8.GetBytes("on"));
        }

        private void btnLuefterAus_Click(object sender, RoutedEventArgs e)
        {
            client.Publish("villach/5AHIF/judthm/Luefter", Encoding.UTF8.GetBytes("on"));
        }
    }
}
