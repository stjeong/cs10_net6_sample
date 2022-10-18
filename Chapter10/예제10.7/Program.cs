
/* ================= 예제 10.7: 2개의 작업을 병렬로 처리하지만 모든 작업이 완료될 때까지 대기 ================= */

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task를 이용해 병렬로 처리
            var task3 = Method3Async();
            var task5 = Method5Async();

            // task3 작업과 task5 작업이 완료될 때까지 현재 스레드를 대기
            Task.WaitAll(task3, task5);

            Console.WriteLine(task3.Result + task5.Result);
        }

        private static Task<int> Method3Async()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                return 3;
            });
        }

        private static Task<int> Method5Async()
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                return 5;
            });
        }
    }
}