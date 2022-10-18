
/* ================= 예제 5.5: public 접근 제한자의 LogWriter 타입 정의 ================= */

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter logWriter = new LogWriter();
            logWriter.Write("start");
        }
    }
}


