
/* ================= 예제 6.25: 스레드에 안전한 메서드 ================= */

using System;
using System.Threading;

class MyData
{
    int number = 0;

    public object _numberLock = new object();

    public int Number { get { return number; } }

    public void Increment()
    {
        lock (_numberLock)
        {
            number++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyData data = new MyData();

        Thread t1 = new Thread(threadFunc);
        Thread t2 = new Thread(threadFunc);

        t1.Start(data);
        t2.Start(data);

        t1.Join();
        t2.Join();

        Console.WriteLine(data.Number);
    }

    static void threadFunc(object inst)
    {
        MyData data = inst as MyData;

        for (int i = 0; i < 100000; i++)
        {
            data.Increment();
        }
    }
}