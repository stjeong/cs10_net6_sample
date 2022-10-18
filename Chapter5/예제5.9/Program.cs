
/* ================= 예제 5.9: DEBUG 전처리 상수 활용 ================= */

using System;
class Program
{
    static void Main(string[] args)
    {
#if DEBUG
        Console.WriteLine("디버그 빌드");
#endif
    }
}