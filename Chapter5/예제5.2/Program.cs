
/* ================= 예제 5.2: 타입의 범위를 넘어서는 연산 ================= */

using System;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                short c = 32767;
                c++;
                Console.WriteLine(c); // 출력 결과: -32768

                int n = 32768;
                c = (short)n;
                Console.WriteLine(c); // 출력 결과: -32768
            }

            {
                short c = -32768;
                c--;
                Console.WriteLine(c); // 출력 결과: 32767

                int n = -32769;
                c = (short)n;
                Console.WriteLine(c); // 출력 결과: 32767
            }
        }
    }
}
