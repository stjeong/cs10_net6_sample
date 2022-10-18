
/* ================= 예제 6.42: TCP 소켓으로 구현한 HTTP 서버 ================= */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        using (Socket srvSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            Console.WriteLine("http://localhost:8000으로 방문해 보세요.");

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);

            srvSocket.Bind(endPoint);
            srvSocket.Listen(10);

            while (true)
            {
                Socket clntSocket = srvSocket.Accept();
                ThreadPool.QueueUserWorkItem(httpProcessFunc, clntSocket);
            }
        }
    }

    private static void httpProcessFunc(object state)
    {
        Socket socket = state as Socket;

        byte[] reqBuf = new byte[4096];
        socket.Receive(reqBuf);

        string header = "HTTP/1.0 200 OK\nContent-Type: text/html; charset=UTF-8\r\n\r\n";
        string body = "<html><body><mark>테스트 HTML</mark> 웹 페이지입니다.</body></html>";

        byte[] respBuf = Encoding.UTF8.GetBytes(header + body);
        socket.Send(respBuf);

        socket.Close();
    }
}


