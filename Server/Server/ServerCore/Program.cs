using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore
{
    class Program
    {
        static Listener listener = new Listener();
        static void OnAcceptHandler(Socket clientSocket)
        {
            try
            {
                Session session = new Session();
                session.Start(clientSocket);

                byte[] sendBuff = Encoding.UTF8.GetBytes("접속되었습니다");
                session.Send(sendBuff);

                Thread.Sleep(1000);

                session.Disconnect();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();

            IPHostEntry hostIp = Dns.GetHostEntry(hostName);

            IPAddress hostIpAdress = hostIp.AddressList[0];

            IPEndPoint endPoint = new IPEndPoint(hostIpAdress, 10000);

            listener.Init(endPoint, OnAcceptHandler);

            Console.WriteLine("리스닝중");
            while (true) { }
        }
    }

}