
/* ================= 예제 10.3: 동기식 코드 ================= */

using System;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient wc = new WebClient();
            string text = wc.DownloadString("http://www.microsoft.com");
            Console.WriteLine(text);
        }
    }
}

