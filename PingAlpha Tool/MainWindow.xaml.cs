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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FileForServerList file = new FileForServerList();

            file.createDirectory();

            List<string> serverList = file.readFile();

            Console.WriteLine(serverList.Count);

            Console.WriteLine(serverList[0]);

            foreach(string item in serverList)
            {
                string hosts = item.Split(',')[0].Trim();
                string ip = item.Split(',')[1].Trim();

                Console.WriteLine(hosts);

                Console.WriteLine(ip);

                SingleIP addedIp = new SingleIP();
                addedIp.Parameters(hosts, ip, singleIpContainer, false);
                singleIpContainer.Children.Add(addedIp);

                //if (ip.Equals("Empty Hostname", StringComparison.OrdinalIgnoreCase))
                //{
                //    SingleIP addedIp = new SingleIP();
                //    bool createRow = addedIp.Parameters(hostNameBox.Text, ipAddressBox.Text, singleIpContainer);
                //    if (createRow)
                //        singleIpContainer.Children.Add(addedIp);
                //}
                //if (hosts.Equals("Empty Ip Address", StringComparison.OrdinalIgnoreCase))
                //{

                //}
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SingleIP addedIp = new SingleIP();
            bool createRow = addedIp.Parameters(hostNameBox.Text, ipAddressBox.Text, singleIpContainer, true);
            if(createRow)
                singleIpContainer.Children.Add(addedIp);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                button_Click(sender, e);
            }
        }

        
    }
}
