
/* ================= 예제 10.8: 2개의 작업을 병렬로, 비동기 호출 ================= */

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
            // await을 이용해 병렬로 비동기 호출: 5초 소요
            DoAsyncTask();
            Console.ReadLine();
        }

        private static async Task DoAsyncTask()
        {
            var task3 = Method3Async();
            var task5 = Method5Async();

            await Task.WhenAll(task3, task5);

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

