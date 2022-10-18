
/* ================= 예제 6.28: 개선된 ThreadPool의 사용 예 ================= */

using System;
using System.Collections;
using System.Threading;

class MyData
{
    int number = 0;

    public int Number { get { return number; } }

    public void Increment()
    {
        Interlocked.Increment(ref number);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyData data = new MyData();

        Hashtable ht1 = new Hashtable();
        ht1["data"] = data;
        ht1["evt"] = new EventWaitHandle(false, EventResetMode.ManualReset);

        // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달한다.
        ThreadPool.QueueUserWorkItem(threadFunc, ht1);
        Hashtable ht2 = new Hashtable();

        ht2["data"] = data;
        ht2["evt"] = new EventWaitHandle(false, EventResetMode.ManualReset);

        // 데이터와 함께 이벤트 객체를 스레드 풀의 스레드에 전달한다.
        ThreadPool.QueueUserWorkItem(threadFunc, ht2);

        // 2개의 이벤트 객체가 Signal 상태로 바뀔 때까지 대기한다.
        (ht1["evt"] as EventWaitHandle).WaitOne();
        (ht2["evt"] as EventWaitHandle).WaitOne();

        Console.WriteLine(data.Number);
    }

    static void threadFunc(object inst)
    {
        Hashtable ht = inst as Hashtable;
        MyData data = ht["data"] as MyData;

        for (int i = 0; i < 100000; i++)
        {
            data.Increment();
        }

        // 주어진 이벤트 객체를 Signal 상태로 전환한다.
        (ht["evt"] as EventWaitHandle).Set();
    }
}

