
/* ================= 예제 6.34: UDP 소켓: 서버 측 바인딩 ================= */

using System;
using System.Net;
using System.Net.Sockets;
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
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPAddress ipAddress = GetCurrentIPAddress();

        if (ipAddress == null)
        {
            Console.WriteLine("IPv4용 랜 카드가 없습니다.");
            return;
        }

        IPEndPoint endPoint = new IPEndPoint(ipAddress, 10200);
        socket.Bind(endPoint);
    }

    // 현재 컴퓨터에 장착된 네트워크 어댑터의 IPv4 주소를 반환
    private static IPAddress GetCurrentIPAddress()
    {
        IPAddress[] addrs = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

        foreach (IPAddress ipAddr in addrs)
        {
            if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
            {
                return ipAddr;
            }
        }

        return null;
    }
}
