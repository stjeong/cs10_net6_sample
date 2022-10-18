
/* ================= 예제 6.41: TCP 소켓을 이용한 HTTP 통신 ================= */

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress ipAddr = Dns.GetHostEntry("www.naver.com").AddressList[0];
        EndPoint serverEP = new IPEndPoint(ipAddr, 80);
        socket.Connect(serverEP);

        string request = "GET / HTTP/1.0\r\nHost: www.naver.com\r\n\r\n";
        byte[] sendBuffer = Encoding.UTF8.GetBytes(request);
        // 네이버 웹 서버로 HTTP 요청을 전송
        socket.Send(sendBuffer);
        // HTTP 요청이 전달됐으므로 네이버 웹 서버로부터 응답을 수신
        MemoryStream ms = new MemoryStream();
        while (true)
        {
            byte[] rcvBuffer = new byte[4096];
            int nRecv = socket.Receive(rcvBuffer);

            if (nRecv == 0)
            {
                // 서버 측에서 더 이상 받을 데이터가 없으면 0을 반환
                break;
            }

            ms.Write(rcvBuffer, 0, nRecv);
        }

        socket.Close();
        string response = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);

        Console.WriteLine(response);
        // 서버 측에서 받은 HTML 데이터를 파일로 저장
        File.WriteAllText("naverpage.html", response);
    }
}

