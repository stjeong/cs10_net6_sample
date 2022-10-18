
/* ================= 10.2.2 Task, Task<TResult> 타입 ================= */

using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Task taskSleep = new Task(() => { Thread.Sleep(5000); });
        taskSleep.Start();
        taskSleep.Wait(); // Task의 작업이 완료될 때까지 현재 스레드를 대기한다.

        Task.Factory.StartNew(() => { Console.WriteLine("process taskitem"); });

        Task.Factory.StartNew((obj) => { Console.WriteLine("process taskitem(obj)"); }, null);

        Task<int> task = new Task<int>(
            () =>
            {
                Random rand = new Random((int)DateTime.Now.Ticks);
                return rand.Next();
            }
        );

        task.Start();
        task.Wait();

        Console.WriteLine("무작위 숫자 값: " + task.Result);

        Task<int> taskReturn = Task.Factory.StartNew<int>(() => 1);
        taskReturn.Wait();
        Console.WriteLine(taskReturn.Result);
    }
}
