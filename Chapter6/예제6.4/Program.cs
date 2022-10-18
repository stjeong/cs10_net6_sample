
/* ================= 예제 6.4: 비효율적인 문자열 연산 ================= */

using System;

class Program
{
    static void Main(string[] args)
    {
        string txt = "Hello World";

        for (int i = 0; i < 300000; i++)
        {
            txt = txt + "1";
        }
    }
}

