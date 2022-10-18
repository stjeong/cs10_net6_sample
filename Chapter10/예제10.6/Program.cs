
/* ================= 예제 10.6: 5초 + 3초 = 8초가 걸리는 작업 ================= */

using System;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int result3 = Method3();
            int result5 = Method5();

            Console.WriteLine(result3 + result5);
        }

        private static int Method3()
        {
            Thread.Sleep(3000); // 3초가 걸리는 작업을 대신해서 Sleep 처리
            return 3;
        }

        private static int Method5()
        {
            Thread.Sleep(5000); // 5초가 걸리는 작업을 대신해서 Sleep 처리
            return 5;
        }
    }
}

