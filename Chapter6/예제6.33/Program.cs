
/* ================= 예제 6.33: 소켓 프로그램 실습을 위한 기본 코드 ================= */

using System;
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
                           
        // 클라이언트 소켓이 동작하는 스레드
        Thread clientThread = new Thread(clientFunc);
        clientThread.IsBackground = true;
        clientThread.Start();

        Console.WriteLine("종료하려면 아무 키나 누르세요...");
        Console.ReadLine();
    }

    private static void serverFunc(object obj)
    {
        // ...... [서버 소켓 코드 작성] ......
    }

    private static void clientFunc(object obj)
    {
        // ...... [클라이언트 소켓 코드 작성] ......
    }
}