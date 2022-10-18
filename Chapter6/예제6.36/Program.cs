
/* ================= 예제 6.36: UDP 클라이언트 소켓 ================= */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Socket clntSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
        EndPoint serverEP = new IPEndPoint(GetCurrentIPAddress(), 10200);

        clntSocket.SendTo(buf, serverEP);
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
