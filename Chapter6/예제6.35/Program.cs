
/* ================= 예제 6.35: UDP 서버 측 소켓을 구현 ================= */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // 서버 소켓이 동작하는 스레드
        Thread serverThread = new Thread(serverFunc);
        serverThread.IsBackground = true;
        serverThread.Start();
        Thread.Sleep(500); // 소켓 서버용 스레드가 실행될 시간을 주기 위해

        Console.WriteLine("종료하려면 아무 키나 누르세요...");
        Console.ReadLine();
    }

    private static void serverFunc(object obj)
    {
        Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);

        srvSocket.Bind(endPoint);

        byte[] recvBytes = new byte[1024];
        EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

        while (true)
        {
            int nRecv = srvSocket.ReceiveFrom(recvBytes, ref clientEP);
            string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

            byte[] sendBytes = Encoding.UTF8.GetBytes("Hello: " + txt);
            srvSocket.SendTo(sendBytes, clientEP);
        }
    }
}