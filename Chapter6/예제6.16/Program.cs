
/* ================= 예제 6.16: Queue 사용 예 ================= */

using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Queue q = new Queue();

        q.Enqueue(1);
        q.Enqueue(5);
        q.Enqueue(3);

        int first = (int)q.Dequeue();
        q.Enqueue(7);

        while (q.Count > 0)
        {
            Console.Write(q.Dequeue() + ", ");
        } // 큐를 Dequeue 과정 없이 비우고 싶다면 q.Clear() 메서드를 호출해도 된다.
    }
}

