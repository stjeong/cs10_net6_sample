
/* ================= 예제 6.20: Join 메서드 사용 예 ================= */

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread t = new Thread(threadFunc);
        t.IsBackground = true;
        t.Start();

        t.Join(); // t 스레드가 종료될 때까지 현재 스레드를 무한 대기
        Console.WriteLine("주 스레드 종료!");
    }

    static void threadFunc()
    {
        Console.WriteLine("60초 후에 프로그램 종료");
        Thread.Sleep(1000 * 60); // 60초 동안 실행 중지
        Console.WriteLine("스레드 종료!");
    }
}

