
/* ================= 예제 8.2: 익명 타입 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        var p = new { Count = 10, Title = "Anders" };

        Console.WriteLine(p.Title + ": " + p.Count); // 출력 결과: Anders: 10
    }
}

