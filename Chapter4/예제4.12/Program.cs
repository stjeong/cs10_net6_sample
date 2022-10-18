
/* ================= 예제 4.12 as의 잘못된 사용예 ================= */

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            string txt = "text";

            /*
            if ((n as string) != null) // 컴파일 오류 발생
            {
                Console.WriteLine("변수 n은 string 타입");
            }

            if ((txt as int) != null) // 컴파일 오류 발생
            {
                Console.WriteLine("변수 txt는 int 타입");
            }
            */

            n = 5;
            if (n is string)
            {
                Console.WriteLine("변수 n은 string 타입");
            }
            txt = "text";
            if (txt is int)
            {
                Console.WriteLine("변수 txt는 int 타입");
            }
        }
    }
}
