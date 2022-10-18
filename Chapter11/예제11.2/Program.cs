
/* ================= 예제 11.2: enum, const 필드에 using static 적용 ================= */

using System;
using System.Net;
using System.Text;

using static MyDay;
using static BitMode;
using static System.Console;

public enum MyDay
{
    Saturday, Sunday, // enum 필드의 내부 구현은 static 속성을 갖는다.
}

public class BitMode
{
    // const 필드의 내부 구현은 static 속성을 갖는다.
    public const int ON = 1;
    public const int OFF = 0;
}

namespace ConsoleApplication1
{
    class Program
    {
        public const int x = 5;
        public bool _expression1 => (x >= 100) || (x < 300);
        public void WriteTest() => System.Console.WriteLine("test");
        public string Text => "Hello World";

        //public void Statement1 => int a = 100;
        //public void Statement2() => if (x > 100) Console.WriteLine();
        //public void Statement3() => ;

        static void Main(string[] args)
        {
            MyDay day = Saturday; // "using static MyDay"로 인해 타입명 생략됨
            int bit = ON; // "using static BitMode"로 인해 타입명 생략됨

            WriteLine(day); // 출력 결과: Saturday
            WriteLine(bit); // 출력 결과: 1

            // "Hello World";
        }
    }
}
