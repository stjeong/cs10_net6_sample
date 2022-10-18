
/* ================= 예제 7.9: 변수에 담은 익명 메서드 ================= */

using System;
using System.Threading;

class Program
{
    delegate int? MyDivide(int a, int b);

    static void Main(string[] args)
    {
        MyDivide myFunc = delegate (int a, int b)
        {
            if (b == 0)
            {
                return null;
            }

            return a / b;
        };

        Console.WriteLine("10 / 2 == " + myFunc(10, 2)); // 출력 결과: 10 / 2 == 5
        Console.WriteLine("10 / 0 == " + myFunc(10, 0)); // 출력 결과: 10 / 2 ==
    }
}