using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace ServerCore
{
    class Listener
    {
        Socket listenerSocket;

        public void Init(IPEndPoint endPoint)
        {
            listenerSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listenerSocket.Bind(endPoint);
            listenerSocket.Listen(10);
        }

        public Socket Accept()
        {
            Socket clientSocket = listenerSocket.Accept();
            
            return clientSocket;
        }
    }
}
