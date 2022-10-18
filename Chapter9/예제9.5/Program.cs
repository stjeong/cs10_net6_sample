
/* ================= 예제 9.5: 덕 타이핑 ================= */

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string txt = "test func";
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };

        Console.WriteLine(DuckTypingCall(txt, "test")); // 출력 결과: 0
        Console.WriteLine(DuckTypingCall(list, 3)); // 출력 결과: 2
    }

    static int DuckTypingCall(dynamic target, dynamic item)
    {
        return target.IndexOf(item);
    }
}
