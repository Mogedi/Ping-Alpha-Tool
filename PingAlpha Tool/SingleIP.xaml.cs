using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        Timer myTimer;

        public SingleIP()
        {
            InitializeComponent();
        }

        public bool Parameters(string hostname, string ipAddress, Panel ipAddressContainer, bool writeToFile)
        {

            if (string.IsNullOrEmpty(hostname) && string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Please type a Hostname or an Ip Address");
                return false;
            }
            else if (string.IsNullOrEmpty(hostname))
            {
                hostname = "Empty Hostname";
            }
            else if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = "Empty Ip Address";
            }

            this.Dispatcher.Invoke(() =>
            {
                this.hostname = hostname;
                this.ip_Address = ipAddress;
                this.ipAddressContainer = ipAddressContainer;

            });

            if(writeToFile)
                FileForServerList.writeToFile(hostname, ip_Address);

            pingable = Pinger.UsingPinger(hostname, ip_Address);

            // Create a timer
            myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(repeat);
            // Set it to go off every five seconds
            myTimer.Interval = 5000;
            // And start it        
            myTimer.Enabled = true;

            createRow();

            return true;
        }

        public void repeat(object source, ElapsedEventArgs e)
        {
            pingable = Pinger.UsingPinger(hostname, ip_Address);
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
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        this.status.Background = System.Windows.Media.Brushes.White;
                    });
                }
                catch (Exception) { }
                
            }

            if (!pingable)
            {
                this.Dispatcher.Invoke(() => {
                    this.status.Background = System.Windows.Media.Brushes.Red;
                });
            }
        }

        

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            myTimer.Stop();
            myTimer = null;
            ipAddressContainer.Children.Remove(this);
        }
    }
}
