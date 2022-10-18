
/* ================= 예제 10.5: ReadAllText 메서드를 비동기로 처리 ================= */

using System;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        public delegate string ReadAllTextDelegate(string path);

        static void Main(string[] args)
        {
            //string text = File.ReadAllText(@"C:\windows\system32\drivers\etc\HOSTS");
            //Console.WriteLine(text);

            string filePath = @"C:\windows\system32\drivers\etc\HOSTS";

            // 델리게이트를 이용한 비동기 처리
            ReadAllTextDelegate func = File.ReadAllText;
            func.BeginInvoke(filePath, actionCompleted, func);

            Console.ReadLine(); // 비동기 스레드가 완료될 때까지 대기하는 용도
        }

        static void actionCompleted(IAsyncResult ar)
        {
            ReadAllTextDelegate func = ar.AsyncState as ReadAllTextDelegate;

            string fileText = func.EndInvoke(ar);

            // 파일의 내용을 화면에 출력
            Console.WriteLine(fileText);
        }
    }
}

