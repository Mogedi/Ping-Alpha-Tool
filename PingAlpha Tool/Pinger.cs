using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PingAlpha_Tool
{
    class Pinger
    {


        public PingReply[] PingAlpha(string hostname, string ip_Address)
        {
            
            try
            {
                Ping pinger = new Ping();
                PingReply pingIpAddressReply = null;
                PingReply pingHostnameReply = null;
                PingReply[] pingReplyArray = new PingReply[1];

                if (ip_Address.Equals("Empty Ip Address", StringComparison.OrdinalIgnoreCase))
                {
                    pingHostnameReply = pinger.Send(hostname, 500);
                    pingReplyArray[0] = pingHostnameReply;
                } else
                {
                    pingIpAddressReply = pinger.Send(ip_Address, 500);
                    pingReplyArray[0] = pingIpAddressReply;
                }

                //if (!(string.IsNullOrEmpty(hostname)) && !(string.IsNullOrEmpty(ip_Address)))
                //{
                //    pingIpAddressReply = pinger.Send(ip_Address, 500);
                //    pingReplyArray[0] = pingIpAddressReply;
                //}

                //if ((string.IsNullOrEmpty(hostname)))
                //{
                //    pingIpAddressReply = pinger.Send(ip_Address, 500);
                //    pingReplyArray[0] = pingIpAddressReply;
                //}
                //if ((string.IsNullOrEmpty(ip_Address)))
                //{
                //    pingHostnameReply = pinger.Send(hostname, 500);
                //    pingReplyArray[0] = pingHostnameReply;
                //}

                return pingReplyArray;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static bool UsingPinger(string hostname, string ip_Address)
        {
            try
            {

                if (!(string.IsNullOrEmpty(hostname)) || !(string.IsNullOrEmpty(ip_Address)))
                {
                    Pinger ping = new Pinger();

                    PingReply[] pingResults = ping.PingAlpha(hostname, ip_Address);

                    if (pingResults[0].Status == 0)
                    {
                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }


}
