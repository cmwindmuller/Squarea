using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace C33.XR
{

    public class Network : MonoBehaviour
    {

        public static Network player;
        public IPAddressInformation ipInfo;

        private void Start()
        {
            player = this;
            scan();
        }

        public string ipAddress { get { return ipInfo.Address.ToString(); } }

        void scan()
        {
            foreach( NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces() )
            {
                if( ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet )
                {
                    foreach( UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses )
                    {
                        if( ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
                        {
                            ipInfo = ip;
                            break;
                        }
                    }
                }
            }
        }


    }
}