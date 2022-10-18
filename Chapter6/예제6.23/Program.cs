
/* ================= 예제 6.23: 다중 스레드에서 단일 변수 사용 ================= */

using System;
using System.Threading;

class Program
{
    int number = 0;

    static void Main(string[] args)
    {
        Program pg = new Program();

        Thread t1 = new Thread(threadFunc);
        Thread t2 = new Thread(threadFunc);

        t1.Start(pg);
        t2.Start(pg); // 2개의 스레드를 시작하고,

        t1.Join();
        t2.Join(); // 2개의 스레드 실행이 끝날 때까지 대기한다.

        Console.WriteLine(pg.number); // 스레드 실행 완료 후 number 필드 값을 출력
    }

    static void threadFunc(object inst)
    {
        Program pg = inst as Program;

        for (int i = 0; i < 10; i++)
        // for (int i = 0; i < 10000; i++)
        {
            pg.number = pg.number + 1; // Program 객체의 number 필드 값을 증가
        }
    }
}