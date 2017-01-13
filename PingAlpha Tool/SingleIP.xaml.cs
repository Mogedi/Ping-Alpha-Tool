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

namespace PingAlpha_Tool
{
    /// <summary>
    /// Interaction logic for SingleIP.xaml
    /// </summary>
    public partial class SingleIP : UserControl
    {
        string hostname;
        string ip_Address;
        public SingleIP()
        {
            InitializeComponent();
        }

        public void Parameters(string hostname, string ipAddress)
        {
            this.Dispatcher.Invoke(() =>
            {
                this.hostname = hostname;
                this.ip_Address = ipAddress;
            });

            MessageBox.Show(hostname + " " + ip_Address);

            FileForServerList.writeToFile(hostname, ipAddress);
        }
    }
}
