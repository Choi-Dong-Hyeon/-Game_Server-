using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //DNS  (Domain Name System)

            Listener listener = new Listener();

            string hostName = Dns.GetHostName();

            IPHostEntry hostIp = Dns.GetHostEntry(hostName);

            IPAddress hostIpAdress = hostIp.AddressList[0];

            IPEndPoint endPoint = new IPEndPoint(hostIpAdress, 7777);

            Socket listenSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenSocket.Bind(endPoint);

                listenSocket.Listen(10);

                while (true)
                {
                    Console.WriteLine("서버오픈");

                    Socket clientSocket = listenSocket.Accept();

                    byte[] buff = new byte[1024];
                    int reciveByte = clientSocket.Receive(buff);
                    string reciveData = Encoding.UTF8.GetString(buff, 0, reciveByte);
                    Console.WriteLine($"클라에서 온메세지 : [{reciveData}]");


                    byte[] sendBuff = Encoding.UTF8.GetBytes("접속되었습니다");
                    clientSocket.Send(sendBuff);

                    clientSocket.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

}