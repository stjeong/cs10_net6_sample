
/* ================= 예제 7.8: 익명 메서드 사용 ================= */

using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Thread thread = new Thread(
            delegate (object obj)
            {
                Console.WriteLine("ThreadFunc in anonymous method called!");
            });

        thread.Start();
        thread.Join();
    }
}

