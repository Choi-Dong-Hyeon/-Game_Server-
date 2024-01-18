using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DummyClient
{
    class Program
    {
     
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();

            IPHostEntry hostIp = Dns.GetHostEntry(hostName);

            IPAddress hostIpAdress = hostIp.AddressList[0];

            IPEndPoint endPoint = new IPEndPoint(hostIpAdress, 7777);


            try
            {
                Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(endPoint);
                Console.WriteLine($"입장되었슴다");

                byte[] sendBuff = new byte[1024];

                sendBuff = Encoding.UTF8.GetBytes("안녕");

                socket.Send(sendBuff);

                byte[] receiveBuff = new byte[1024];

                string receiveData = Encoding.UTF8.GetString(receiveBuff, 0, receiveBuff.Length);

                socket.Receive(receiveBuff);

                Console.WriteLine(receiveData);

                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }
    }
}