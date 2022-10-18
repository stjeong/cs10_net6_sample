
/* ================= 예제 6.26: 스레드에 안전하지 않은 메서드를 외부에서 안전하게 사용하는 방법 ================= */

using System;
using System.Threading;

class MyData
{
    int number = 0;

    public int Number { get { return number; } }

    public void Increment()
    {
        number++;
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
            lock (data)
            {
                data.Increment();
            }
        }
    }
}
