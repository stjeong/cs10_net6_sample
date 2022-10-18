
/* ================= 예제 6.19: 2개의 스레드 실행이 완료된 후 프로그램 종료 ================= */

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread t = new Thread(threadFunc);
        // t.IsBackground = true;

        t.Start();
        // 더는 주 스레드가 실행할 명령어가 없으므로 주 스레드는 제거됨
    }

    static void threadFunc()
    {
        Console.WriteLine("60초 후에 프로그램 종료");
        Thread.Sleep(1000 * 60); // 60초 동안 실행 중지
                                 // 현재 주 스레드는 종료됐어도 t 스레드는 존속한다.
        Console.WriteLine("스레드 종료!");
    }
}

