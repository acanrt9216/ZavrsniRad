using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Biblioteka;

namespace Server
{
    public partial class ServerKlasa
    {
        Socket soket;
        private ServerKlasa formServer;

        public ServerKlasa(ServerKlasa formServer)
        {
            this.formServer = formServer;
        }
        public bool pokreniServer() 
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 11000);
                soket.Bind(ep);

                ThreadStart ts = osluskuj;
                Thread nit = new Thread(ts);
                nit.Start();

                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        void osluskuj() 
        {
            try
            {
                while (true) 
                {
                    soket.Listen(5);
                    Socket klijent = soket.Accept();
                    NetworkStream tok = new NetworkStream(klijent);
                    new Obrada(tok,formServer);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

    }
}
