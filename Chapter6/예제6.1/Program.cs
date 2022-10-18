
/* ================= 예제 6.1: DateTime을 이용한 시간차 계산 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime before = DateTime.Now;
        Sum();
        DateTime after = DateTime.Now;

        long gap = after.Ticks - before.Ticks;

        Console.WriteLine("Total Ticks: " + gap);
        Console.WriteLine("Millisecond: " + (gap / 10000));
        Console.WriteLine("Second: " + (gap / 10000 / 1000));
    }

    private static long Sum()
    {
        long sum = 0;
        for (int i = 0; i < 1000000; i++)
        {
            sum += i;
        }
        return sum;
    }
}
