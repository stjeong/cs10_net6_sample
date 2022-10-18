
/* ================= 예제 3.2: 정수형 변수를 더하는 코드 ================= */

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 50; // 선언과 동시에 값을 부여할 수도 있고
            int n2; // 선언만 하고
            n2 = 100; // 값은 나중에 부여하는 것도 가능하다.

            long sum = n1 + n2; // 더한 값을 저장

            Console.WriteLine(sum); // 출력 결과: 150
        }
    }
}

