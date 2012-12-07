using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SliceOfPie
{
    public class ClientSystemFacade
    {
        private static ClientSystemFacade instance;
        private Socket socket;
        internal static ClientSystemFacade GetInstance()
        {
            if (instance == null)
            {
                instance = new ClientSystemFacade();
            }
            return instance;
        }

        private ClientSystemFacade()
        {
            IPEndPoint ipe = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0], 8080);
            socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipe);
            socket.Listen(1000);
            Socket socketConnection = socket.Accept();
            Byte[] bytes = new Byte[100];
            socketConnection.Receive(bytes);
            string recievedString = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("ClientSystemFacade - constructor - recievedString: " + recievedString);
        }
    }
}
