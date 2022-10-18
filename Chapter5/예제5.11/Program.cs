
/* ================= 예제 5.11: Console, Debug, Trace 타입을 사용한 출력 예제 ================= */

using System;
using System.Diagnostics;


// DebugView
// http://technet.microsoft.com/en-us/sysinternals/bb896647.aspx

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("사용자 화면 출력");
        Debug.WriteLine("디버그 화면 출력 - Debug");
        Trace.WriteLine("디버그 화면 출력 - Trace");
    }
}
