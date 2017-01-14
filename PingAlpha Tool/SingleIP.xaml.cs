using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace PingAlpha_Tool
{
    /// <summary>
    /// Interaction logic for SingleIP.xaml
    /// </summary>
    public partial class SingleIP : UserControl
    {
        string hostname;
        string ip_Address;
        Panel ipAddressContainer;
        bool pingable;

        public SingleIP()
        {
            InitializeComponent();
        }

        public void Parameters(string hostname, string ipAddress, Panel ipAddressContainer)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.hostname = hostname;
                this.ip_Address = ipAddress;
                this.ipAddressContainer = ipAddressContainer;

            });

            FileForServerList.writeToFile(hostname, ipAddress);

            Console.WriteLine(UsingPinger());

            createRow();
        }

        public void createRow()
        {
            this.Dispatcher.Invoke(() => {
                this.hostName.Content = hostname;
                this.ipAddress.Content = ip_Address;
            });

            if(pingable)
            {
                this.Dispatcher.Invoke(() => {
                    this.status.Background = System.Windows.Media.Brushes.Green;
                });
            }

            if (!pingable)
            {
                this.Dispatcher.Invoke(() => {
                    this.status.Background = System.Windows.Media.Brushes.Red;
                });
            }
        }

        public string UsingPinger()
        {
            try
            {
                if (!(string.IsNullOrEmpty(hostname)) || !(string.IsNullOrEmpty(ip_Address)))
                {
                    Pinger ping = new Pinger();

                    PingReply[] pingResults = ping.PingAlpha(hostname, ip_Address);

                    if(pingResults[0].Status == 0)
                    {
                        pingable = true;
                        return "Success";
                    }
                }
                pingable = false;
                return "Failure";

            }
            catch (Exception)
            {
                pingable = false;
                return "Failure";
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
