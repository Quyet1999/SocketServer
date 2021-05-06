using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace SocketServer
{
    public class ClientInformation
    {
        public Socket client { get; set; }
        public int ComputerID { get; set; }
        public ClientInformation() { }
        public ClientInformation(Socket _client)
        {
            client = _client;
        }
    }
}
