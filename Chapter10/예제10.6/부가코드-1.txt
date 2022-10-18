
/* ================= 10.2.5 비동기 호출의 병렬 처리 ================= */

using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            Thread t3 = new Thread((result) =>
            {
                Thread.Sleep(3000);
                dict.Add("t3Result", 3);
            });

            Thread t5 = new Thread((result) =>
            {
                Thread.Sleep(5000);
                dict.Add("t5Result", 5);
            });

            t3.Start(dict);
            t5.Start(dict);

            t3.Join(); // 3초짜리 작업이 완료되기를 대기
            t5.Join(); // 5초짜리 작업도 완료되기를 대기
                       // 약 5초 후에 모든 결괏값을 얻어 처리 가능

            Console.WriteLine(dict["t3Result"] + dict["t5Result"]);
        }
    }
}