
/* ================= 예제 4.3: 제곱 메서드 정의 ================= */

using System;

namespace ConsoleApplication1
{
    class Mathematics
    {
        public int f(int x)
        {
            return x * x;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mathematics m = new Mathematics();
            int result = m.f(5);
            Console.WriteLine(result); // 출력 결과: 25
        }
    }
}
