
/* ================= 예제 10.4: Task 타입 ================= */

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 기존의 QueueUserWorkItem으로 별도의 스레드에서 작업을 수행
            ThreadPool.QueueUserWorkItem(
                (obj) =>
                {
                    Console.WriteLine("process workitem");
                }, null);

            // .NET 4.0의 Task 타입을 이용해 별도의 스레드에서 작업을 수행
            Task task1 = new Task(
                () =>
                {
                    Console.WriteLine("process taskitem");
                });

            task1.Start();

            Task task2 = new Task(
                (obj) =>
                {
                    Console.WriteLine("process taskitem(obj)");
                }, null);

            task2.Start();

            Console.ReadLine();
        }
    }
}


